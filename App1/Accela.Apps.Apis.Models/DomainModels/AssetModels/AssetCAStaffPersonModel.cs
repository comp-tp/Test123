using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.AssetModels
{
    public class AssetCAStaffPersonModel : IdentifierBase
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AuditStatus { get; set; }

        public string ServiceProviderCode { get; set; }

        public string UserID { get; set; }

        public string AgencyCode { get; set; }

        public string BureauCode { get; set; }

        public string DivisionCode { get; set; }

        public string SectionCode { get; set; }

        public string GroupCode { get; set; }

        public string OfficeCode { get; set; }
    }
}
