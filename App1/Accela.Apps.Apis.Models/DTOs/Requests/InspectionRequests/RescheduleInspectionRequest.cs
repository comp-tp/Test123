using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests
{
    /// <summary>
    /// RescheduleInspection request class.
    /// </summary>
    [DataContract]
    public class RescheduleInspectionRequest:RequestBase
    {
        /// <summary>
        /// Inspection id.
        /// </summary>
        //[DataMember(Name = "inspectionId")]
        //public string InspectionId
        //{
        //    get;
        //    set;
        //}
 

        /// <summary>
        /// Inspection model.
        /// </summary>
        [DataMember(Name = "inspection")]
        public InspectionModel Inspection
        {
            get;
            set;
        }
    }
}
