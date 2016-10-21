#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: UserRolePrivilege.cs
*
*  Accela, Inc.
*  Copyright (C): 2011
*
*  Description:
*  Create By Jaison Yang
*  Notes:
* </pre>
*/

#endregion Header

namespace Accela.Automation.GovXmlClient.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class UserRolePrivilege
    {
        /// <summary>
        /// User rele privilege
        /// </summary>
        public UserRolePrivilege()
        {
        }

        [XmlElement(ElementName = "allAcaUserAllowed")]
        public string isAllAcaUserAllowed;

        [XmlElement(ElementName = "capCreatorAllowed")]
        public string isCapCreatorAllowed;

        [XmlElement(ElementName = "licenseProfessionalAllowed")]
        public string isLicenseProfessionalAllowed;

        [XmlElement(ElementName = "contactAllowed")]
        public string isContactAllowed;

        [XmlElement(ElementName = "ownerAllowed")]
        public string isOwnerAllowed;
    }
}
