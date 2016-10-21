using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse
{
    public class GetAssetCAsResponse : PagedResponse
    {
        public List<AssetCAModel> AssetCAModels { get; set; }
    }
}
