using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DomainModels.ConditionModels;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.CostModels;
using Accela.Apps.Apis.Models.DomainModels.GISModels;
using Accela.Apps.Apis.Models.DomainModels.ParcelModels;
using Accela.Apps.Apis.Models.DomainModels.PartModels;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DomainModels.RecordModels
{
    /// <summary>
    /// It is record data model
    /// </summary>
    [DataContract]
    public class RecordModel : DataModel, IDataModel
    {
        /// <summary>
        /// Gets or sets the record Id.
        /// </summary>
        [DataMember(Name = "identifier",EmitDefaultValue=false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the record display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

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
        [DataMember(Name = "recordType", EmitDefaultValue = false)]
        public RecordTypeModel RecordType { get; set; }

        /// <summary>
        /// The current status of this RECORD.  
        /// </summary>
        [DataMember(Name = "recordStatus", EmitDefaultValue = false)]
        public RecordStatusModel RecordStatus { get; set; }

        /// <summary>
        /// An additional descriptor for the RECORD. 
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// record's assign date
        /// </summary>
        [DataMember(Name = "assignToInfo", EmitDefaultValue = false)]
        public AssignToInfo AssignToInfo { get; set; }

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
        /// The module name.
        /// </summary>
        [DataMember(Name = "module", EmitDefaultValue = false)]
        public string Module { get; set; }

        /// <summary>
        /// Department for the record
        /// </summary>
        [DataMember(Name = "department", EmitDefaultValue = false)]
        public DepartmentModel Department { get; set; }

        [DataMember(Name = "staffPerson", EmitDefaultValue = false)]
        public StaffPersonModel StaffPerson { get; set; }

        /// <summary>
        /// The record addresses information.
        /// </summary>
        [DataMember(Name = "addresses", EmitDefaultValue = false)]
        public List<AddressModel> Addresses { get; set; }

        /// <summary>
        /// The record condition information.
        /// </summary>
        [DataMember(Name = "conditions", EmitDefaultValue = false)]
        public List<ConditionModel> Conditions { get; set; }

        /// <summary>
        /// The record contact information.
        /// </summary>
        [DataMember(Name = "contacts", EmitDefaultValue = false)]
        public List<ContactModel> Contacts { get; set; }

        /// <summary>
        /// Additional Info
        /// </summary>
        [DataMember(Name = "additionalInfo", EmitDefaultValue = false)]
        public List<AdditionalGroupModel> AdditionalInfo { get; set; }

        /// <summary>
        /// Additional Table Info
        /// </summary>
        [DataMember(Name = "additionalTableInfo", EmitDefaultValue = false)]
        public List<AdditionalTableModel> AdditionalTableInfo { get; set; }

        /// <summary>
        /// The record parcel information
        /// </summary>
        [DataMember(Name = "parcels", EmitDefaultValue = false)]
        public List<ParcelModel> Parcels { get; set; }

        /// <summary>
        /// The record part information
        /// </summary>
        [DataMember(Name = "parts", EmitDefaultValue = false)]
        public List<PartModel> Parts { get; set; }

        /// <summary>
        /// The record costs.
        /// </summary>
        [DataMember(Name = "costs", EmitDefaultValue = false)]
        public List<CostModel> Costs { get; set; }

        /// <summary>
        /// The related records.
        /// </summary>
        [DataMember(Name = "relatedRecords", EmitDefaultValue = false)]
        public List<RelatedRecordModel> RelatedRecords { get; set; }

        /// <summary>
        /// The record assets.
        /// </summary>
        public List<AssetModel> Assets { get; set; }

        /// <summary>
        /// The record comment
        /// </summary>
        public List<RecordCommentModel> RecordComments { get; set; }

        /// <summary>
        /// The work order task
        /// </summary>
        public List<WorkOrderTaskModel> WorkOrderTasks { get; set; }

        public List<OwnerModel> Owners { get; set; }

        public List<GISObjectModel> GISObjects { get; set; }

        public string Priority { get; set; }

        [DataMember(Name = "citizen", EmitDefaultValue = false)]
        public CloudUserModel User { get; set; }

        public string CreatedDate { get; set; }

        public int FollowersCount { get; set; }

        /// <summary>
        /// Record's Short Notes
        /// </summary>       
        public string ShortNotes { get; set; }

        /// <summary>
        /// Workorder's template  name
        /// </summary>      
        public string TemplateName { get; set; }
    }

    [DataContract]
    public class AssignToInfo
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
    }
}
