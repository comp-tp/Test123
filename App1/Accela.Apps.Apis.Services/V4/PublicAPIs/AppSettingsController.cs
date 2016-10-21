using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;
using Accela.Apps.Apis.WSModels.V4.AppSettings;
using Accela.Apps.Shared.Contexts;

using System.Web.Http;
using System;
using System.Linq;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v4/appsettings")]
    public class AppSettingsV4Controller : ControllerBase
    {
        private IAppSettingsBusinessEntity _settingsBusinessEntity;
        private readonly IAgencyAppContext agencyContext;

        public AppSettingsV4Controller(IAppSettingsBusinessEntity settingsBusinessEntity, IAgencyAppContext agencyContext)
        {
            _settingsBusinessEntity = settingsBusinessEntity;  //IocContainer.Resolve<IAppSettingsBusinessEntity>();
            this.agencyContext = agencyContext;
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
        public WSAppSettingsV4Response GetApplicationSettings(string keys = null, string agency = null, string appId = null, string appSecret = null)
        {
            AppSettingsRequest request = new AppSettingsRequest();

            request.AppId = agencyContext.App;
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

            return WSAppSettingsV4Response.FromEntityModel(entityResponse);
        }
    }
}
