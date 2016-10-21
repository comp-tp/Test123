
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
namespace Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests
{
    public class DrillDownValuesRequest : RequestBase
    {
        public string RecordId { get; set; }

        public string DrillDownId { get; set; }

        public string ParentValueId { get; set; }
    }
}
