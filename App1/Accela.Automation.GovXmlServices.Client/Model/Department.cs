using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class Departments : ElementList
    {
        [XmlElement(ElementName = "Department")]
        public Department[] Department;
    }
    public class Department: element
    {
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        [XmlElement(ElementName = "agencyCode")]
        public string agencyCode;

        [XmlElement(ElementName = "bureauCode")]
        public string bureauCode;

        [XmlElement(ElementName = "divisionCode")]
        public string divisionCode;

        [XmlElement(ElementName = "sectionCode")]
        public string sectionCode;

        [XmlElement(ElementName = "groupCode")]
        public string groupCode;

        [XmlElement(ElementName = "subgroupCode")]
        public string subgroupCode;

        [XmlElement(ElementName = "subgroupCodeDesc")]
        public string subgroupDesc;

        [XmlElement(ElementName = "Staff")]
        public Staff Staff;
    }
    public class Staff : ElementList
    {
        [XmlElement(ElementName = "StaffPerson")]
        public StaffPerson[] StaffPerson;
    }

    public class StaffPerson : element
    {
        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        [XmlElement(ElementName = "firstName")]
        public string firstName;

        [XmlElement(ElementName = "lastName")]
        public string lastName;

        [XmlElement(ElementName = "auditStatus")]
        public string auditStatus;

        [XmlElement(ElementName = "serviceProviderCode")]
        public string serviceProviderCode;

        [XmlElement(ElementName = "userID")]
        public string userId;

        [XmlElement(ElementName = "agencyCode")]
        public string agencyCode;

        [XmlElement(ElementName = "bureauCode")]
        public string bureauCode;

        [XmlElement(ElementName = "divisionCode")]
        public string divisionCode;

        [XmlElement(ElementName = "sectionCode")]
        public string sectionCode;

        [XmlElement(ElementName = "groupCode")]
        public string groupCode;

        [XmlElement(ElementName = "officeCode")]
        public string officeCode;

        [XmlElement(ElementName = "userStatus")]
        public string userStatus;
    }
}
