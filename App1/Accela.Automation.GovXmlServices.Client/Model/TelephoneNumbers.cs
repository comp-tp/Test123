using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for TelephoneNumbers.
	/// </summary>
	/// 
	[XmlType(Namespace="http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL", TypeName = "telephoneNumbers")]
	public class TelephoneNumbers
	{
		public TelephoneNumbers()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "String", IsNullable = true)]
		public string[] str;
	}
}
