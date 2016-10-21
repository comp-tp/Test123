using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.AssetModels
{
    public class CAAssetModel : IdentifierBase
    {        
        public AssetTypeModel Type { get; set; }
        
        public AssetDescriptionModel Description { get; set; }
        
        public string Name { get; set; }
    }
}
