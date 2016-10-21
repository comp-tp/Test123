using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.WSModels.ASIs.InspectorApp;
using Accela.Apps.Apis.WSModels.Inspections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract(Name = "inspection")]
    public class WSInspectorAppInspection : WSIdentifierBase
    {
        /// <summary>
        /// Gets or sets the inspectionseq.
        /// </summary>
        [DataMember(Name = "sequenceNumber", EmitDefaultValue = false)]
        public string SequenceNumber { get; set; }

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
        public WSInspectorAppInspectionType Type { get; set; }

        /// <summary>
        /// Gets or sets the inspection status disp.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public WSInspectorAppInspectionStatus Status { get; set; }

        /// <summary>
        /// Gets or sets auto assign property.
        /// </summary>
        [DataMember(Name = "autoAssign", EmitDefaultValue = false)]
        public bool AutoAssign { get; set; }

        /// <summary>
        /// Gets or sets the Record 
        /// </summary>
        [DataMember(Name = "record", EmitDefaultValue = false)]
        public WSInspectorAppKeysRecord Record { get; set; }

        /// <summary>
        /// Gets or sets the result date.
        /// </summary>
        [DataMember(Name = "resultDate", EmitDefaultValue = false)]
        public string ResultDate { get; set; }

        /// <summary>
        /// Gets or sets the schedule date.
        /// </summary>
        [DataMember(Name = "scheduleDate", EmitDefaultValue = false)]
        public string ScheduleDate { get; set; }

        /// <summary>
        /// Gets or sets the schedule time.
        /// </summary>
        [DataMember(Name = "scheduleTime", EmitDefaultValue = false)]
        public string ScheduleTime { get; set; }

        /// <summary>
        /// Gets or sets the schedule notes.
        /// </summary>
        [DataMember(Name = "scheduleNotes", EmitDefaultValue = false)]
        public string ScheduleNotes { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public string Address { get; set; }

        [DataMember(Name = "detailAddress", EmitDefaultValue = false)]
        public WSDetailAddress DetailAddress { get; set; }

        public string AddressForGeocode { get; set; }

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        [DataMember(Name = "department", EmitDefaultValue = false)]
        public string Department { get; set; }

        /// <summary>
        /// Inspector for the inspection
        /// </summary>
        [DataMember(Name = "inspector", EmitDefaultValue = false)]
        public WSInspectorAppInspector Inspector { get; set; }

        /// <summary>
        /// Gets or sets the inspction unit.
        /// </summary>
        [DataMember(Name = "inspectionUnit", EmitDefaultValue = false)]
        public string InspectionUnit { get; set; }

        /// <summary>
        /// Gets or sets the requestor phone number.
        /// </summary>
        [DataMember(Name = "requestorPhoneNumber", EmitDefaultValue = false)]
        public string RequestorPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the contact name.
        /// </summary>
        [DataMember(Name = "contactName", EmitDefaultValue = false)]
        public string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the contact name.
        /// </summary>
        [DataMember(Name = "contactPhoneNumber", EmitDefaultValue = false)]
        public string ContactPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the firstName.
        /// </summary>
        [DataMember(Name = "contactFirstName", EmitDefaultValue = false)]
        public string ContactFirstName { get; set; }

        /// <summary>
        /// Gets or sets the middleName.
        /// </summary>
        [DataMember(Name = "contactMiddleName", EmitDefaultValue = false)]
        public string ContactMiddleName { get; set; }

        /// <summary>
        /// Gets or sets the lastName.
        /// </summary>
        [DataMember(Name = "contactLastName", EmitDefaultValue = false)]
        public string ContactLastName { get; set; }

        /// <summary>
        /// Inspector for the inspection
        /// </summary>
        [DataMember(Name = "licensedProfessional", EmitDefaultValue = false)]
        public string LicensedProfessional { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        [DataMember(Name = "latitude", EmitDefaultValue = false)]
        public string Latitude { get; set; }

        /// <summary>
        /// Gets or sets the Longitude.
        /// </summary>
        [DataMember(Name = "longitude", EmitDefaultValue = false)]
        public string Longitude { get; set; }

        /// <summary>
        /// Gets or sets the latitude.
        /// </summary>
        [DataMember(Name = "autoCaptureGPSLatitude", EmitDefaultValue = false)]
        public string AutoCaptureGPSLatitude { get; set; }

        /// <summary>
        /// Gets or sets the Longitude.
        /// </summary>
        [DataMember(Name = "autoCaptureGPSLongitude", EmitDefaultValue = false)]
        public string AutoCaptureGPSLongitude { get; set; }

        /// <summary>
        /// Check list for the inspection
        /// </summary>
        [DataMember(Name = "checklists", EmitDefaultValue = false)]
        public List<WSInspectorAppChecklist> Checklists { get; set; }

        /// <summary>
        /// Comments for the inspection
        /// </summary>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public List<WSInspectorAppComment> Comments { get; set; }

        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public string Priority { get; set; }

        /// <summary>
        /// The API used to save asi when update inspection
        /// the property only use in inspector
        /// </summary>
        [DataMember(Name = "additionals", EmitDefaultValue = false)]
        public List<WSInspectorAppASI> Additionals { get; set; }

        /// <summary>
        /// The API used to save asit when update inspection
        /// the property only use in inspector
        /// </summary>
        [DataMember(Name = "additionalTables", EmitDefaultValue = false)]
        public List<WSInspectorAppASIT> AdditionalTables { get; set; }

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

        [DataMember(Name = "estimatedStartTime")]
        public string EstimatedStartTime;

        [DataMember(Name = "estimatedEndTime")]
        public string EstimatedEndTime;

        [DataMember(Name = "score")]
        public string InspectionScore;

        [DataMember(Name = "checklistIdMapping")]
        public List<string[]> ChecklistIdMapping;

        public static InspectionModel ToEntityModel(WSInspectorAppInspection model)
        {
            InspectionModel result = null;

            if (model != null)
            {
                model.Latitude = model.AutoCaptureGPSLatitude;
                model.Longitude = model.AutoCaptureGPSLongitude;
                result = new InspectionModel()
                {
                    Additionals = WSInspectorAppASI.ToEntityModels(model.Additionals),
                    AdditionalTables = WSInspectorAppASIT.ToEntityModels(model.AdditionalTables),
                    Address = model.Address,
                    AddressForGeocode = model.AddressForGeocode,
                    AutoAssign = model.AutoAssign,
                    Checklists = WSInspectorAppChecklist.ToEntityModels(model.Checklists),
                    Comments = WSInspectorAppComment.ToEntityModels(model.Comments),
                    ContactFirstName = model.ContactFirstName,
                    ContactLastName = model.ContactLastName,
                    ContactMiddleName = model.ContactMiddleName,
                    ContactName = model.ContactName,
                    ContactPhoneNumber = model.ContactPhoneNumber,
                    ContextType = model.ContextType,
                    Department = model.Department,
                    Display = model.Display,
                    Identifier = model.Id,
                    InspectionUnit = model.InspectionUnit,
                    Inspector = WSInspectorAppInspector.ToEntityModel(model.Inspector),                    
                    Latitude = model.Latitude,                    
                    Longitude = model.Longitude,
                    LicensedProfessional = model.LicensedProfessional,
                    Priority = model.Priority,
                    Record = WSInspectorAppKeysRecord.ToEntityModel(model.Record),
                    RequestorPhoneNumber = model.RequestorPhoneNumber,
                    ResultDate = model.ResultDate,
                    ScheduleDate = model.ScheduleDate,
                    ScheduleNotes = model.ScheduleNotes,
                    ScheduleTime = model.ScheduleTime,
                    SequenceNumber = model.SequenceNumber,
                    Status = WSInspectorAppInspectionStatus.ToEntityModel(model.Status),
                    Type = WSInspectorAppInspectionType.ToEntityModel(model.Type),
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    TotalTime = model.TotalTime,
                    IsBillable = model.IsBillable,
                    IsOvertime = model.IsOvertime,
                    StartMileage = model.StartMileage,
                    EndMileage = model.EndMileage,
                    TotalMileage = model.TotalMileage,
                    VehicleId = model.VehicleId,
                    EstimatedStartTime = model.EstimatedStartTime,
                    EstimatedEndTime = model.EstimatedEndTime,
                    InspectionScore = model.InspectionScore
                };
            }

            return result;
        }

        public static WSInspectorAppInspection FromEntityModel(InspectionModel model)
        {
            WSInspectorAppInspection result = null;

            if (model != null)
            {
                result = new WSInspectorAppInspection()
                {
                    Additionals = null,
                    AdditionalTables = null,
                    Address = model.Address,
                    DetailAddress = WSDetailAddress.FromEntityModel(model.DetailAddress),
                    AddressForGeocode = model.AddressForGeocode,
                    AutoAssign = model.AutoAssign,
                    Checklists = WSInspectorAppChecklist.FromEntityModels(model.Checklists),
                    Comments = WSInspectorAppComment.FromEntityModels(model.Comments),
                    ContactFirstName = model.ContactFirstName,
                    ContactLastName = model.ContactLastName,
                    ContactMiddleName = model.ContactMiddleName,
                    ContactName = model.ContactName,
                    ContactPhoneNumber = model.ContactPhoneNumber,
                    ContextType = model.ContextType,
                    Department = model.Department,
                    Display = model.Display,
                    Id = model.Identifier,
                    InspectionUnit = model.InspectionUnit,
                    Inspector = WSInspectorAppInspector.FromEntityModel(model.Inspector),
                    Latitude = model.Latitude,
                    LicensedProfessional = model.LicensedProfessional,
                    Longitude = model.Longitude,
                    AutoCaptureGPSLatitude = model.AutoCaptureGPSLatitude,
                    AutoCaptureGPSLongitude = model.AutoCaptureGPSLongitude,
                    Priority = model.Priority,
                    Record = WSInspectorAppKeysRecord.FromEntityModel(model.Record),
                    RequestorPhoneNumber = model.RequestorPhoneNumber,
                    ResultDate = model.ResultDate,
                    ScheduleDate = model.ScheduleDate,
                    ScheduleNotes = model.ScheduleNotes,
                    ScheduleTime = model.ScheduleTime,
                    SequenceNumber = model.SequenceNumber,
                    Status = WSInspectorAppInspectionStatus.FromEntityModel(model.Status),
                    Type = WSInspectorAppInspectionType.FromEntityModel(model.Type),
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    TotalTime = model.TotalTime,
                    IsBillable = model.IsBillable,
                    IsOvertime = model.IsOvertime,
                    StartMileage = model.StartMileage,
                    EndMileage = model.EndMileage,
                    TotalMileage = model.TotalMileage,
                    VehicleId = model.VehicleId,
                    EstimatedStartTime = model.EstimatedStartTime,
                    EstimatedEndTime = model.EstimatedEndTime,
                    InspectionScore = model.InspectionScore,
                    ChecklistIdMapping = model.ChecklistIdMapping
                };
            }

            return result;
        }

        public static List<WSInspectorAppInspection> FromEntityModels(List<InspectionModel> models)
        {
            List<WSInspectorAppInspection> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<WSInspectorAppInspection>();
                foreach (var m in models)
                {
                    var entityModel = FromEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }
    }
}
