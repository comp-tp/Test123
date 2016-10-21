using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract(Name = "recordBase")]
    public class WSInspectorAppRecordBase : WSDataModel
    {
        /// <summary>
        /// UID separator
        /// </summary>
        public const string UID_SEPARATOR = "__";

        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// The description associated with this RECORD. This can be Work Description for a Permit. 
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Name = "isPrivate", EmitDefaultValue = false)]
        public bool IsPrivate { get; set; }

        /// <summary>
        /// Type information of this RECORD. 
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public WSInspectorAppRecordType RecordType { get; set; }

        /// <summary>
        /// The current status of this RECORD.  
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public WSInspectorAppRecordStatus RecordStatus { get; set; }

        /// <summary>
        /// Department for the record
        /// </summary>
        [DataMember(Name = "department", EmitDefaultValue = false)]
        public WSInspectorAppDepartment Department { get; set; }

        [DataMember(Name = "staffPerson", EmitDefaultValue = false)]
        public WSInspectorAppStaffPerson StaffPerson { get; set; }


        /// <summary>
        /// record's assign date
        /// </summary>
        [DataMember(Name = "assignDate", EmitDefaultValue = false)]
        public string AssignDate { get; set; }

        /// <summary>
        /// The record schedule date.
        /// </summary>
        [DataMember(Name = "scheduleDate", EmitDefaultValue = false)]
        public string ScheduleDate { get; set; }

        /// <summary>
        /// The record schedule time
        /// </summary>
        [DataMember(Name = "scheduleTime", EmitDefaultValue = false)]
        public string ScheduleTime { get; set; }

        /// <summary>
        /// record's assign date
        /// </summary>
        [DataMember(Name = "openDate", EmitDefaultValue = false)]
        public string OpenDate { get; set; }

        /// <summary>
        /// Record's priority
        /// </summary>
        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public string Priority { get; set; }

        /// <summary>
        /// Record's Short Notes
        /// </summary>
        [DataMember(Name = "shortNotes", EmitDefaultValue = false)]
        public string ShortNotes { get; set; }

        /// <summary>
        /// Workorder's template  name
        /// </summary>
        [DataMember(Name = "templateName", EmitDefaultValue = false)]
        public string TemplateName { get; set; }



        /// <summary>
        /// Convert biz entity to response entity.
        /// </summary>
        /// <param name="record">Record model.</param>
        /// <returns>WS record model.</returns>
        public static WSInspectorAppRecordBase FromEntityModel(RecordModel record)
        {
            if (record != null)
            {
                return new WSInspectorAppRecordBase()
                {
                    Id = record.Identifier,
                    Description = record.Description,
                    RecordType = WSInspectorAppRecordType.FromEntityModel(record.RecordType),
                    RecordStatus = WSInspectorAppRecordStatus.FromEntityModel(record.RecordStatus),
                    Department = WSInspectorAppDepartment.FromEntityModel(record.Department),
                    StaffPerson = WSInspectorAppStaffPerson.FromEntityModel(record.StaffPerson),
                    //Addresses = WSAddress.FromEntityModels(record.Addresses),
                    AssignDate = record.AssignDate,
                    ScheduleDate = record.ScheduleDate,
                    ScheduleTime = record.ScheduleTime,
                    OpenDate = record.OpenDate,
                    Priority = record.Priority,
                    ShortNotes = record.ShortNotes,
                    TemplateName = record.TemplateName,
                };
            }
            return null;
        }

        /// <summary>
        /// Convert WSRecord to RecordModel.
        /// </summary>
        /// <param name="wsRecord">WSRecord.</param>
        /// <returns>RecordModel.</returns>
        public static void ToEntityModel(RecordModel recordModel, WSInspectorAppRecordBase wsRecord)
        {
            if (wsRecord != null && recordModel != null)
            {
                recordModel.Identifier = wsRecord.Id;
                recordModel.Description = wsRecord.Description;
                recordModel.RecordType = WSInspectorAppRecordType.ToEntityModel(wsRecord.RecordType);
                recordModel.RecordStatus = WSInspectorAppRecordStatus.ToEntityModel(wsRecord.RecordStatus);
                recordModel.Department = WSInspectorAppDepartment.ToEntityModel(wsRecord.Department);
                recordModel.StaffPerson = WSInspectorAppStaffPerson.ToEntityModel(wsRecord.StaffPerson);
                //recordModel.Addresses = WSAddress.ToEntityModels(wsRecord.Addresses);
                recordModel.AssignDate = wsRecord.AssignDate;
                recordModel.ScheduleDate = wsRecord.ScheduleDate;
                recordModel.ScheduleTime = wsRecord.ScheduleTime;
                recordModel.OpenDate = wsRecord.OpenDate;
                recordModel.Priority = wsRecord.Priority;
                recordModel.ShortNotes = wsRecord.ShortNotes;
                recordModel.TemplateName = wsRecord.TemplateName;
            };
        }

        /// <summary>
        /// Builds the UID.
        /// </summary>
        /// <param name="agency">The agency.</param>
        /// <param name="environmentName">Name of the environment.</param>
        /// <param name="recordId">The record id.</param>
        /// <returns>the UID.</returns>
        public static string BuildUID(string agency, string environmentName, string recordId)
        {
            const string UID_PATTERN = "{1}{0}{2}{0}{3}";
            var uid = String.Format(UID_PATTERN, UID_SEPARATOR, agency, environmentName, recordId);
            return uid;
        }

        public static bool ParseUID(string uid, out string agencyName, out string environmentName, out string recordId)
        {
            bool result = false;

            agencyName = null;
            environmentName = null;
            recordId = uid;

            if (!String.IsNullOrWhiteSpace(uid))
            {
                var valueArray = uid.Split(new string[] { UID_SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);

                if (valueArray != null && valueArray.Length == 3)
                {
                    agencyName = valueArray[0];
                    environmentName = valueArray[1];
                    recordId = valueArray[2];

                    result = true;
                }
            }

            return result;
        }
    }
}
