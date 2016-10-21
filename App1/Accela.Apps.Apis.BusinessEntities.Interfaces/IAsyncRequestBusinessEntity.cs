using Accela.Apps.Apis.Models.DomainModels.AsyncRequestModels;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IAsyncRequestBusinessEntity : IBusinessEntity
    {
        /// <summary>
        ///     Cache request message.
        /// </summary>
        /// <param name="requestStatusModel">requestStatusModel</param>
        void Add(AsyncRequestStatusModel requestStatusModel);


        /// <summary>
        ///     Update Response Data to cache.
        /// </summary>
        /// <param name="requestId">request id.</param>
        /// <param name="responseData">response data.</param>
        /// <param name="errorDescription">error description</param>
        void UpdateResponseData(string requestId, object responseData, string errorDescription = null);

        /// <summary>
        ///     Update request status to cache.
        /// </summary>
        /// <param name="requestId">request id.</param>
        /// <param name="status">proccess status.</param>
        void UpdateRequestStatus(string requestId, AsyncProcessState status);

        /// <summary>
        ///     Get Async state data by request id.
        /// </summary>
        /// <param name="requestId">request id.</param>
        /// <returns>an instance of AsyncRequestStatusModel.</returns>
        AsyncRequestStatusModel Get(string requestId);
    }
}