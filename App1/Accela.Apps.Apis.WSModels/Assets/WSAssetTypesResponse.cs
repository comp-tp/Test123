using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract]
    public class WSAssetTypesResponse : WSPagedResponse
    {
        [DataMember(Name = "types", EmitDefaultValue = false)]
        public List<WSAssetType> Types { get; set; }

        public static WSAssetTypesResponse FromEntityModel(AssetTypesResponse entityResponse)
        {
            WSAssetTypesResponse response = new WSAssetTypesResponse
            {
                PageInfo = WSPagination.FromEntityModel(entityResponse.PageInfo)
            };

            response.Types = new List<WSAssetType>();

            if (entityResponse.Types != null
                && entityResponse.Types.Count > 0)
            {
                entityResponse.Types.ForEach(model => response.Types.Add(WSAssetType.FromEntityModel(model)));
            }

            return response;
        }
    }
}
