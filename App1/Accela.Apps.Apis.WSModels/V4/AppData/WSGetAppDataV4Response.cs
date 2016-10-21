using System.Net;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AppDataResponses;

namespace Accela.Apps.Apis.WSModels.V4.AppDatas
{
    [DataContract]
    public class WSGetAppDataV4Response : WSResponseBase
    {
        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "result")]
        public string AppData { get; set; }

        public static WSGetAppDataV4Response FromEntityModel(GetAppDataResponse appDataResponse)
        {
            /*
             * In current implementation, the value of AppData variable of appDataResponse object is what it is, if found; otherwise, it is a empty string.
             * So, we always return 200 status.
             */ 
            return new WSGetAppDataV4Response()
            {
                Status = (int)HttpStatusCode.OK,
                AppData = appDataResponse.AppData
            };
        }
    }
}
