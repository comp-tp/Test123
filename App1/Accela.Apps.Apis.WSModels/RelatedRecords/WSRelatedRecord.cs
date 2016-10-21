using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.Records;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.WSModels.RecordTypes;
using Accela.Apps.Apis.WSModels.RecordStatus;

namespace Accela.Apps.Apis.WSModels.RelatedRecords
{
    [DataContract(Name = "record")]
    public class WSRelatedRecord : WSRecord
    {
        [DataMember(Name = "related", EmitDefaultValue = false)]
        public List<WSRelationship> RelatedRecords { get; set; }

        public new static WSRelatedRecord FromEntityModel(RecordModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSRelatedRecord()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display,
                Description = entityModel.Description,
                RecordType = WSRecordType.FromEntityModel(entityModel.RecordType),
                WSAssignToInfo = WSAssignToInfo.FromEntityModel(entityModel.AssignToInfo),
                RecordStatus = WSRecordStatus.FromEntityModel(entityModel.RecordStatus),
                Department = WSDepartment.FromEntityModel(entityModel.Department),
                StaffPerson = WSStaffPerson.FromEntityModel(entityModel.StaffPerson),
                //Addresses = WSAddress.FromEntityModels(entityModel.Addresses),
                Name = entityModel.Name,
                AssignDate = entityModel.AssignDate,
                ScheduleDate = entityModel.ScheduleDate,
                ScheduleTime = entityModel.ScheduleTime,
                OpenDate = entityModel.OpenDate,
                Module = entityModel.Module,
                Priority=entityModel.Priority,
            };

            result.RelatedRecords = new List<WSRelationship>();

            entityModel.RelatedRecords.ForEach(model => result.RelatedRecords.Add(WSRelationship.FromEntityModel(model)));

            return result;
        }
    }
}
