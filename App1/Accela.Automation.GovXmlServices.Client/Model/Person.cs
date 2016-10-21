#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: Person.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By WINSEAN-WANG at 4/16/2009 3:30:18 PM

*  Revision History:
*  Date                  Who                What
*  2009/05/21            Winsean Wang       Added fullName property
* </pre>
*/

#endregion Header

namespace Accela.Automation.GovXmlClient.Model
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// Summary description for Person.
    /// </summary>
    /// 
    [XmlType(Namespace="http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
    public class Person
    {
        [XmlElement(ElementName = "id")]
        public string id;

        [XmlElement(ElementName = "familyName")]
        public string familyName;

        [XmlElement(ElementName = "givenName")]
        public string givenName;

        [XmlElement(ElementName = "middleNames")]
        public MiddleNames middleNames;

        [XmlElement(ElementName = "roles")]
        public roles_ifc roles;

        [XmlElement(ElementName = "addresses")]
        public Addresses addresses;

        [XmlElement(ElementName = "OwnerAddress")]
        public OwnerAddress OwnerAddress;

        //Author:Liner Lin
        //Date:2008-12-19
        //Desc:Bug 8474 Parcel contact full name not return to AW 
        [XmlElement(ElementName = "fullName")]
        public string fullName;

        [XmlElement(ElementName = "businessName")]
        public string contactBusinessName;

        [XmlElement(ElementName = "email")]
        public string email;

        [XmlElement(ElementName = "businessName1")]
        public string businessName1;
    }
}