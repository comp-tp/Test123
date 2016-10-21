using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.AppDataRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AppDataResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.AppDatas;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.WSModels;

using System.Web.Http;
using System.Web;
using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/appdata")]
    [APIControllerInfoAttribute(Name = "App Data", Group = "App", Order=2, Description = "The following APIs are exposed to app data.")]
    public class AppDataController : ControllerBase
    {
        const string ACCELA_APP_ID_ALIAS = "comaccelainspector";
        const string ACCELA_APP_ID = "com.accela.inspector";
        
        private readonly IAppDataBusinessEntity appDataBusinessEntity;
        private readonly IRecordBusinessEntity recordBusinessEntity;
        private readonly IAgencyAppContext agencyContext;

        /// <summary>
        /// App data service constructor.
        /// </summary>
        public AppDataController(IAppDataBusinessEntity appDataBusinessEntity, IRecordBusinessEntity recordBusinessEntity, IAgencyAppContext agencyContext)
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
        [APIActionInfoAttribute(Name = "Get App Data", Scope = "get_app_data", Order = 1, Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves app data matching the container and blob name. The two parameters are defined by the invoker (an app) and must be unique.")]
        public WSGetAppDataResponse GetAppData(string container, string blobName, string appId, string appSecret, string lang=null)
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

            return WSGetAppDataResponse.FromEntityModel(RecordsResponse);
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
        [APIActionInfoAttribute(Name = "Save App Data", Scope = "update_app_data", Order = 2, Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Stores app data in the Cloud based on the container and blob name. If the two parameters exist in the Cloud already, the API will override them; otherwise, the API will create them in the Cloud. The two parameters are defined by the invoker (an app) and must be unique.")]
        public GenericResultResponse<bool> SaveAppData(string container, string blobName, string appid, string appSecret, [FromBody]WSSaveAppDataRequest wsCreateAppDataRequest, string lang = null)
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

            return new GenericResultResponse<bool>()
            {
                Result = RecordsResponse.IsSaveSuccess
            };
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
        [APIActionInfoAttribute(Name = "Delete App Data", Scope = "delete_app_data", Order = 3, Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Deletes app data based on the container and blob name. No error will be returned if neither of the parameters exists in the Cloud.")]
        public GenericResultResponse<bool> DeleteAppData(string container, string blobName, string appid, string appSecret, string lang = null)
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
            return new GenericResultResponse<bool>()
            {
                Result = RecordsResponse.IsDeleteSuccess
            };
        }
        
    }
}
