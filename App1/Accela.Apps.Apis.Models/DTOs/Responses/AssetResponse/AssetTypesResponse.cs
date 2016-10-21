using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse
{
    [DataContract(Name = "AssetTypesResponse")]
    public class AssetTypesResponse : PagedResponse
    {
        [DataMember(Name = "types", EmitDefaultValue = false)]
        public List<AssetTypeModel> Types { get; set; }
    }
}
