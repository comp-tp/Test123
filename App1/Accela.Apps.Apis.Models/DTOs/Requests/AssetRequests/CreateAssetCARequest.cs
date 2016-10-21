using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests
{
    public class CreateAssetCARequest : RequestBase
    {
        public AssetCAModel AssetCAModel { get; set; }
    }
}
