using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests
{
    [DataContract]
    public class CreateAssetRequest : RequestBase
    {
        [DataMember(Name = "asset", EmitDefaultValue = false)]
        public AssetModel Asset { get; set; } 
    }
}
