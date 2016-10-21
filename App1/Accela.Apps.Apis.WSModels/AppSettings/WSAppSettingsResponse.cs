using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;

namespace Accela.Apps.Apis.WSModels.AppSettings
{
    [DataContract]
    public class WSAppSettingsResponse : WSResponseBase
    {
        [DataMember(Name = "settings", EmitDefaultValue = false)]
        public List<WSAppSetting> Settings { get; set; }

        public static WSAppSettingsResponse FromEntityModel(AppSettingsResponse entityResponse)
        {
            WSAppSettingsResponse response = new WSAppSettingsResponse
            {
            };

            response.Settings = new List<WSAppSetting>();

            if (entityResponse.SettingValues != null
                && entityResponse.SettingValues.Keys != null
                && entityResponse.SettingValues.Keys.Count > 0)
            {
                foreach (var key in entityResponse.SettingValues.Keys)
                {
                    response.Settings.Add(new WSAppSetting
                    {
                        Key = key,
                        Value = entityResponse.SettingValues[key]
                    });
                }
            }

            return response;
        }
    }
}
