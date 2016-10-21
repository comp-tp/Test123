using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.ReferenceModels
{
    [DataContract]
    public class StaffPersonModel : DataModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// The agency code
        /// </summary>
        [DataMember(Name = "agencyCode", EmitDefaultValue = false)]
        public string AgencyCode { get; set; }

        /// <summary>
        /// The audit status
        /// </summary>
        [DataMember(Name = "auditStatus", EmitDefaultValue = false)]
        public string AuditStatus { get; set; }

        /// <summary>
        /// The bureau code
        /// </summary>
        [DataMember(Name = "bureauCode", EmitDefaultValue = false)]
        public string BureauCode { get; set; }

        /// <summary>
        /// The division ocde
        /// </summary>
        [DataMember(Name = "divisionCode", EmitDefaultValue = false)]
        public string DivisionCode { get; set; }

        /// <summary>
        /// The first name
        /// </summary>
        [DataMember(Name = "firstName", EmitDefaultValue = false)]
        public string FirstName { get; set; }

        /// <summary>
        /// The group code
        /// </summary>
        [DataMember(Name = "groupCode", EmitDefaultValue = false)]
        public string GroupCode { get; set; }


        /// <summary>
        /// The last name
        /// </summary>
        [DataMember(Name = "lastName", EmitDefaultValue = false)]
        public string LastName { get; set; }

        /// <summary>
        /// The office code.
        /// </summary>
        [DataMember(Name = "officeCode", EmitDefaultValue = false)]
        public string OfficeCode { get; set; }

        /// <summary>
        /// The section code.
        /// </summary>
        [DataMember(Name = "sectionCode", EmitDefaultValue = false)]
        public string SectionCode { get; set; }

        /// <summary>
        /// The service provider code.
        /// </summary>
        [DataMember(Name = "serviceProviderCode", EmitDefaultValue = false)]
        public string ServiceProviderCode { get; set; }

        /// <summary>
        /// The user status.
        /// </summary>
        [DataMember(Name = "userStatus", EmitDefaultValue = false)]
        public string UserStatus { get; set; }
    }
}
