using Accela.Apps.Apis.Common;
using Accela.Apps.Apis.Persistence;
using Accela.Apps.Apis.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Repositories
{
    public class AsyncRequestRepository : RepositoryBase, IAsyncRequestRepository
    {
        /// <summary>
        /// Add AsyncRequestStatus to DB.
        /// </summary>
        /// <param name="asyncRequestStatus">asyncRequestStatus</param>
        public void Add(AsyncRequestStatus asyncRequestStatus)
        {
            if(asyncRequestStatus == null)
            {
                throw new ArgumentNullException("asyncRequestStats");
            }

            asyncRequestStatus.CreatedDate = DateTime.UtcNow;

            using (var dbContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    dbContext.AsyncRequestStatuses.Add(asyncRequestStatus);
                });

                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Update response data.
        /// </summary>
        /// <param name="requestId">requestId.</param>
        /// <param name="responseDataBlobUrl">responseDataBlobUrl.</param>
        /// <param name="status">process status</param>
        /// <param name="errorDescription">error description</param>
        public void UpdateResponseData(string requestId, string responseDataBlobUrl,string status,string errorDescription = null)
        {
            if (String.IsNullOrWhiteSpace(requestId))
            {
                throw new ArgumentNullException("requestId");
            }

            using (var dbContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    var updatedObj = dbContext.AsyncRequestStatuses.FirstOrDefault(o => o.RequestID == requestId);

                    if (responseDataBlobUrl != null)
                    {
                        updatedObj.ResponseDataBlobUrl = responseDataBlobUrl;
                    }

                    updatedObj.Status = status;

                    if (!String.IsNullOrEmpty(errorDescription))
                    {
                        updatedObj.Description = errorDescription;
                    }

                    updatedObj.LastUpdatedDate = DateTime.UtcNow;
                });

                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Update request status to cache.
        /// </summary>
        /// <param name="requestId">request id.</param>
        /// <param name="status">proccess status.</param>
        public void UpdateRequestStatus(string requestId, string status)
        {
            if (String.IsNullOrWhiteSpace(requestId))
            {
                throw new ArgumentNullException("requestId");
            }

            using (var dbContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    var updatedObj = dbContext.AsyncRequestStatuses.FirstOrDefault(o => o.RequestID == requestId);
                    updatedObj.Status = status;
                    updatedObj.LastUpdatedDate = DateTime.UtcNow;
                });

                dbContext.SaveChanges();
            }
        }

        /// <summary>
        /// Get AsyncRequestStatus by request id.
        /// </summary>
        /// <param name="requestId">reques id.</param>
        /// <returns>an instance of AsyncRequestStatus.</returns>
        public AsyncRequestStatus Get(string requestId)
        {
            if (String.IsNullOrWhiteSpace(requestId))
            {
                throw new ArgumentNullException("requestId");
            }

            AsyncRequestStatus selectObj = null;
            using (var dbContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                SqlRetryPolicy.ExecuteAction(() =>
                {
                    selectObj = dbContext.AsyncRequestStatuses.FirstOrDefault(o => o.RequestID == requestId);
                });
            }

            return selectObj;
        }
    }
}
