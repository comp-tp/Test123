#region Header

/**
 * <pre>
 *
 *  Accela Mobile Office
 *  File:
 *
 *  Accela, Inc.
 *  Copyright (C): 2009-2010
 *
 *  Description:
 *
 *
 *  Note
 *  Created By: Code generator
 *
 * </pre>
 */

#endregion Header

using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    /// <summary>
    /// Summary description for License.
    /// </summary>
    public class License
    {
        public License()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        [XmlElement(ElementName = "licenseType")]
        public string licenseType;

        [XmlElement(ElementName = "LicenseTypeId")]
        public Enumeration AMOLicenseType;

        [XmlElement(ElementName = "licenseNumber")]
        public string licenseNumber;

        [XmlElement(ElementName = "issuedDate")]
        public string issuedDate;

        [XmlElement(ElementName = "expirationDate")]
        public string expirationDate;

        [XmlElement(ElementName = "issuedBy")]
        public Organization[] issuedBy;

        [XmlAttribute(AttributeName = "action")]
        public string action;
    }
}
