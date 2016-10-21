using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name="department")]
    public class WSAssetCADepartment : WSIdentifierBase
    {
        [DataMember(Name="agencyCode", EmitDefaultValue = false, Order = 3)]
        public string AgencyCode { get; set;}

        [DataMember(Name="bureauCode", EmitDefaultValue = false, Order = 4)]
        public string BureauCode { get; set; }

        [DataMember(Name="divisionCode", EmitDefaultValue = false, Order = 5)]
        public string DivisionCode { get; set; }

        [DataMember(Name="sectionCode", EmitDefaultValue = false, Order = 6)]
        public string SectionCode { get; set; }

        [DataMember(Name="groupCode", EmitDefaultValue = false, Order = 7)]
        public string GroupCode { get; set; }

        [DataMember(Name="subgroupCode", EmitDefaultValue = false, Order = 8)]
        public string SubgroupCode { get; set; }

        [DataMember(Name="subgroupCodeDesc", EmitDefaultValue = false, Order = 9)]
        public string SubgroupCodeDesc { get; set; }

        [DataMember(Name="staff", EmitDefaultValue = false, Order = 10)]
        public List<WSAssetCAStaffPerson> Staff {get;set;}

        public static WSAssetCADepartment FromEntityModel(AssetCADepartmentModel assetCADepartmentModel)
        {
            WSAssetCADepartment wsAssetCADepartment = null;
            if (assetCADepartmentModel != null)
            {
                wsAssetCADepartment = new WSAssetCADepartment();
                wsAssetCADepartment.Id = assetCADepartmentModel.Identifier;
                wsAssetCADepartment.Display = assetCADepartmentModel.Display;
                wsAssetCADepartment.AgencyCode = assetCADepartmentModel.AgencyCode;
                wsAssetCADepartment.BureauCode = assetCADepartmentModel.BureauCode;
                wsAssetCADepartment.DivisionCode = assetCADepartmentModel.DivisionCode;
                wsAssetCADepartment.SectionCode = assetCADepartmentModel.SectionCode;
                wsAssetCADepartment.GroupCode = assetCADepartmentModel.GroupCode;
                wsAssetCADepartment.SubgroupCode = assetCADepartmentModel.SubgroupCode;
                wsAssetCADepartment.SubgroupCodeDesc = assetCADepartmentModel.SubgroupCodeDesc;

                if (assetCADepartmentModel.Staff != null && assetCADepartmentModel.Staff.Count > 0)
                {
                    wsAssetCADepartment.Staff = new List<WSAssetCAStaffPerson>();
                    foreach (var staff in assetCADepartmentModel.Staff)
                    {
                        wsAssetCADepartment.Staff.Add(WSAssetCAStaffPerson.FromEntityModel(staff));
                    }
                }
            }
            return wsAssetCADepartment;
        }

        public static AssetCADepartmentModel ToEntityModel(WSAssetCADepartment wsAssetCADepartment)
        {
            AssetCADepartmentModel assetCADepartmentModel = null;
            if (wsAssetCADepartment != null)
            {
                assetCADepartmentModel = new AssetCADepartmentModel();
                assetCADepartmentModel.Identifier = wsAssetCADepartment.Id;
                assetCADepartmentModel.Display = wsAssetCADepartment.Display;
                assetCADepartmentModel.AgencyCode = wsAssetCADepartment.AgencyCode;
                assetCADepartmentModel.BureauCode = wsAssetCADepartment.BureauCode;
                assetCADepartmentModel.DivisionCode = wsAssetCADepartment.DivisionCode;
                assetCADepartmentModel.SectionCode = wsAssetCADepartment.SectionCode;
                assetCADepartmentModel.GroupCode = wsAssetCADepartment.GroupCode;
                assetCADepartmentModel.SubgroupCode = wsAssetCADepartment.SubgroupCode;
                assetCADepartmentModel.SubgroupCodeDesc = wsAssetCADepartment.SubgroupCodeDesc;

                if (wsAssetCADepartment.Staff != null && wsAssetCADepartment.Staff.Count > 0)
                {
                    assetCADepartmentModel.Staff = new List<AssetCAStaffPersonModel>();
                    foreach (var staff in wsAssetCADepartment.Staff)
                    {
                        assetCADepartmentModel.Staff.Add(WSAssetCAStaffPerson.ToEntityModel(staff));
                    }
                }
            }
            return assetCADepartmentModel;
        }
    }
}
