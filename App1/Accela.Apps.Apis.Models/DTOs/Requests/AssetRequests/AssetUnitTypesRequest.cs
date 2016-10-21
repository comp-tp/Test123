using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests
{
    public class AssetUnitTypesRequest : PageListRequest
    {
        /// <summary>
        /// related id
        /// </summary>
        public string RelatedId { get; set; }
    }
}
