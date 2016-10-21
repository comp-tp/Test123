using Accela.Apps.Apis.Persistence;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IAsyncRequestRepository : IRepository
    {
        /// <summary>
        ///     Add AsyncRequestStatus to DB.
        /// </summary>
        /// <param name="asyncRequestStatus">asyncRequestStatus</param>
        void Add(AsyncRequestStatus asyncRequestStatus);

        /// <summary>
        ///     Update response data.
        /// </summary>
        /// <param name="requestId">requestId.</param>
        /// <param name="responseDataBlobUrl">responseDataBlobUrl to be updated.</param>
        /// <param name="status">process status</param>
        /// <param name="errorDescription">error description</param>
        void UpdateResponseData(string requestId, string responseDataBlobUrl, string status,
            string errorDescription = null);

        /// <summary>
        ///     Update request status.
        /// </summary>
        /// <param name="requestId">request id.</param>
        /// <param name="status">proccess status.</param>
        void UpdateRequestStatus(string requestId, string status);

        /// <summary>
        ///     Get AsyncRequestStatus by request id.
        /// </summary>
        /// <param name="requestId">reques id.</param>
        /// <returns>an instance of AsyncRequestStatus.</returns>
        AsyncRequestStatus Get(string requestId);
    }
}