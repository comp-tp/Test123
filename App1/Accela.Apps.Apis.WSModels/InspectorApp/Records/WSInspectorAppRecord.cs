using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract(Name = "record")]
    public class WSInspectorAppRecord : WSInspectorAppRecordBase
    {
        /// <summary>
        /// Gets or sets the record display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// The module name.
        /// </summary>
        [DataMember(Name = "module", EmitDefaultValue = false)]
        public string Module { get; set; }

        /// <summary>
        /// An additional descriptor for the RECORD. 
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "assignToInfo", EmitDefaultValue = false)]
        public WSInspectorAppAssignToInfo WSAssignToInfo { get; set; }


        [DataMember(Name = "user", EmitDefaultValue = false)]
        public WSInspectorAppCitizen Citizen { get; set; }

        [DataMember(Name = "createdDate", EmitDefaultValue = false)]
        public string CreatedDate { get; set; }



        /// <summary>
        /// Convert biz entity to response entity.
        /// </summary>
        /// <param name="record">Record model.</param>
        /// <returns>WS record model.</returns>
        public static new WSInspectorAppRecord FromEntityModel(RecordModel record)
        {
            if (record != null)
            {
                var result = new WSInspectorAppRecord()
                {
                    Id = record.Identifier,
                    Display = record.Display,
                    Description = record.Description,
                    RecordType = WSInspectorAppRecordType.FromEntityModel(record.RecordType),
                    RecordStatus = WSInspectorAppRecordStatus.FromEntityModel(record.RecordStatus),
                    WSAssignToInfo = WSInspectorAppAssignToInfo.FromEntityModel(record.AssignToInfo),
                    Department = WSInspectorAppDepartment.FromEntityModel(record.Department),
                    StaffPerson = WSInspectorAppStaffPerson.FromEntityModel(record.StaffPerson),
                    Name = record.Name,
                    AssignDate = record.AssignDate,
                    ScheduleDate = record.ScheduleDate,
                    ScheduleTime = record.ScheduleTime,
                    OpenDate = record.OpenDate,
                    Module = record.Module,
                    Priority = record.Priority,
                    CreatedDate = record.CreatedDate
                };

                //TODO:
                //if (record.User != null)
                //{
                //    result.Citizen = new WSCitizen
                //    {
                //        CivicId = record.User.Id,
                //        Email = record.User.LoginName,
                //        FirstName = record.User.FirstName,
                //        LastName = record.User.LastName
                //    };
                //}

                return result;
            }

            return null;
        }

        /// <summary>
        /// Convert WSRecord to RecordModel.
        /// </summary>
        /// <param name="wsRecord">WSRecord.</param>
        /// <returns>RecordModel.</returns>
        public static void ToEntityModel(RecordModel recordModel, WSInspectorAppRecord wsRecord)
        {
            if (wsRecord != null && recordModel != null)
            {
                recordModel.Identifier = wsRecord.Id;
                recordModel.Display = wsRecord.Display;
                recordModel.Description = wsRecord.Description;
                recordModel.RecordType = WSInspectorAppRecordType.ToEntityModel(wsRecord.RecordType);
                recordModel.RecordStatus = WSInspectorAppRecordStatus.ToEntityModel(wsRecord.RecordStatus);
                recordModel.Department = WSInspectorAppDepartment.ToEntityModel(wsRecord.Department);
                recordModel.StaffPerson = WSInspectorAppStaffPerson.ToEntityModel(wsRecord.StaffPerson);
                recordModel.Name = wsRecord.Name;
                recordModel.AssignDate = wsRecord.AssignDate;
                recordModel.ScheduleDate = wsRecord.ScheduleDate;
                recordModel.ScheduleTime = wsRecord.ScheduleTime;
                recordModel.OpenDate = wsRecord.OpenDate;
                recordModel.Module = wsRecord.Module;
                recordModel.Priority = wsRecord.Priority;
                recordModel.CreatedDate = wsRecord.CreatedDate;
            };
        }
    }
}
