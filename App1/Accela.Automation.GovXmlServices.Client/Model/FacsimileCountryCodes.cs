using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FacsimileCountryCodes.
	/// </summary>
	/// 
	[XmlType(Namespace="http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL", TypeName = "facsimileCountryCodes")]
	public class FacsimileCountryCodes
	{
		public FacsimileCountryCodes()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "String", IsNullable = true)]
		public string[] str;
	}
}
