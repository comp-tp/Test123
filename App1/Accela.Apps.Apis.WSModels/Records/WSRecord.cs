using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.WSModels.Citizen;
using Accela.Apps.Apis.WSModels.RecordTypes;
using Accela.Apps.Apis.WSModels.RecordStatus;
using Accela.Apps.Apis.WSModels.RelatedRecords;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract(Name = "record")]
    public class WSRecord : WSRecordBase
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
        public WSAssignToInfo WSAssignToInfo { get; set; }
        

        [DataMember(Name = "user", EmitDefaultValue = false)]
        public WSCitizen Citizen { get; set; }

        [DataMember(Name = "createdDate", EmitDefaultValue = false)]
        public string CreatedDate { get; set; }

         

        /// <summary>
        /// Convert biz entity to response entity.
        /// </summary>
        /// <param name="record">Record model.</param>
        /// <returns>WS record model.</returns>
        public static new WSRecord FromEntityModel(RecordModel record)
        {
            if (record != null)
            {
                WSRecord result = new WSRecord()
                {
                    Id = record.Identifier,
                    Display = record.Display,
                    Description = record.Description,
                    RecordType = WSRecordType.FromEntityModel(record.RecordType),
                    RecordStatus = WSRecordStatus.FromEntityModel(record.RecordStatus),
                    WSAssignToInfo = WSAssignToInfo.FromEntityModel(record.AssignToInfo),
                    Department = WSDepartment.FromEntityModel(record.Department),
                    StaffPerson = WSStaffPerson.FromEntityModel(record.StaffPerson),
                    Name = record.Name,
                    AssignDate = record.AssignDate,
                    ScheduleDate = record.ScheduleDate,
                    ScheduleTime = record.ScheduleTime,
                    OpenDate = record.OpenDate,
                    Module = record.Module,
                    Priority=record.Priority,
                    CreatedDate=record.CreatedDate
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
        public static void ToEntityModel(RecordModel recordModel, WSRecord wsRecord)
        {
            if (wsRecord != null && recordModel != null)
            {
                recordModel.Identifier = wsRecord.Id;
                recordModel.Display = wsRecord.Display;
                recordModel.Description = wsRecord.Description;
                recordModel.RecordType = WSRecordType.ToEntityModel(wsRecord.RecordType);
                recordModel.RecordStatus = WSRecordStatus.ToEntityModel(wsRecord.RecordStatus);
                recordModel.Department = WSDepartment.ToEntityModel(wsRecord.Department);
                recordModel.StaffPerson = WSStaffPerson.ToEntityModel(wsRecord.StaffPerson);
                recordModel.AssignToInfo = WSAssignToInfo.ToEntityModel(wsRecord.WSAssignToInfo);
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

    [DataContract]
    public class WSAssignToInfo
    {
        [DataMember(Name = "totalJobCost", EmitDefaultValue = false)]
        public string TotalJobCost { get; set; }

        [DataMember(Name = "completeDate", EmitDefaultValue = false)]
        public string CompleteDate { get; set; }

        [DataMember(Name = "AssignDate", EmitDefaultValue = false)]
        public string AssignDate { get; set; }

        [DataMember(Name = "scheduledDate", EmitDefaultValue = false)]
        public string ScheduledDate { get; set; }

        [DataMember(Name = "assignStaff", EmitDefaultValue = false)]
        public string AssignStaff { get; set; }

        [DataMember(Name = "assignDepartment", EmitDefaultValue = false)]
        public string AssignDepartment { get; set; }

        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public string Priority { get; set; }

        public static WSAssignToInfo FromEntityModel(AssignToInfo assignToInfo)
        {
            WSAssignToInfo wsAssignToInfo = null;
            if (assignToInfo != null)
            {
                wsAssignToInfo = new WSAssignToInfo() { 
                    AssignDate = assignToInfo.AssignDate, 
                    AssignDepartment = assignToInfo.AssignDepartment,
                    AssignStaff = assignToInfo.AssignStaff,
                    CompleteDate = assignToInfo.CompleteDate,
                    ScheduledDate = assignToInfo.ScheduledDate,
                    TotalJobCost = assignToInfo.TotalJobCost,
                    Priority = assignToInfo.Priority
                };
                
            }

            return wsAssignToInfo;
        }

        public static AssignToInfo ToEntityModel(WSAssignToInfo wsAssignToInfo)
        {
            AssignToInfo assignToInfo = null;
            if (wsAssignToInfo != null)
            {
                assignToInfo = new AssignToInfo()
                {
                    AssignDate = wsAssignToInfo.AssignDate,
                    AssignDepartment = wsAssignToInfo.AssignDepartment,
                    AssignStaff = wsAssignToInfo.AssignStaff,
                    CompleteDate = wsAssignToInfo.CompleteDate,
                    ScheduledDate = wsAssignToInfo.ScheduledDate,
                    TotalJobCost = wsAssignToInfo.TotalJobCost,
                    Priority = wsAssignToInfo.Priority
                };

            }

            return assignToInfo;
        }
    }
}
