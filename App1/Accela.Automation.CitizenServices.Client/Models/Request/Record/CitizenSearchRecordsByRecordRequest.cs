using System.Runtime.Serialization;
using Accela.ACA.WSProxy;

namespace Accela.Automation.CitizenServices.Client.Models.Request.Record
{
    [DataContract(Name = "citizenSearchRecordsByRecordRequest")]
    public class CitizenSearchRecordsByRecordRequest : RequestBase
    {
        [DataMember(EmitDefaultValue=false)]
        public string accessByACA
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false)]
        public CitizenSearchRecordsByAddressRequest addressModel
        {
            get;
            set;
        }

        //[DataMember(EmitDefaultValue=false)]
        //public CitizenAddressModel[] addressModels
        //{
        //    get;
        //    set;
        //}

        [DataMember(EmitDefaultValue=false)]
        public string altID
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string appTypeAlias
        {
            get;
            set;
        }

        //[DataMember(EmitDefaultValue=false)]
        //public CapContactModel4WS applicantModel
        //{
        //    get;
        //    set;
        //}

        [DataMember(EmitDefaultValue=false)]
        public string auditDate
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string auditID
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string auditStatus
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string capClass
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false)]
        public CitizenSearchRecordsByContactRequest capContactModel
        {
            get;
            set;
        }

        //[DataMember(EmitDefaultValue=false)]
        //public CitizenRecordDetailModel capDetailModel
        //{
        //    get;
        //    set;
        //}

        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID
        {
            get;
            set;
        }

        //[DataMember(EmitDefaultValue=false)]
        //public OwnerModel capOwnerModel
        //{
        //    get;
        //    set;
        //}

        //[DataMember(EmitDefaultValue=false)]
        //public ParcelModel capParcelModel
        //{
        //    get;
        //    set;
        //}

        [DataMember(EmitDefaultValue=false)]
        public string capStatus
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string capStatusDate
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public CapTypeModel capType
        {
            get;
            set;
        }

        //[DataMember(EmitDefaultValue=false)]
        //public CapContactModel4WS[] contactsGroup
        //{
        //    get;
        //    set;
        //}

        [DataMember(EmitDefaultValue=false)]
        public string createdBy
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string createdByACA
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string endFileDate
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string endReportedDate
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string eventCode
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string expDate
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string fileDate
        {
            get;
            set;
        }

        //[DataMember(EmitDefaultValue=false)]
        //public GISObjectModel[] gisObjects
        //{
        //    get;
        //    set;
        //}

        [DataMember(EmitDefaultValue=false)]
        public string licSeqNbr
        {
            get;
            set;
        }

        //[DataMember(EmitDefaultValue=false)]
        //public LicenseProfessionalModel4WS licenseProfessionalModel
        //{
        //    get;
        //    set;
        //}

        [DataMember(EmitDefaultValue=false)]
        public string moduleName
        {
            get;
            set;
        }

        //[DataMember(EmitDefaultValue=false)]
        //public RefOwnerModel ownerModel
        //{
        //    get;
        //    set;
        //}

        //[DataMember(EmitDefaultValue=false)]
        //public CapParcelModel parcelModel
        //{
        //    get;
        //    set;
        //}

        [DataMember(EmitDefaultValue=false)]
        public CapIDModel parentCapID
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public long projectNumber
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string renewalStatus
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string reportedDate
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string reportedTime
        {
            get;
            set;
        }

        [DataMember(EmitDefaultValue=false)]
        public string superServProvCode
        {
            get;
            set;
        }

        //[DataMember(EmitDefaultValue=false)]
        //public SysUserModel4WS sysUser
        //{
        //    get;
        //    set;
        //}

        [DataMember(EmitDefaultValue=false)]
        public long trackingNbr
        {
            get;
            set;
        }
    }
}