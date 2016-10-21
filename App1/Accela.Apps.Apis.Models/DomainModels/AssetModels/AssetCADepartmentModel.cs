using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.AssetModels
{
    public class AssetCADepartmentModel : IdentifierBase
    {         
        public string AgencyCode { get; set;}

        public string BureauCode { get; set; }

        public string DivisionCode { get; set; }

        public string SectionCode { get; set; }

        public string GroupCode { get; set; }

        public string SubgroupCode { get; set; }

        public string SubgroupCodeDesc { get; set; }

        public List<AssetCAStaffPersonModel> Staff {get;set;}
    }
}
