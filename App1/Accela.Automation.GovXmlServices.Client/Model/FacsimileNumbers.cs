using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FacsimileNumbers.
	/// </summary>
	/// 
	[XmlType(Namespace="http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL", TypeName = "facsimileNumbers")]
	public class FacsimileNumbers
	{
		public FacsimileNumbers()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "String", IsNullable = true)]
		public string[] str;
	}
}
