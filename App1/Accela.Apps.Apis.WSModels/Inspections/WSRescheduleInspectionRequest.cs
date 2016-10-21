using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;

namespace Accela.Apps.Apis.WSModels.Inspections
{
   [DataContract(Name = "rescheduleInspectionRequest")]
    public class WSRescheduleInspectionRequest : WSRequestBase
   {
       /// <summary>
       /// Gets or sets the inspection
       /// </summary>
       /// <value>
       /// Ths inspection.
       /// </value>
       [DataMember(Name = "rescheduleInspection",EmitDefaultValue = false)]
       public WSRescheduleInspection Inspection
       {
           get;
           set;
       }

       /// <summary>
       /// Toes the entity models.
       /// </summary>
       /// <param name="wsModel">The ws model.</param>
       /// <returns>the entity models.</returns>
       public static RescheduleInspectionRequest ToEntityModels(WSRescheduleInspectionRequest wsModel)
       {
           if (wsModel == null)
           {
               return null;
           }

           var result = new RescheduleInspectionRequest()
           {
              Inspection =  WSRescheduleInspection.ToEntityModel(wsModel.Inspection),
           };

           return result;
       }
   }
}
