using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name = "staffPerson")]
    public class WSAssetCAStaffPerson : WSIdentifierBase
    {
        [DataMember(Name = "firstName", EmitDefaultValue = false, Order = 3)]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName", EmitDefaultValue = false, Order = 4)]
        public string LastName { get; set; }

        [DataMember(Name = "auditStatus", EmitDefaultValue = false, Order = 5)]
        public string AuditStatus { get; set; }

        [DataMember(Name = "serviceProviderCode", EmitDefaultValue = false, Order = 6)]
        public string ServiceProviderCode { get; set; }

        [DataMember(Name = "userID", EmitDefaultValue = false, Order = 7)]
        public string UserID { get; set; }

        [DataMember(Name = "agencyCode", EmitDefaultValue = false, Order = 8)]
        public string AgencyCode { get; set; }

        [DataMember(Name = "bureauCode", EmitDefaultValue = false, Order = 9)]
        public string BureauCode { get; set; }

        [DataMember(Name = "divisionCode", EmitDefaultValue = false, Order = 10)]
        public string DivisionCode { get; set; }

        [DataMember(Name = "sectionCode", EmitDefaultValue = false, Order = 11)]
        public string SectionCode { get; set; }

        [DataMember(Name = "groupCode", EmitDefaultValue = false, Order = 12)]
        public string GroupCode { get; set; }

        [DataMember(Name = "officeCode", EmitDefaultValue = false, Order = 13)]
        public string OfficeCode { get; set; }

        public static WSAssetCAStaffPerson FromEntityModel(AssetCAStaffPersonModel assetCAStaffPersonModel)
        {
            WSAssetCAStaffPerson wsAssetCAStaffPerson = null;
            if (assetCAStaffPersonModel != null)
            {
                wsAssetCAStaffPerson = new WSAssetCAStaffPerson();
                wsAssetCAStaffPerson.Id = assetCAStaffPersonModel.Identifier;
                wsAssetCAStaffPerson.Display = assetCAStaffPersonModel.Display;

                wsAssetCAStaffPerson.FirstName = assetCAStaffPersonModel.FirstName;
                wsAssetCAStaffPerson.LastName = assetCAStaffPersonModel.LastName;
                wsAssetCAStaffPerson.AuditStatus = assetCAStaffPersonModel.AuditStatus;
                wsAssetCAStaffPerson.ServiceProviderCode = assetCAStaffPersonModel.ServiceProviderCode;
                wsAssetCAStaffPerson.UserID = assetCAStaffPersonModel.UserID;
                wsAssetCAStaffPerson.AgencyCode = assetCAStaffPersonModel.AgencyCode;
                wsAssetCAStaffPerson.BureauCode = assetCAStaffPersonModel.BureauCode;
                wsAssetCAStaffPerson.DivisionCode = assetCAStaffPersonModel.DivisionCode;
                wsAssetCAStaffPerson.SectionCode = assetCAStaffPersonModel.SectionCode;
                wsAssetCAStaffPerson.GroupCode = assetCAStaffPersonModel.GroupCode;
                wsAssetCAStaffPerson.OfficeCode = assetCAStaffPersonModel.OfficeCode;       
            }
            return wsAssetCAStaffPerson;
        }

        public static AssetCAStaffPersonModel ToEntityModel(WSAssetCAStaffPerson wsAssetCAStaffPerson)
        {
            AssetCAStaffPersonModel assetCAStaffPersonModel = null;
            if (wsAssetCAStaffPerson != null)
            {
                assetCAStaffPersonModel = new AssetCAStaffPersonModel();
                assetCAStaffPersonModel.Identifier = wsAssetCAStaffPerson.Id;
                assetCAStaffPersonModel.Display = wsAssetCAStaffPerson.Display;
                assetCAStaffPersonModel.FirstName = wsAssetCAStaffPerson.FirstName;
                assetCAStaffPersonModel.LastName = wsAssetCAStaffPerson.LastName;
                assetCAStaffPersonModel.AuditStatus = wsAssetCAStaffPerson.AuditStatus;
                assetCAStaffPersonModel.ServiceProviderCode = wsAssetCAStaffPerson.ServiceProviderCode;
                assetCAStaffPersonModel.UserID = wsAssetCAStaffPerson.UserID;
                assetCAStaffPersonModel.AgencyCode = wsAssetCAStaffPerson.AgencyCode;
                assetCAStaffPersonModel.BureauCode = wsAssetCAStaffPerson.BureauCode;
                assetCAStaffPersonModel.DivisionCode = wsAssetCAStaffPerson.DivisionCode;
                assetCAStaffPersonModel.SectionCode = wsAssetCAStaffPerson.SectionCode;
                assetCAStaffPersonModel.GroupCode = wsAssetCAStaffPerson.GroupCode;
                assetCAStaffPersonModel.OfficeCode = wsAssetCAStaffPerson.OfficeCode;
            }
            return assetCAStaffPersonModel;
        }
    }
}
