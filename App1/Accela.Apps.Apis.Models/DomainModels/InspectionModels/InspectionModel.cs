using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DomainModels.InspectionModels
{
    /// <summary>
    /// Inspection class
    /// Here need know the ContextType,
    /// The ContextType have two field, 1. Readonly, 2. Scheduled
    /// The field was tell user whether or not the inspection can be changed
    /// </summary>
    [DataContract]
    public class InspectionModel : DataModel
    {
        
        #region Properties
        
        /// <summary>
        /// Gets or sets the inspection Id.
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the inspectionseq.
        /// </summary>
        [DataMember(Name = "sequenceNumber", EmitDefaultValue = false)]
        public string SequenceNumber { get; set; }

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
        public InspectionTypeModel Type { get; set; }

        /// <summary>
        /// Gets or sets the inspection status disp.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public InspectionStatusModel Status { get; set; }

        /// <summary>
        /// Gets or sets auto assign property.
        /// </summary>
        [DataMember(Name = "autoAssign", EmitDefaultValue = false)]
        public bool AutoAssign { get; set; }

        /// <summary>
        /// Gets or sets the Record 
        /// </summary>
        [DataMember(Name = "record", EmitDefaultValue = false)]
        public RecordModel Record { get; set; }

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
        public DetailAddressModel DetailAddress { get; set; }

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
        public InspectorModel Inspector { get; set; }

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
        public List<ChecklistModel> Checklists { get; set; }

        /// <summary>
        /// Comments for the inspection
        /// </summary>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public List<Comment> Comments { get; set; }

        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public string Priority { get; set; }

        /// <summary>
        /// The API used to save asi when update inspection
        /// the property only use in inspector
        /// </summary>
        [DataMember(Name = "additionals", EmitDefaultValue = false)]
        public List<AdditionalGroupModel> Additionals { get; set; }

        /// <summary>
        /// The API used to save asit when update inspection
        /// the property only use in inspector
        /// </summary>
        [DataMember(Name = "additionalTables", EmitDefaultValue = false)]
        public List<AdditionalTableModel> AdditionalTables { get; set; }

        [DataMember(Name = "startTime", EmitDefaultValue = false)]
        public string StartTime { get; set; }

        [DataMember(Name = "endTime", EmitDefaultValue = false)]
        public string EndTime { get; set; }

        [DataMember(Name = "totalTime", EmitDefaultValue = false)]
        public string TotalTime { get; set; }

        [DataMember(Name = "isOvertime", EmitDefaultValue = false)]
        public bool IsOvertime { get; set; }

        [DataMember(Name = "isBillable", EmitDefaultValue = false)]
        public bool IsBillable { get; set; }

        [DataMember(Name = "startMileage", EmitDefaultValue = false)]
        public double StartMileage { get; set; }

        [DataMember(Name = "endMileage", EmitDefaultValue = false)]
        public double EndMileage { get; set; }

        [DataMember(Name = "totalMileage", EmitDefaultValue = false)]
        public double TotalMileage { get; set; }

        [DataMember(Name = "vehicleId", EmitDefaultValue = true)]
        public string VehicleId { get; set; }

        [DataMember(Name = "estimatedStartTime")]
        public string EstimatedStartTime;

        [DataMember(Name = "estimatedEndTime")]
        public string EstimatedEndTime;

        [DataMember(Name = "score")]
        public string InspectionScore;

        [DataMember(Name = "ChecklistIdMapping")]
        public List<string[]> ChecklistIdMapping;

        #endregion Properties
    }
}
