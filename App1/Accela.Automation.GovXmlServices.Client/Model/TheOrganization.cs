using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for TheOrganization.
	/// </summary>
	/// 
	[XmlType(Namespace="http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL", TypeName = "theOrganization")]
	public class TheOrganization
	{
		public TheOrganization()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Organization")]
		public Organization organization;
	}
}
