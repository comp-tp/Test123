using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using Accela.Apps.Apis.Repositories.Agency.AARESTModels;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.GovXmlQueries;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Resources;
using Accela.Core.Ioc;
using Accela.Apps.Shared;
using Accela.Automation.GovXmlClient.Model;
using System;
using Accela.Apps.Shared.Contexts;
using System.Globalization;
using System.IO;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Gateway.Client;
using System.Net.Http;
using Accela.Apps.Shared.Exceptions;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class AttachmentRepository : RepositoryBase, IAttachmentRepository
    {
        private IMobileEntityRepository<Attachment> _attachmentMECache;
        private IMobileEntityRepository<UploadAttachmentDescRequest> _inspectionDescCache;
        private InspectionCache _inspectionCache;
        private IGatewayClient _gatewayClient;

        //private readonly IAgencyAppContext currentAgencyContext;

        //public AttachmentRepository(string appId, string agencyName, string serviceProvCode, string agencyUserId, string agencyUsername, string token, string environmentName, string language)
        //    : base(appId, agencyName, serviceProvCode, agencyUserId, agencyUsername, token, environmentName, language)
        //{
        //    _inspectionCache = InspectionCache.Instance;
        //    _attachmentMECache = IocContainer.Resolve<IMobileEntityRepository<Attachment>>();
        //    _inspectionDescCache = IocContainer.Resolve<IMobileEntityRepository<UploadAttachmentDescRequest>>();
        //}

        public AttachmentRepository(IAgencyAppContext contextEntity, IGatewayClient gatewayClient, IMobileEntityRepository<Attachment> attachmentMECache = null, IMobileEntityRepository<UploadAttachmentDescRequest> inspectionDescCache = null)
            : base(contextEntity)
        {
            _inspectionCache = InspectionCache.Instance;          
           _gatewayClient = gatewayClient;

            if (attachmentMECache != null)
                _attachmentMECache = attachmentMECache;
            else
                _attachmentMECache = IocContainer.Resolve<IMobileEntityRepository<Attachment>>();

            if (inspectionDescCache != null)
                _inspectionDescCache = inspectionDescCache;
            else
                _inspectionDescCache = IocContainer.Resolve<IMobileEntityRepository<UploadAttachmentDescRequest>>();
            //this.currentAgencyContext = contextEntity;
        }

        //public AttachmentRepository(IAgencyAppContext contextEntity, IGatewayClient gatewayClient)
        //    : base(contextEntity)
        //{
        //    _inspectionCache = InspectionCache.Instance;
        //    _attachmentMECache = IocContainer.Resolve<IMobileEntityRepository<Attachment>>();
        //    _inspectionDescCache = IocContainer.Resolve<IMobileEntityRepository<UploadAttachmentDescRequest>>();
        //    _gatewayClient = gatewayClient;
        //}

        //private AARestClient _restClient;
        //private AARestClient RestClient
        //{
        //    get
        //    {
        //        if (_restClient == null)
        //        {
        //            _restClient = new AARestClient(this.CurrentContext.Agency, this.CurrentContext.EnvName);
        //        }

        //        return _restClient;
        //    }
        //}

        public AttachmentsResponse GetAttachments(AttachmentsRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getDocumentList = new GetDocumentList();
            govXmlIn.getDocumentList.system = CommonHelper.GetSystem(request, this.CurrentContext);
            govXmlIn.getDocumentList.objectId = new ObjectId();
            govXmlIn.getDocumentList.objectId.contextType = request.EntityType;
            if (!String.IsNullOrEmpty(request.EntityId))
            {
                govXmlIn.getDocumentList.objectId.keys = KeysHelper.CreateXMLKeys(request.EntityId);
            }

            /*
             * Implementation Notes:
      
             From AA version 7.2.0 Hotfix 8 and version 7.1.0 SP13 on, no need to send the EDMS Adapter information to the GovXML
             when downloading the list of document of RECORD and/or INSPECTION and the binary document file.
     
             So we can simply comment the EDMSAdapter property.
            // */
            //govXmlIn.getDocumentList.EDMSAdapters = GetEDMSAnonymousAdapters();

            GovXML response = CommonHelper.Post(govXmlIn,
                                                govXmlIn.getDocumentList.system,
                                                (o) => o.getDocumentListResponse == null ? null : o.getDocumentListResponse.system);

            AttachmentsResponse result = AttachmentHelper.GetClientAttachments(response.getDocumentListResponse);

            return result;
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
            var aaResult = _gatewayClient.Get<AADocumentResponse>(ApiTypes.NormalApi, requestUrl); //   RestClient.ExecuteV4<AADocumentResponse>(requestUrl);
            
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
            //return RestClient.DownloadStream(requestUrl);
            var response = _gatewayClient.Send(ApiTypes.NormalApi, requestUrl,HttpMethod.Get);

            if (response != null && response.Content != null && response.StatusCode!= System.Net.HttpStatusCode.NoContent)
            {
                return response.Content.ReadAsStreamAsync().Result;
            }
            else
            {
                return null;
            }
        }

        public Attachment GetAttachmentContent(AttachmentContentRequest request)
        {
            Attachment result = null;

            if (request != null)
            {
                var cachedAttachment = _inspectionCache.GetAttachmentFileInfo(request.AttachmentId, this.CurrentContext);

                if (cachedAttachment != null)
                {
                    var memoryStream = _inspectionCache.GetAttachmentFile(request.AttachmentId, this.CurrentContext);

                    if (memoryStream != null)
                    {
                        cachedAttachment.Content = memoryStream != null ? AttachmentHelper.GetFileBase64String(memoryStream) : String.Empty;
                        result = cachedAttachment;
                    }
                }

                if (result == null)
                {
                    var query = new AttachmentsQuery()
                    {
                        AttachmentId = request.AttachmentId
                    };

                    GovXML govXmlIn = new GovXML();
                    govXmlIn.getDocument = new GetDocument();
                    govXmlIn.getDocument.system = CommonHelper.GetSystem(request, this.CurrentContext);
                    if (!String.IsNullOrEmpty(request.AttachmentId))
                    {
                        govXmlIn.getDocument.documentId = new DocumentId();
                        govXmlIn.getDocument.documentId.keys = KeysHelper.CreateXMLKeys(request.AttachmentId);
                    }

                    GovXML response = CommonHelper.Post(govXmlIn,
                                                        govXmlIn.getDocument.system,
                                                        (o) => o.getDocumentResponse == null ? null : o.getDocumentResponse.system);

                    Attachment attachment = AttachmentHelper.GetClientAttachment(response.getDocumentResponse);

                    _inspectionCache.CacheAttachment(attachment, false, this.CurrentContext);

                    result = attachment;
                }
            }

            return result;
        }

        public UploadAttachmentDescResponse UploadAttachmentDesc(UploadAttachmentDescRequest request)
        {
            string key = Guid.NewGuid().ToString();
            MobileEntity descEntity = new MobileEntity(QueryHelpler.GetEntityScope(EntityTypes.AttachmentDescription, this.CurrentContext));

            descEntity.ObjectId = key;
            descEntity.ObjectData = JsonConverter.ToJson(request);
            descEntity.ExpiresAfter = DateTime.UtcNow.AddMinutes(20);
            descEntity.Timestamp = DateTime.UtcNow;

            _inspectionDescCache.InsertEntity(descEntity);

            UploadAttachmentDescResponse response = new UploadAttachmentDescResponse();
            response.Key = key;
            return response;
        }

        public string CreateAttachment(AttachmentUploadRequest attachmentRequest, MemoryStream stream)
        {
            //1. Upload desc and retu a key to client
            //2. Upload file stream
            //  a. get desc from desc key
            //  b. set desc to attachment model
            //Get desc from blob
            UploadAttachmentDescRequest descRequest = new UploadAttachmentDescRequest();

            if (!string.IsNullOrWhiteSpace(attachmentRequest.DescKey))
            {
                IEntityScope scope = QueryHelpler.GetEntityScope(EntityTypes.AttachmentDescription, this.CurrentContext);
                var cacheDescription = _inspectionDescCache.GetObjectById<UploadAttachmentDescRequest>(scope, attachmentRequest.DescKey, true);

                if (cacheDescription == null)
                {
                    throw new MobileException(MobileResources.GetString("file_upload_failed"));
                }

                descRequest = cacheDescription;

                if (String.IsNullOrEmpty(descRequest.FileName))
                {
                    descRequest.FileName = DateTime.Now.ToString("yyyyMMdd");
                }
            }

            Attachment attachment = new Attachment();
            attachment.Description = descRequest.Desc;
            attachment.FileName = descRequest.FileName;

            GovXML govXmlIn = new GovXML();
            govXmlIn.createDocument = new CreateDocument();
            govXmlIn.createDocument.system = CommonHelper.GetSystem(attachmentRequest, this.CurrentContext);
            if (!String.IsNullOrEmpty(descRequest.InspectionId))
            {
                govXmlIn.createDocument.objectId = new ObjectId();
                govXmlIn.createDocument.objectId.keys = KeysHelper.CreateXMLKeys(descRequest.InspectionId);
                govXmlIn.createDocument.objectId.contextType = "Inspection";
            }
            govXmlIn.createDocument.document = AttachmentHelper.GetXMLDocument(attachment, stream);

            GovXML response = CommonHelper.Post(govXmlIn,
                                                govXmlIn.createDocument.system,
                                                (o) => o.createDocumentResponse == null ? null : o.createDocumentResponse.system);

            CreateAttachmentResponse result = AttachmentHelper.ToClientDocument(response.createDocumentResponse);

            return result.Identifier;
        }

        public CreateAttachmentResponse CreateAttachment(CreateAttachmentRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.createDocument = new CreateDocument();
            govXmlIn.createDocument.system = CommonHelper.GetSystem(request, this.CurrentContext);
            if (!String.IsNullOrEmpty(request.EntityId))
            {
                govXmlIn.createDocument.objectId = new ObjectId();
                govXmlIn.createDocument.objectId.keys = KeysHelper.CreateXMLKeys(request.EntityId);
                if (!String.IsNullOrEmpty(request.EntityType))
                {
                    govXmlIn.createDocument.objectId.contextType = request.EntityType;
                }
            }
            govXmlIn.createDocument.document = AttachmentHelper.GetXMLDocument(request.Attachment, request.FileContent);

            GovXML response = CommonHelper.Post(govXmlIn,
                                                govXmlIn.createDocument.system,
                                                (o) => o.createDocumentResponse == null ? null : o.createDocumentResponse.system);

            CreateAttachmentResponse result = AttachmentHelper.ToClientDocument(response.createDocumentResponse);

            return result;
        }
    }
}
