using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for PersonAndOrganization.
	/// </summary>
	/// 
	[XmlType(Namespace="http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
	public class PersonAndOrganization
	{
		public PersonAndOrganization()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "thePerson")]
		public ThePerson thePerson;

		[XmlElement(ElementName = "theOrganization")]
		public TheOrganization theOrganization;

		[XmlElement(ElementName = "roles")]
		public roles_ifc roles;
	}
}
