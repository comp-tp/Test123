using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for ThePerson.
	/// </summary>
	/// 
	[XmlType(Namespace="http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL", TypeName = "thePerson")]
	public class ThePerson
	{
		public ThePerson()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Person")]
		public Person person;
	}
}
