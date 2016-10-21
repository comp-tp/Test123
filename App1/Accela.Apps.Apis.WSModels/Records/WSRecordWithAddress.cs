using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.WSModels.Addresses;
using Accela.Apps.Apis.WSModels.RecordStatus;
using Accela.Apps.Apis.WSModels.RecordTypes;
using Accela.Apps.Apis.WSModels.RelatedRecords;
using Accela.Apps.Shared.FormatHelpers;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract]
    public class WSRecordWithAddress : WSRecord
    {
        /// <summary>
        /// The record addresses information.
        /// </summary>
        [DataMember(Name = "addresses", EmitDefaultValue = false)]
        public List<WSAddress> Addresses { get; set; }

        public static List<WSRecordWithAddress> FromEntityModels(List<RecordModel> records)
        {
            List<WSRecordWithAddress> wsRecords = new List<WSRecordWithAddress>();
            if (records != null && records.Count > 0)
            {
                foreach (var record in records)
                {
                    wsRecords.Add(FromEntityModel(record));
                }
            }
            return wsRecords;
        }

        /// <summary>
        /// Convert biz entity to response entity.
        /// </summary>
        /// <param name="record">Record model.</param>
        /// <returns>WS record model.</returns>
        public new static WSRecordWithAddress FromEntityModel(RecordModel record)
        {
            if (record != null)
            {
                return new WSRecordWithAddress()
                {
                    Id = record.Identifier,
                    Display = record.Display,
                    Description = record.Description,
                    RecordType = WSRecordType.FromEntityModel(record.RecordType),
                    WSAssignToInfo = WSAssignToInfo.FromEntityModel(record.AssignToInfo),
                    RecordStatus = WSRecordStatus.FromEntityModel(record.RecordStatus),
                    Department = WSDepartment.FromEntityModel(record.Department),
                    StaffPerson = WSStaffPerson.FromEntityModel(record.StaffPerson),
                    Addresses = WSAddress.FromEntityModels(record.Addresses),
                    Name = record.Name,
                    AssignDate = record.AssignDate,
                    ScheduleDate = record.ScheduleDate,
                    ScheduleTime = record.ScheduleTime,
                    OpenDate = Accela.Apps.Shared.FormatHelpers.DateTimeFormat.ToMetaDateStringFromUIDateString(record.OpenDate),
                    Module = record.Module,
                    Priority = record.Priority,
                    CreatedDate = Accela.Apps.Shared.FormatHelpers.DateTimeFormat.ToMetaDateStringFromUIDateString(record.CreatedDate),
                };
            }
            return null;
        }
    }
}
