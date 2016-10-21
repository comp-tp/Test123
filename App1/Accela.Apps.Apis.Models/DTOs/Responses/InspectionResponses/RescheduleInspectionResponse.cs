using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses
{
    /// <summary>
    /// Resinspection response
    /// </summary>
   [DataContract(Name = "rescheduleInspectionsResponse")]
    public class RescheduleInspectionResponse : ResponseBase
   {
       /// <summary>
       /// Gets or sets the reinspection.
       /// </summary>
       /// <value>
       /// The reinspection.
       /// </value> 
       [DataMember(Name = "reinspection")]
       public InspectionModel Inspection
       {
           get;
           set;
       }

       /// <summary>
       /// Gets or sets the configuationNumber
       /// </summary>
       /// <value>
       /// The reinspection
       /// </value>
       [DataMember(Name = "configuationNumber")]
       public string ConfiguationNumber
       {
           get;
           set;
       }
   }
}
