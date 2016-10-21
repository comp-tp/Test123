#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: Contact.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By TIM-XU
*  Notes:

*  Revision History:
*  Date                  Who                What
* </pre>
*/

#endregion Header

using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Contact.
	/// </summary>
	/// 
	
	public class Contact
	{
		public enum Action
		{
			[XmlEnum(Name = "")]
			Null,
			[XmlEnum(Name = "Add")]
			Add,
			[XmlEnum(Name = "Edit")]
			Edit
		}

		public Contact()
		{
			//
			// TODO: Add constructor logic here
			//
		}

	    [XmlAttribute(AttributeName = "isPrimary")] 
        public string isPrimary;
 
		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "Person", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public Person person;

		[XmlElement(ElementName = "Organization", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public Organization organization;

		[XmlElement(ElementName = "PersonAndOrganization", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public PersonAndOrganization personAndOrganization;

		[XmlElement(ElementName = "Licenses", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public Licenses licenses;

		[XmlAttribute(AttributeName="action")]
		public string action;	

	}
}
