using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses
{
    [DataContract(Name = "getRecordAssetsResponse")]
    public class RecordAssetsResponse : PagedResponse
    {
        /// <summary>
        /// The record assets.
        /// </summary>
        [DataMember(Name = "assets", EmitDefaultValue = false)]
        public List<AssetModel> Assets { get; set; }
    }
}
