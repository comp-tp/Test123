using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "inspectionBase")]
    public class WSInspectionBase : WSDataModel
    {
        /// <summary>
        /// Gets or sets the inspection seq.
        /// </summary>
        [DataMember(Name = "sequenceNumber", EmitDefaultValue = false)]
        public string SequenceNumber { get; set; }

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

        /// <summary>
        /// Gets or sets the department.
        /// </summary>
        [DataMember(Name = "department", EmitDefaultValue = false)]
        public string Department { get; set; }

        /// <summary>
        /// Inspector for the inspection
        /// </summary>
        [DataMember(Name = "inspector", EmitDefaultValue = false)]
        public WSInspector Inspector { get; set; }

        /// <summary>
        /// Gets or sets the inspection unit.
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
        /// Gets or sets the contact name.
        /// </summary>
        [DataMember(Name = "contactPhoneNumber", EmitDefaultValue = false)]
        public string ContactPhoneNumber { get; set; }

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
        /// Comments for the inspection
        /// </summary>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public List<WSInspectionComment> Comments { get; set; }

        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public string Priority { get; set; }

        [DataMember(Name = "estimatedStartTime")]
        public string EstimatedStartTime;

        [DataMember(Name = "estimatedEndTime")]
        public string EstimatedEndTime;
    }
}
