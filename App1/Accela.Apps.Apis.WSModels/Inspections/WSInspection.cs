using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.WSModels.Records;
using System;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "inspection")]
    public class WSInspection : WSInspectionBase
    {
        /// <summary>
        /// Gets or sets the inspection Id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the inspection display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the ContextType.
        /// Here need know the ContextType,
        /// The ContextType have two field, 1. Readonly, 2. Scheduled
        /// The field was tell user whether or not the inspection can be changed
        /// </summary>
        [DataMember(Name = "contextType", EmitDefaultValue = false)]
        public string ContextType { get; set; }

        /// <summary>
        /// Gets or sets Inspection Type
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public WSInspectionType Type { get; set; }

        /// <summary>
        /// Gets or sets the inspection status disp.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public WSInspectionStatus Status { get; set; }

        [DataMember(Name = "recordId", EmitDefaultValue = false)]
        public string RecordId { get; set; }

        [DataMember(Name = "recordIdDisplay", EmitDefaultValue = false)]
        public string RecordIdDisplay { get; set; }

        /// <summary>
        /// Gets or sets the result date.
        /// </summary>
        [DataMember(Name = "resultDate", EmitDefaultValue = false)]
        public string ResultDate { get; set; }

        [DataMember(Name = "record", EmitDefaultValue = false)]
        public WSRecordWithinInspection Record { get; set; }

        [DataMember(Name = "startTime", EmitDefaultValue = false)]
        public string StartTime { get; set; }

        [DataMember(Name = "endTime", EmitDefaultValue = false)]
        public string EndTime { get; set; }

        [DataMember(Name = "totalTime", EmitDefaultValue = false)]
        public string TotalTime { get; set; }

        [DataMember(Name = "overtime", EmitDefaultValue = true)]
        public bool IsOvertime { get; set; }

        [DataMember(Name = "billable", EmitDefaultValue = true)]
        public bool IsBillable { get; set; }

        [DataMember(Name = "startMileage", EmitDefaultValue = true)]
        public double StartMileage { get; set; }

        [DataMember(Name = "endMileage", EmitDefaultValue = true)]
        public double EndMileage { get; set; }

        [DataMember(Name = "totalMileage", EmitDefaultValue = true)]
        public double TotalMileage { get; set; }

        [DataMember(Name = "vehicleId", EmitDefaultValue = false)]
        public string VehicleId { get; set; }

        [DataMember(Name = "score")]
        public string InspectionScore;

        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">The ws model.</param>
        /// <returns>the entity model.</returns>
        public static InspectionModel ToEntityModel(WSInspection wsModel)
        {
            if (wsModel != null)
            {
                return new InspectionModel()
                {
                    Identifier = wsModel.Id,
                    SequenceNumber = wsModel.SequenceNumber,
                    Display = wsModel.Display,
                    ContextType = wsModel.ContextType,
                    Type = WSInspectionType.ToEntityModel(wsModel.Type),
                    Status = WSInspectionStatus.ToEntityModel(wsModel.Status),
                    Record = !String.IsNullOrWhiteSpace(wsModel.RecordId) ?
                        new RecordModel()
                        {
                            Identifier = wsModel.RecordId,
                            Display = wsModel.RecordIdDisplay
                        } : null,
                    ResultDate = wsModel.ResultDate,
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
                    Priority = wsModel.Priority,
                    IsOvertime = wsModel.IsOvertime,
                    IsBillable = wsModel.IsBillable,
                    StartMileage = wsModel.StartMileage,
                    EndMileage = wsModel.EndMileage,
                    TotalMileage = wsModel.TotalMileage,
                    VehicleId = wsModel.VehicleId,
                    EstimatedStartTime = wsModel.EstimatedStartTime,
                    EstimatedEndTime = wsModel.EstimatedEndTime,
                    InspectionScore = wsModel.InspectionScore
                };
            }
            return null;
        }

        /// <summary>
        /// Convert InspectionModel to WSInspection.
        /// </summary>
        /// <param name="inspectionModel">InspectionModel.</param>
        /// <returns>WSInspection.</returns>
        public static WSInspection FromEntityModel(InspectionModel inspectionModel)
        {
            if (inspectionModel == null) return null;
            
            var result = new WSInspection()
            {
                Id = inspectionModel.Identifier,
                SequenceNumber = inspectionModel.SequenceNumber,
                Display = inspectionModel.Display,
                ContextType = inspectionModel.ContextType,
                Type = WSInspectionType.FromEntityModel(inspectionModel.Type),
                Status = WSInspectionStatus.FromEntityModel(inspectionModel.Status),
                ResultDate = inspectionModel.ResultDate,
                ScheduleDate = inspectionModel.ScheduleDate,
                ScheduleTime = inspectionModel.ScheduleTime,
                ScheduleNotes = inspectionModel.ScheduleNotes,
                Address = inspectionModel.Address,
                DetailAddress = WSDetailAddress.FromEntityModel(inspectionModel.DetailAddress),
                Department = inspectionModel.Department,
                Inspector = WSInspector.FromEntityModel(inspectionModel.Inspector),
                InspectionUnit = inspectionModel.InspectionUnit,
                RequestorPhoneNumber = inspectionModel.RequestorPhoneNumber,
                ContactName = inspectionModel.ContactName,
                ContactFirstName = inspectionModel.ContactFirstName,
                ContactMiddleName = inspectionModel.ContactMiddleName,
                ContactLastName = inspectionModel.ContactLastName,
                ContactPhoneNumber = inspectionModel.ContactPhoneNumber,
                LicensedProfessional = inspectionModel.LicensedProfessional,
                Latitude = inspectionModel.Latitude,
                Longitude = inspectionModel.Longitude,
                AutoCaptureGPSLatitude = inspectionModel.AutoCaptureGPSLatitude,
                AutoCaptureGPSLongitude = inspectionModel.AutoCaptureGPSLongitude,
                Priority = inspectionModel.Priority,
                Comments = WSInspectionComment.FromEntityModels(inspectionModel.Comments),
                StartTime = inspectionModel.StartTime,
                EndTime = inspectionModel.EndTime,
                TotalTime = inspectionModel.TotalTime,
                IsBillable = inspectionModel.IsBillable,
                IsOvertime = inspectionModel.IsOvertime,
                StartMileage = inspectionModel.StartMileage,
                EndMileage = inspectionModel.EndMileage,
                TotalMileage = inspectionModel.TotalMileage,
                VehicleId = inspectionModel.VehicleId,
                EstimatedStartTime = inspectionModel.EstimatedStartTime,
                EstimatedEndTime = inspectionModel.EstimatedEndTime,
                InspectionScore = inspectionModel.InspectionScore
            };

            if (inspectionModel.Record == null) return result;

            result.RecordId = inspectionModel.Record.Identifier;
            result.RecordIdDisplay = inspectionModel.Record.Display;

            if (inspectionModel.Record.RecordType != null)
            {
                result.Record = WSRecordWithinInspection.FromEntityModel(inspectionModel.Record);
            }

            return result;
        }
    }
}
