using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse
{
    [DataContract(Name = "GetAssetStatusesResponse")]
    public class AssetStatusesResponse : ResponseBase
    {
        [DataMember(Name = "statuses", EmitDefaultValue = false)]
        public List<AssetStatusModel> Statuses { get; set; }
    }
}
