using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract]
    public class WSInspectorAppStaffPerson : WSDataModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
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

        /// <summary>
        /// Convert StaffPersonModel to WSStaffPerson.
        /// </summary>
        /// <param name="staffPersonModel">StaffPersonModel.</param>
        /// <returns>WSStaffPerson.</returns>
        public static WSInspectorAppStaffPerson FromEntityModel(StaffPersonModel staffPersonModel)
        {
            if (staffPersonModel != null)
            {
                return new WSInspectorAppStaffPerson
                {
                    Id = staffPersonModel.Identifier,
                    Display = staffPersonModel.Display,
                    AgencyCode = staffPersonModel.AgencyCode,
                    AuditStatus = staffPersonModel.AuditStatus,
                    BureauCode = staffPersonModel.BureauCode,
                    DivisionCode = staffPersonModel.DivisionCode,
                    FirstName = staffPersonModel.FirstName,
                    GroupCode = staffPersonModel.GroupCode,
                    LastName = staffPersonModel.LastName,
                    OfficeCode = staffPersonModel.OfficeCode,
                    SectionCode = staffPersonModel.SectionCode,
                    ServiceProviderCode = staffPersonModel.ServiceProviderCode,
                    UserStatus = staffPersonModel.UserStatus,
                };
            }
            return null;
        }

        /// <summary>
        /// Convert WSStaffPerson to StaffPersonModel.
        /// </summary>
        /// <param name="wsStaffPerson">WSStaffPerson.</param>
        /// <returns>StaffPersonModel.</returns>
        public static StaffPersonModel ToEntityModel(WSInspectorAppStaffPerson wsStaffPerson)
        {
            if (wsStaffPerson != null)
            {
                return new StaffPersonModel()
                {
                    Identifier = wsStaffPerson.Id,
                    Display = wsStaffPerson.Display,
                    AgencyCode = wsStaffPerson.AgencyCode,
                    AuditStatus = wsStaffPerson.AuditStatus,
                    BureauCode = wsStaffPerson.BureauCode,
                    DivisionCode = wsStaffPerson.DivisionCode,
                    FirstName = wsStaffPerson.FirstName,
                    GroupCode = wsStaffPerson.GroupCode,
                    LastName = wsStaffPerson.LastName,
                    OfficeCode = wsStaffPerson.OfficeCode,
                    SectionCode = wsStaffPerson.SectionCode,
                    ServiceProviderCode = wsStaffPerson.ServiceProviderCode,
                    UserStatus = wsStaffPerson.UserStatus,
                };
            };
            return null;
        }

        public static StaffPersonModel ToEntityModel(string staffId)
        {
            if (!string.IsNullOrEmpty(staffId))
            {
                return new StaffPersonModel()
                {
                    Identifier = staffId
                };
            };
            return null;
        }
    }
}
