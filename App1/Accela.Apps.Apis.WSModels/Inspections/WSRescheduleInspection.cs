using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "rescheduleInspection")]
    public class WSRescheduleInspection : WSInspectionBase
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }
         
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; } 

        [DataMember(Name = "autoAssign", EmitDefaultValue = false)]
        public bool AutoAssign { get; set; }
          
        /// <summary>
        /// Gets or sets Inspection Type
        /// </summary>
        [DataMember(Name = "inspectionTypeId", EmitDefaultValue = false)]
        public string InspectionTypeId { get; set; }

        /// <summary>
        /// Check list for the inspection
        /// </summary>
        [DataMember(Name = "checklists", EmitDefaultValue = false)]
        public List<WSScheduleChecklist> Checklists { get; set; }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The web service models.</param>
        /// <returns>the entity models.</returns>
        public static List<InspectionModel> ToEntityModels(List<WSRescheduleInspection> wsModels)
        {
            if (wsModels == null)
            {
                return null;
            }

            var result = wsModels.Select(m => ToEntityModel(m)).ToList();
            return result;
        }

        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">The web service model.</param>
        /// <returns>The entity model.</returns>
        public static InspectionModel ToEntityModel(WSRescheduleInspection wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            wsModel.Latitude = wsModel.AutoCaptureGPSLatitude;
            wsModel.Longitude = wsModel.AutoCaptureGPSLongitude;

            var result = new InspectionModel()
            {
                Identifier = wsModel.Id,
                SequenceNumber = wsModel.SequenceNumber,
                //ContextType = "Rescheduled",
                Type = new InspectionTypeModel()
                {
                    Identifier = wsModel.InspectionTypeId
                }, 
                AutoAssign = wsModel.AutoAssign,
                ScheduleDate = wsModel.ScheduleDate,
                ScheduleTime = wsModel.ScheduleTime,
                ScheduleNotes = wsModel.ScheduleNotes,
                Address = wsModel.Address,
                Department = wsModel.Department,
                Inspector = WSInspector.ToEntityModel(wsModel.Inspector),
                InspectionUnit = wsModel.InspectionUnit,
                RequestorPhoneNumber = wsModel.RequestorPhoneNumber,
                ContactName = wsModel.ContactName,
                ContactFirstName = wsModel.ContactFirstName,
                ContactMiddleName = wsModel.ContactMiddleName,
                ContactLastName = wsModel.ContactLastName,
                ContactPhoneNumber = wsModel.ContactPhoneNumber,
                LicensedProfessional = wsModel.LicensedProfessional,
                Latitude = wsModel.Latitude,
                Longitude = wsModel.Longitude,
                Checklists = WSScheduleChecklist.ToEntityModels(wsModel.Checklists),
                Comments = WSInspectionComment.ToEntityModels(wsModel.Comments)
            };

            if (wsModel.AutoAssign)
            {
                result.ScheduleDate = string.Empty;
                result.ScheduleTime = string.Empty;
                result.Inspector = null;
            }

            return result;
        }
    }
}
