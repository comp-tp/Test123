using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name = "assetSearchRequest")]
    public class WSAssetsSearchRequest : WSRequestBase
    {
        [DataMember(Name = "filter", EmitDefaultValue = false)]
        public WSAssetFitlter AssetFilter { get; set; }
    }
}
