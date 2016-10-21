using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.AssessmentResponses
{
    public class UpdateAssetCAResponse : ResponseBase
    {
        public AssetCAModel AssetCAModel { get; set; }
    }
}
