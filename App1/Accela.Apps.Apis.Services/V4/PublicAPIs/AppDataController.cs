using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.AppDataRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AppDataResponses;
using Accela.Apps.Apis.WSModels.V4.AppDatas;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.WSModels;

using System.Web.Http;
using System.Web;
using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v4/appdata")]
    public class AppDataV4Controller : ControllerBase
    {
        const string ACCELA_APP_ID_ALIAS = "comaccelainspector";
        const string ACCELA_APP_ID = "com.accela.inspector";


        //private IAppDataBusinessEntity _appDataBusinessEntity = null;
        private readonly IAppDataBusinessEntity appDataBusinessEntity;

        //private IRecordBusinessEntity _recordBusinessEntity = null;
        private readonly IRecordBusinessEntity recordBusinessEntity;

        private readonly IAgencyAppContext agencyContext;

        /// <summary>
        /// App data service constructor.
        /// </summary>
        public AppDataV4Controller(IAppDataBusinessEntity appDataBusinessEntity, IRecordBusinessEntity recordBusinessEntity, IAgencyAppContext agencyContext)
        {
            this.appDataBusinessEntity = appDataBusinessEntity;
            this.recordBusinessEntity = recordBusinessEntity;
            this.agencyContext = agencyContext;
        }

        /// <summary>
        /// Get app data.
        /// </summary>
        /// <param name="lang">Lang.</param>
        /// <param name="container">Container.</param>
        /// <param name="blobName">Blob name.</param>
        /// <param name="appId">App id.</param>
        /// <param name="appSecret">App Secret.</param>
        /// <returns>App data response.</returns>
        [HttpGet]
        [Route("{container}/{blobname}")]
        public GenericResultResponse<string> GetAppData(string container, string blobName, string appId, string appSecret, string lang = null)
        {
            var appDataRequest = new GetAppDataRequest();
            appDataRequest.UserId = agencyContext.App;

            // Azure blob storage does not allow the name of container contains a dot mark ('.').
            // The app id of Inspector App does contain one.
            // So we have to change it to something.
            // We simply remove it since there is no special meaning about the naming.
            if (appDataRequest.UserId.ToLowerInvariant() == ACCELA_APP_ID)
            {
                appDataRequest.UserId = ACCELA_APP_ID_ALIAS;
            }

            appDataRequest.BlobName = HttpUtility.UrlDecode(blobName);
            appDataRequest.Container = container;

            var RecordsResponse = this.ExcuteV1_2<GetAppDataResponse, GetAppDataRequest>(
                                    (o) =>
                                    {
                                        return appDataBusinessEntity.GetAppData(o);
                                    },
                                    appDataRequest);

            return new GenericResultResponse<string>()
            {
                Result = RecordsResponse.AppData
            };
        }

        /// <summary>
        /// Create app data.
        /// </summary>
        /// <param name="lang">Lang.</param>
        /// <param name="container">Container.</param>
        /// <param name="blobName">Blob name.</param>
        /// <param name="appid">App id.</param>
        /// <param name="appSecret">App Secret.</param>
        /// <param name="wsCreateAppDataRequest">Create app data request.</param>
        /// <returns>Create app data response.</returns>
        [HttpPut]
        [Route("{container}/{blobname}")]
        public GenericResultResponse<string> SaveAppData(string container, string blobName, string appid, string appSecret, [FromBody]WSSaveAppDataV4Request wsCreateAppDataRequest, string lang = null)
        {
            var createAppDataRequest = new SaveAppDataRequest();
            createAppDataRequest.UserId = agencyContext.App;

            // Azure blob storage does not allow the name of container contains a dot mark ('.').
            // The app id of Inspector App does contain one.
            // So we have to change it to something.
            // We simply remove it since there is no special meaning about the naming.
            if (createAppDataRequest.UserId.ToLowerInvariant() == ACCELA_APP_ID)
            {
                createAppDataRequest.UserId = ACCELA_APP_ID_ALIAS;
            }

            createAppDataRequest.Container = container;
            createAppDataRequest.BlobName = HttpUtility.UrlDecode(blobName);
            createAppDataRequest.AppData = wsCreateAppDataRequest.AppData;

            var RecordsResponse = this.ExcuteV1_2<SaveAppDataResponse, SaveAppDataRequest>(
                                    (o) =>
                                    {
                                        return appDataBusinessEntity.SaveAppData(o);
                                    },
                                    createAppDataRequest);

            return new GenericResultResponse<string>();
        }

        /// <summary>
        /// Delete app data.
        /// </summary>
        /// <param name="lang">Lang.</param>
        /// <param name="container">Container.</param>
        /// <param name="blobName">Blob name.</param>
        /// <param name="appid">App id.</param>
        /// <param name="appSecret">App Secret.</param>
        /// <returns>Delete app data response.</returns>
        [HttpDelete]
        [Route("{container}/{blobname}")]
        public GenericResultResponse<string> DeleteAppData(string container, string blobName, string appid, string appSecret, string lang = null)
        {
            var deleteAppDataRequest = new DeleteAppDataRequest();
            deleteAppDataRequest.UserId = agencyContext.App;

            // Azure blob storage does not allow the name of container contains a dot mark ('.').
            // The app id of Inspector App does contain one.
            // So we have to change it to something.
            // We simply remove it since there is no special meaning about the naming.
            if (deleteAppDataRequest.UserId.ToLowerInvariant() == ACCELA_APP_ID)
            {
                deleteAppDataRequest.UserId = ACCELA_APP_ID_ALIAS;
            }

            deleteAppDataRequest.Container = container;
            deleteAppDataRequest.BlobName = HttpUtility.UrlDecode(blobName);

            var RecordsResponse = this.ExcuteV1_2<DeleteAppDataResponse, DeleteAppDataRequest>(
                                    (o) =>
                                    {
                                        return appDataBusinessEntity.DeleteAppData(o);
                                    },
                                    deleteAppDataRequest);

            return new GenericResultResponse<string>();
        }
    }
}
