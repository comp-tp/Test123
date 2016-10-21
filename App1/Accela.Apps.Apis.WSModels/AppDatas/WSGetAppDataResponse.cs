using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AppDataResponses;

namespace Accela.Apps.Apis.WSModels.AppDatas
{
    [DataContract]
    public class WSGetAppDataResponse : WSResponseBase
    {
        [DataMember(Name = "appData")]
        public string AppData { get; set; }

        public static WSGetAppDataResponse FromEntityModel(GetAppDataResponse appDataResponse)
        {
            return new WSGetAppDataResponse()
            {
                AppData = appDataResponse.AppData
            };
        }
    }
}
