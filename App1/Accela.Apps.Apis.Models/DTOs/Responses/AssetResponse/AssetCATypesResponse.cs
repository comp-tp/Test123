using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse
{
    [DataContract(Name = "AssetCATypesResponse")]
    public class AssetCATypesResponse:ResponseBase
    {
        [DataMember(Name = "assetCATypes", EmitDefaultValue = false)]
        public List<AssetCATypeModel> AssetCATypes { get; set; }
    }
}
