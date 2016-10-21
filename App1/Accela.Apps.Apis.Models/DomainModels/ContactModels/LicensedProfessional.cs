using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.ContactModels
{
    [DataContract]
    public class LicensedProfessional : ActionDataModel
    {
        [DataMember(Name = "licenseType", EmitDefaultValue = false)]
        public LicenseTypeModel LicenseType { get; set; }
        [DataMember(Name = "licenseNumber", EmitDefaultValue = false)]
        public string LicenseNumber { get; set; }
        [DataMember(Name = "issuedDate", EmitDefaultValue = false)]
        public string IssuedDate { get; set; }
        [DataMember(Name = "expirationDate", EmitDefaultValue = false)]
        public string ExpirationDate { get; set; }
    }
}
