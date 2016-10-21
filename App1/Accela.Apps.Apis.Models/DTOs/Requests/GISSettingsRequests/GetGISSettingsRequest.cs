using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.GISSettingsRequests
{
    [DataContract]
    public class GetGISSettingsRequest : RequestBase
    {
        [DataMember(Name = "appId")]
        public string AppId { get; set; }

        [DataMember(Name = "agencyId")]
        public string AgencyName { get; set; }
    }
}
