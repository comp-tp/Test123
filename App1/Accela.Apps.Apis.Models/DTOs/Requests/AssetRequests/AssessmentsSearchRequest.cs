using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests
{
    public class AssessmentsSearchRequest : PageListRequest
    {
        public string AssessmentId { get; set; }

        public string AssessmentTypeId { get; set; }

        public string AssessmentStatusId { get; set; }

        public string AssetId { get; set; }

        public string AssetTypeId { get; set; }

        public string AssetName { get; set; }

        public string ScheduledDateFrom { get; set; }

        public string ScheduledDateTo { get; set; }

        public string InspectionDateFrom { get; set; }

        public string InspectionDateTo { get; set; }

        public string AssetIdDisplay { get; set; }

        public string DepartmentId { get; set; }

        public string InspectorId { get; set; }
    }
}
