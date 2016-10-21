using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests
{
    /// <summary>
    /// Inspection request class.
    /// </summary>
    [DataContract]
    public class InspectionRequest : PageListRequest
    {
        /// <summary>
        /// Inspection id.
        /// </summary>
        public string InspectionId
        {
            get;
            set;
        }

        /// <summary>
        /// Inspection model.
        /// </summary>
        public InspectionModel InspectionModel
        {
            get;
            set;
        }
    }
}
