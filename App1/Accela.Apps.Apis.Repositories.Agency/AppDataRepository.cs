using System;
using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Apis.Models.DTOs.Requests.AppDataRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AppDataResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Common;
using Accela.Apps.Shared;
using Accela.Infrastructure.Storage;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.Repositories.Agency
{
    /// <summary>
    /// App data repository class.
    /// </summary>
    public class AppDataRepository : RepositoryBase, IAppDataRepository
    {
        IBinaryStorage _storage = null;
        public AppDataRepository(IBinaryStorage storage)
            : base() {
                _storage = storage;
        }

        /// <summary>
        /// Get app data.
        /// </summary>
        /// <param name="getAppDataRequest">GetAppDataRequest.</param>
        /// <returns>Get app data response.</returns>
        public GetAppDataResponse GetAppData(GetAppDataRequest getAppDataRequest)
        {
            try
            {
                var containerName = getAppDataRequest.UserId;
                var blobName = getAppDataRequest.Container + @"/" + getAppDataRequest.BlobName;

                var data =_storage.ReadAsString(containerName, blobName);

                return new GetAppDataResponse()
                {
                    AppData = data
                };
            }
            catch
            {
                return new GetAppDataResponse()
                {
                    AppData = string.Empty
                };
            }
        }

        /// <summary>
        /// Save app data.
        /// </summary>
        /// <param name="saveAppDataRequest">Save app data request</param>
        /// <returns>Save app data response.</returns>
        public SaveAppDataResponse SaveAppData(SaveAppDataRequest saveAppDataRequest)
        {
            try
            {
                var containerName = saveAppDataRequest.UserId;
                var blobName = saveAppDataRequest.Container + @"/" + saveAppDataRequest.BlobName;
                var realBlobName = string.Format("{0}/{1}", containerName, blobName);

                _storage.CreateNewOrUpdate(containerName, blobName, new MemoryStream(Encoding.UTF8.GetBytes(saveAppDataRequest.AppData)));

                return new SaveAppDataResponse
                {
                    IsSaveSuccess = true 
                };

            }
            catch (Exception err)
            {
                return new SaveAppDataResponse()
                {
                    IsSaveSuccess = false,
                    Error = new ErrorMessage()
                    {
                        Message = err.Message,
                        ErrorCode = "500"
                    }
                };
            }
        }

        /// <summary>
        /// Delete app data.
        /// </summary>
        /// <param name="deleteAppDataRequest">Delete app data request.</param>
        /// <returns>Delete app data response.</returns>
        public DeleteAppDataResponse DeleteAppData(DeleteAppDataRequest deleteAppDataRequest)
        {
            try
            {
                var containerName = deleteAppDataRequest.UserId;
                var blobName = deleteAppDataRequest.Container + @"/" + deleteAppDataRequest.BlobName;
       
                _storage.DeleteIfExists(containerName, blobName);

                return new DeleteAppDataResponse()
                {
                    IsDeleteSuccess = true
                };
            }
            catch (Exception err)
            {
                return new DeleteAppDataResponse()
                {
                    IsDeleteSuccess = false,
                    Error = new ErrorMessage()
                    {
                        Message = err.Message,
                        ErrorCode = "500"
                    }
                };
            }
        }
    }
}
