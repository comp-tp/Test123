using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.ASIs;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name = "getAssetAttributeTablesResponse")]
    public class WSGetAssetAttributeTablesResponse : WSResponseBase
    {
        [DataMember(Name = "attributeTables", EmitDefaultValue = false)]
        public List<WSASIT> AttributeTables { get; set; }

        public static WSGetAssetAttributeTablesResponse FromEntityModel(AssetResponse getAssetResponse)
        {
            var wsGetAssetAttributeTableResponse = new WSGetAssetAttributeTablesResponse();            

            if (getAssetResponse != null && getAssetResponse.Asset != null)
            {
                wsGetAssetAttributeTableResponse.AttributeTables = WSASITResponse.GetASITModel(getAssetResponse.Asset.AdditionalTables);
            }

            return wsGetAssetAttributeTableResponse;
        }
    }
}
