
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using Accela.Apps.Apis.Repositories.Agency.AARESTModels;
using Accela.Apps.Apis.Repositories.CitizenHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;
using Accela.Automation.CitizenServices.Client.Models;
using Accela.Automation.CitizenServices.Client.Models.Request.Document;
using Accela.Automation.CitizenServices.Client.Models.Response.Document;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Gateway.Client;
using Accela.Apps.Shared.Contants;
using System.Net.Http;
namespace Accela.Apps.Apis.Repositories.Citizen
{
    /// <summary>
    /// Attachment repository class.
    /// </summary>
    public class AttachmentRepository : RepositoryBase, IAttachmentRepository
    {

        private IGatewayClient _gatewayClient;
        //private RestClient _restClient;
        //private RestClient RestClient
        //{
        //    get
        //    {
        //        if (_restClient == null)
        //        {
        //            _restClient = new RestClient(this.CurrentContext.Agency, this.CurrentContext.EnvName);
        //        }

        //        return _restClient;
        //    }
        //}

        //public AttachmentRepository(string appId, string agencyName, string serviceProvCode, string agencyUserId, string agencyUsername, string token, string environmentName, string language)
        //    : base(appId, agencyName, serviceProvCode, agencyUserId, agencyUsername, token, environmentName, language)
        //{

        //}

        //private readonly IAgencyAppContext currentAgencyContext;
        public AttachmentRepository(IAgencyAppContext contextEntity, IGatewayClient gatewayClient)
            : base(contextEntity)
        {
            //this.currentAgencyContext = contextEntity;
            _gatewayClient = gatewayClient;
        }


        public CreateAttachmentResponse CreateAttachment(CreateAttachmentRequest request)
        {
            if (request == null)
            {
                return null;
            }

            if (request.EntityId == null)
            {
                return null;
            }

            string[] capIds = request.EntityId.Split('-');

            var documentRequest = new CreateDocumentRequest()
            {
                entityID = request.EntityId,
                entityType = request.EntityType,
                fileName = request.Attachment.FileName,
                documentContent = new DocumentContentModel() { docContentStream = GetFileContent(request.FileContent) },
                capID = new CapID()
                {
                    id1 = capIds[0],
                    id2 = capIds[1],
                    id3 = capIds[2]
                }
            };

            if (documentRequest.capID != null)
            {
                documentRequest.capID.serviceProviderCode = this.CurrentContext.ServProvCode;
            }

            documentRequest.serviceProviderCode = this.CurrentContext.ServProvCode;
            var uriTemplate = "records/{0}-{1}/documents?token={2}";
            string uri = String.Format(uriTemplate, this.CurrentContext.ServProvCode, request.EntityId, this.CurrentContext.SocialToken);
            //var citizenResult = RestClient.Execute<CreateDocumentResponse>(uri, documentRequest);
            var citizenResult = _gatewayClient.Post<CreateDocumentResponse>(ApiTypes.NormalApi, uri, documentRequest);

            EventMessage message = new EventMessage()
            {
                EventCode = citizenResult.responseStatus.status,
                DetailInfo = citizenResult.responseStatus.detail == null ? string.Empty : citizenResult.responseStatus.detail.message
            };

            return new CreateAttachmentResponse()
            {
                Events = new List<EventMessage>() { message }
            };
        }

        private static string GetFileContent(Stream stream)
        {
            if (stream != null)
            {
                stream.Position = 0;
                int streamLength = (int)stream.Length;
                var bytes = new byte[streamLength];
                stream.Read(bytes, 0, streamLength);
                string strBase64 = Convert.ToBase64String(bytes);
                return strBase64;
            }

            return null;
        }

        public AttachmentsResponse GetAttachments(AttachmentsRequest request)
        {
            string requestUrl = string.Format("records/{0}/documents?token={1}", this.CurrentContext.ServProvCode + "-" + request.EntityId, this.CurrentContext.SocialToken);
            var response = _gatewayClient.Get<CitizenRecordDocumentsResponse>(ApiTypes.NormalApi, requestUrl);
            var documentsResponse = CitizenAttachmentHelper.GetAttachmentsResponse(response);
            return documentsResponse;
        }

        public Attachment GetAttachmentContent(AttachmentContentRequest request)
        {
            var uriTemplate = "documents/{0}?token={1}";
            string uri = String.Format(uriTemplate, request.AttachmentId, this.CurrentContext.SocialToken);
            var citizenResult = _gatewayClient.GetAsync<GetDocumentContentResponse>(ApiTypes.NormalApi, uri).Result;
            return CitizenAttachmentHelper.ToEntityAttachment(citizenResult);
        }


        public string CreateAttachment(AttachmentUploadRequest attachmentRequest, MemoryStream stream)
        {
            throw new NotImplementedException();
        }

        public UploadAttachmentDescResponse UploadAttachmentDesc(UploadAttachmentDescRequest request)
        {
            throw new NotImplementedException();
        }


        public Attachment GetAttachment(AttachmentRequest request)
        {
            var attachment = GetAttachmentContent(new AttachmentContentRequest()
                                                      {
                                                          AttachmentId = request.DocumentId,
                                                          EntityId = request.RecordId,
                                                          EntityType = request.EntityType
                                                      });

            return attachment;
        }

        public AttachmentV4Model GetAttachmentV4Info(AttachmentV4Request request)
        {
            const string requestUrlTemplate = "apis/v4/documents/{0}?token={1}";
            var requestUrl = String.Format(requestUrlTemplate, request.AttachmentId, this.CurrentContext.SocialToken);
            var aaResult = _gatewayClient.Get<AADocumentResponse>(ApiTypes.NormalApi,requestUrl);

            if (aaResult.result == null)
            {
                throw new NotFoundException("The given document is not found.");
            }

            return new AttachmentV4Model
            {
                Id = aaResult.result[0].id.ToString(CultureInfo.InvariantCulture),
                ContentType = aaResult.result[0].type,
                FileName = aaResult.result[0].fileName,
                ServiceProviderCode = aaResult.result[0].serviceProviderCode
            };
        }

        public Stream GetRawDocumentContent(string attachmentId)
        {
            const string requestUrlTemplate = "apis/v4/documents/{0}/download?token={1}";
            var requestUrl = String.Format(requestUrlTemplate, attachmentId, this.CurrentContext.SocialToken);

            IDictionary<string, string> header = new Dictionary<string, string>();
            header.Add("Content-Type", "application/json");
            header.Add("Accept", "application/octet-stream");

            //HttpRequestMessage requestMessage = new HttpRequestMessage
            //{
            //    RequestUri = new Uri(requestUrl)
            //};

            //return RestClient.DownloadStream(requestUrl);
            var response = _gatewayClient.Send(ApiTypes.NormalApi,requestUrl,HttpMethod.Get);

            if(response != null && response.Content != null)
            {
                return response.Content.ReadAsStreamAsync().Result;
            }
            else
            {
                return null;
            }
        }
    }
}
