using System;
using System.Linq;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.AppSettings;
using Accela.Apps.Shared;

using System.Web.Http;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/appsettings")]
    [APIControllerInfoAttribute(Name = "App Settings", Group = "App", Order = 3, Description = "The following API is exposed to app settings.")]
    public class AppSettingsController : ControllerBase
    {
        private IAppSettingsBusinessEntity _settingsBusinessEntity;
        private IAgencyAppContext _context;

        public AppSettingsController(IAppSettingsBusinessEntity settingsBusinessEntity, IAgencyAppContext context)
        {
            _settingsBusinessEntity = settingsBusinessEntity; //IocContainer.Resolve<IAppSettingsBusinessEntity>();
            _context = context;
        }

        private string DecodeParam(string str)
        {
            return System.Web.HttpUtility.UrlDecode(str);
        }

        /// <summary>
        /// Get app settings.
        /// </summary>
        /// <param name="keys">The keys are used to retrive app setting values. Uses comma to seperate the keys.</param>
        /// <param name="agency">Optional. If passed agency, returns agency customized app settings value.</param>
        /// <param name="appId">App Id.</param>
        /// <param name="appSecret">App Secret.</param>
        /// <returns>App setting list with key and value.</returns>
        [Route("")]
        [APIActionInfoAttribute(Name = "Get App Settings", Scope = "get_app_settings", Applicability = APIActionInfoAttribute.APPLICABILITY_BOTH, Description = "Retrieves app settings matching the array of comma delimited setting keys, if any; otherwise, all settings will be returned.")]
        public WSAppSettingsResponse GetApplicationSettings(string keys = null, string agency = null, string appId = null, string appSecret = null)
        {
            AppSettingsRequest request = new AppSettingsRequest();

            request.AppId = _context.App;
            request.Agency = agency;

            if (!String.IsNullOrWhiteSpace(keys))
            {
                request.SettingKeys = DecodeParam(keys.TrimEnd(',')).Split(',').ToList<string>();
            }

            var entityResponse = this.ExcuteV1_2<AppSettingsResponse, AppSettingsRequest>(
                                    (o) =>
                                    {
                                        return _settingsBusinessEntity.GetAppSettings(o);
                                    },
                                    request);

            return WSAppSettingsResponse.FromEntityModel(entityResponse);
        }
    }
}
