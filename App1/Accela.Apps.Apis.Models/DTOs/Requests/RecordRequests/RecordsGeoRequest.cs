using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests
{
    public class RecordsGeoRequest : PageListRequest
    {
        public Guid CivicId { get; set; }

        public BBox BBoxValue { get; set; }

        public GeoCircle GeoCircle { get; set; }

        public string Environment { get; set; }
    }
}
