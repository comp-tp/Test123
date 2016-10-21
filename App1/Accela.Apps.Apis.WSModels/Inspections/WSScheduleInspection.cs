using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "scheduleInspection")]
    public class WSScheduleInspection : WSInspectionBase
    {
        /// <summary>
        /// Gets or sets Inspection Type
        /// </summary>
        [DataMember(Name = "inspectionTypeId", EmitDefaultValue = false)]
        public string InspectionTypeId { get; set; }

        /// <summary>
        /// Gets or sets the record id.
        /// </summary>
        /// <value>
        /// The record id.
        /// </value>
        [DataMember(Name = "recordId", EmitDefaultValue = false)]
        public string RecordId { get; set; }

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
        public static List<InspectionModel> ToEntityModels(List<WSScheduleInspection> wsModels)
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
        public static InspectionModel ToEntityModel(WSScheduleInspection wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }
            
            wsModel.Latitude = wsModel.AutoCaptureGPSLatitude;           
            wsModel.Longitude = wsModel.AutoCaptureGPSLongitude;
            
            var result = new InspectionModel()
            {
                SequenceNumber = wsModel.SequenceNumber,
                Type = new InspectionTypeModel()
                {
                    Identifier = wsModel.InspectionTypeId
                },
                Record = new RecordModel()
                {
                    Identifier = wsModel.RecordId
                },
                ScheduleDate = wsModel.ScheduleDate,
                ScheduleTime = wsModel.ScheduleTime,
                ScheduleNotes = wsModel.ScheduleNotes,
                Address = wsModel.Address,
                Department = wsModel.Department,
                Inspector = WSInspector.ToEntityModel(wsModel.Inspector),
                InspectionUnit = wsModel.InspectionUnit,
                RequestorPhoneNumber = wsModel.RequestorPhoneNumber,
                ContactName = wsModel.ContactName,
                ContactPhoneNumber = wsModel.ContactPhoneNumber,
                LicensedProfessional = wsModel.LicensedProfessional,
                Latitude = wsModel.Latitude,
                Longitude = wsModel.Latitude,
                Checklists = WSScheduleChecklist.ToEntityModels(wsModel.Checklists),
                Comments = WSInspectionComment.ToEntityModels(wsModel.Comments)
            };

            return result;
        }
    }
}
