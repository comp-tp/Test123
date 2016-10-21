using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.Models.DomainModels.AssetModels
{
    public class AssetCAModel : IdentifierBase
    {
        public CAAssetModel CAAsset { get; set; }

        public AssetModel Asset { get; set; }
       
        public AssetCAStatusModel Status { get; set; }
      
        public AssetCATypeModel Type { get; set; }
 
        public string ScheduleDate { get; set; }
     
        public string ScheduleTime { get; set; }
   
        public string InspectionDate { get; set; }
  
        public string InspectionTime { get; set; }
     
        public AssetCADepartmentModel Department { get; set; }
       
        public AssetCAStaffPersonModel StaffPerson { get; set; }

        public string TimeSpent { get; set; }
      
        public string Comment { get; set; }

        public List<AdditionalGroupModel> AdditionalInformations { get; set; }

        public List<AdditionalTableModel> Observations { get; set; }

    }
}
