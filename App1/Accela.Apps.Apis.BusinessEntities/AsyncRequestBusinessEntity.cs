// -----------------------------------------------------------------------
// <copyright file="AsyncRequestBusinessEntity.cs" company="Accela.Inc">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Persistence;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Apis.Models.DomainModels.ResourceModels;
using Accela.Apps.Apis.Models.DomainModels.AsyncRequestModels;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Accela.Apps.Apis.Common;
using Accela.Infrastructure.Storage;
using Accela.Apps.Apis.Models.Common;

namespace Accela.Apps.Apis.BusinessEntities
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class AsyncRequestBusinessEntity : BusinessEntityBase, IAsyncRequestBusinessEntity
    {
        private IAsyncRequestRepository _asyncRequestRepository;
        private IBinaryStorage _binaryStorage;

        public AsyncRequestBusinessEntity(IAsyncRequestRepository asyncRequestRepository, IBinaryStorage binaryStroage)
        {
            _asyncRequestRepository = asyncRequestRepository;
            _binaryStorage = binaryStroage;
        }

        /// <summary>
        /// Cache request message.
        /// </summary>
        /// <param name="requestStatusModel">requestStatusModel</param>
        public void Add(AsyncRequestStatusModel requestStatusModel)
        {
            if(requestStatusModel == null)
            {
                throw new ArgumentNullException("requestStatusModel is null.");
            }
            else if(String.IsNullOrWhiteSpace(requestStatusModel.RequestID)
                || String.IsNullOrWhiteSpace(requestStatusModel.HttpMethod)
                || String.IsNullOrWhiteSpace(requestStatusModel.RequestUrl)
                )
            {
                throw new ArgumentException("RequestID, Status, HttpMethod and RequestUrl are requied in requestStatusModel.");
            }

            string blobUrlForRequestData = null;
            string blobUrlForResponseData = null;

            if(requestStatusModel.RequestData != null)
            {
                blobUrlForRequestData = SaveConentToBlob(requestStatusModel.RequestID, "request", requestStatusModel.RequestData);
            }

            if (requestStatusModel.ResponseData != null)
            {
                blobUrlForResponseData = SaveConentToBlob(requestStatusModel.RequestID, "response", requestStatusModel.ResponseData);
            }
         
            AsyncRequestStatus dbObj = new AsyncRequestStatus
            {
                RequestID = requestStatusModel.RequestID.ToLower(),
                RequestUrl = requestStatusModel.RequestUrl,
                HttpMethod = requestStatusModel.HttpMethod.ToUpper(),
                Status = String.IsNullOrWhiteSpace(requestStatusModel.Status) ? AsyncProcessState.Created.ToString() : requestStatusModel.Status,
                ExpirationDate = DateTime.UtcNow.AddDays(7),
                RequestDataBlobUrl = blobUrlForRequestData,
                ResponseDataBlobUrl = blobUrlForResponseData
            };

            _asyncRequestRepository.Add(dbObj);
        }

        /// <summary>
        /// Update Response Data to cache.
        /// </summary>
        /// <param name="requestId">request id.</param>
        /// <param name="responseData">response data.</param>
        /// <param name="errorDescription">error description</param>
        public void UpdateResponseData(string requestId, object responseData, string errorDescription = null)
        {
            if (String.IsNullOrWhiteSpace(requestId))
            {
                throw new ArgumentNullException("requestId");
            }

            requestId = requestId.ToLower();
            string blobUrlForResponseData = null;

            if(responseData != null)
            {
                blobUrlForResponseData = SaveConentToBlob(requestId, "response", responseData);
            }

            // db column limits to 100 vachar
            if(errorDescription != null && errorDescription.Length > 100)
            {
                errorDescription = errorDescription.Substring(0, 100);
            }
            _asyncRequestRepository.UpdateResponseData(requestId, blobUrlForResponseData, AsyncProcessState.Completed.ToString(), errorDescription);
        }

        /// <summary>
        /// Update request status to cache.
        /// </summary>
        /// <param name="requestId">request id.</param>
        /// <param name="status">proccess status.</param>
        public void UpdateRequestStatus(string requestId, AsyncProcessState status)
        {
            if (String.IsNullOrWhiteSpace(requestId))
            {
                throw new ArgumentNullException("requestId");
            }

            requestId = requestId.ToLower();


            _asyncRequestRepository.UpdateRequestStatus(requestId, status.ToString());
        }

        /// <summary>
        /// Get Async state data by request id.
        /// </summary>
        /// <param name="requestId">request id.</param>
        /// <returns>an instance of AsyncRequestStatusModel.</returns>
        public AsyncRequestStatusModel Get(string requestId)
        {
            if (String.IsNullOrWhiteSpace(requestId))
            {
                throw new ArgumentNullException("requestId");
            }

            AsyncRequestStatusModel result = null;
            requestId = requestId.ToLower();

            var dbObj = _asyncRequestRepository.Get(requestId);
            if (dbObj != null)
            {
                result = new AsyncRequestStatusModel();
                result.RequestID = dbObj.RequestID;
                result.HttpMethod = dbObj.HttpMethod;
                result.RequestUrl = dbObj.RequestUrl;
                result.Status = dbObj.Status;
                result.ExpirationDate = dbObj.ExpirationDate;

                if (result.Status == AsyncProcessState.Created.ToString() && !String.IsNullOrWhiteSpace(dbObj.RequestDataBlobUrl))
                {
                    Stream requestContent = GetContentFromBlob(dbObj.RequestDataBlobUrl);
                    if (requestContent != null && requestContent.Length > 0)
                    {
                        BinaryFormatter binForm = new BinaryFormatter();
                        AsyncHttpRequestMessage objContent = binForm.Deserialize(requestContent) as AsyncHttpRequestMessage;
                        result.RequestData = objContent;
                    }
                }
                else if (result.Status == AsyncProcessState.Completed.ToString() && result.ExpirationDate > DateTime.UtcNow && !String.IsNullOrWhiteSpace(dbObj.ResponseDataBlobUrl))
                {
                    Stream responseContent = GetContentFromBlob(dbObj.ResponseDataBlobUrl);
                    if (responseContent != null && responseContent.Length > 0)
                    {
                        BinaryFormatter binForm = new BinaryFormatter();
                        AsyncHttpResponseMessage objContent = binForm.Deserialize(responseContent) as AsyncHttpResponseMessage;
                        result.ResponseData = objContent;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Save request/response content to storage.
        /// </summary>
        /// <param name="requestId">request id.</param>
        /// <param name="contentType">request/respose</param>
        /// <param name="content">conent to be stored.</param>
        /// <returns>Full blob url with container.</returns>
        private string SaveConentToBlob(string requestId,string contentType, object content)
        {
            try
            {
                string[] containerNameSegents = requestId.Split('-');

                if (containerNameSegents.Length != 2 || String.IsNullOrWhiteSpace(containerNameSegents[1]))
                {
                    throw new Exception("Invalid request id.");
                }

                if(content == null)
                {
                    return null;
                }

                Stream contentStream = null;

                if (content is Stream)
                {
                    contentStream = content as Stream;
                    contentStream.Position = 0;
                }
                else
                {
                    contentStream = new MemoryStream();
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(contentStream, content);
                    //contentStream.Position = 0;
                }

                //use asynccaches-yyyyMMdd as container name
                string container = (CacheConstants.API_TEMPDATA_CONTAINER_PREFIX + containerNameSegents[1]).ToLower();
                string blobName = String.Format("{0}_{1}", requestId, contentType);

                _binaryStorage.CreateNewOrUpdate(container, blobName, contentStream);

                string fileName = String.Format("{0}/{1}", container, blobName);
                return fileName;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw ex;
            }
        }

        /// <summary>
        /// Get content from storage.
        /// </summary>
        /// <param name="blobNameWithContainer">blob name with container name.</param>
        /// <returns>blob content.</returns>
        private Stream GetContentFromBlob(string blobNameWithContainer)
        {
            blobNameWithContainer = blobNameWithContainer.ToLower();

            string[] containerNameSegents = blobNameWithContainer.Split('/');

            if (containerNameSegents.Length != 2 ||  String.IsNullOrWhiteSpace(containerNameSegents[0]) || String.IsNullOrWhiteSpace(containerNameSegents[1]))
            {
                throw new ArgumentException("blobNameWithContainer");
            }

            string container = containerNameSegents[0];
            string blobName = containerNameSegents[1];
            //BlobHelper blobHelper = new BlobHelper(ConnectionStrings.ApiStorageSettingName);
            //var exist = blobHelper.CheckBlobExist(container, blobName);
            //if (!exist)
            //{
            //    throw new Exception("The cache item can't be found from storage.");
            //}

            //var fileStream = blobHelper.DownloadFromStream(container, blobName, true);

            return _binaryStorage.ReadAsStream(container, blobName);
        }
    }
}
