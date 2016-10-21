using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;

namespace Accela.Apps.Apis.WSModels.V4.AppSettings
{
    [DataContract]
    public class WSAppSettingsV4Response : WSResponseBase
    {
        [DataMember(Name = "result", EmitDefaultValue = false)]
        public List<WSAppSettingV4> Settings { get; set; }

        public static WSAppSettingsV4Response FromEntityModel(AppSettingsResponse entityResponse)
        {
            WSAppSettingsV4Response response = new WSAppSettingsV4Response
            {
            };

            response.Settings = new List<WSAppSettingV4>();

            if (entityResponse.SettingValues != null
                && entityResponse.SettingValues.Keys != null
                && entityResponse.SettingValues.Keys.Count > 0)
            {
                foreach (var key in entityResponse.SettingValues.Keys)
                {
                    response.Settings.Add(new WSAppSettingV4
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
