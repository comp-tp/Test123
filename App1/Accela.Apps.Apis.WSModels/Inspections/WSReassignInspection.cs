﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "reassignInspection")]
    public class WSReassignInspection : WSInspectionBase
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// gets or sets the display
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// gets or sets the autoAssign.
        /// </summary>
        [DataMember(Name ="autoAssign", EmitDefaultValue = false)]
        public bool AutoAssign { get; set; }

        /// <summary>
        /// Gets or sets Inspection Type id
        /// </summary>
        [DataMember(Name = "inspectionTypeId", EmitDefaultValue = false)]
        public string InspectionTypeId { get; set; }

        /// <summary>
        /// Gets or sets Inspection Type
        /// </summary>
        [DataMember(Name = "inspectionTypeDisplay", EmitDefaultValue = false)]
        public string InspectionTypeDisplay { get; set; }


        /// <summary>
        /// gets or sets the status id
        /// </summary>
        [DataMember(Name = "statusId", EmitDefaultValue = false)]
        public string StatusId { get; set; }

        /// <summary>
        /// gets or sets the status display
        /// </summary>
        [DataMember(Name = "statusDisplay", EmitDefaultValue = false)]
        public string StatusDisplay { get; set; }

        /// <summary>
        /// gets or sets the status type
        /// </summary>
        [DataMember(Name = "statusType", EmitDefaultValue = false)]
        public string StatusType{ get; set; }

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
        public static List<InspectionModel> ToEntityModels(List<WSReassignInspection> wsModels)
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
        public static InspectionModel ToEntityModel(WSReassignInspection wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            wsModel.Latitude = wsModel.AutoCaptureGPSLatitude;
            wsModel.Longitude = wsModel.AutoCaptureGPSLongitude;

            var result = new InspectionModel()
                             {
                                 Identifier = wsModel.Identifier,
                                 SequenceNumber = wsModel.SequenceNumber,
                                 Type = new InspectionTypeModel()
                                            {
                                                Identifier = wsModel.InspectionTypeId,
                                                Display = wsModel.InspectionTypeDisplay

                                            },
                                 Record = new RecordModel()
                                              {
                                                  Identifier = wsModel.RecordId

                                              },
                                 Status = new InspectionStatusModel()
                                              {
                                                  Display = wsModel.StatusDisplay,
                                                  Identifier = wsModel.StatusId,
                                                  Type = wsModel.StatusDisplay
                                              },
                                         
                                 AutoAssign =  wsModel.AutoAssign,
                                 Display = wsModel.Display,
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

            if(wsModel.AutoAssign)
            {
                result.ScheduleDate = string.Empty;
                result.ScheduleTime = string.Empty;
                result.Inspector = null;
            }

            return result;
        }
    }
}