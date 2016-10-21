using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// In XML documents, this element actually appears as "addressLines" (lower case).  Counterpart to this class is the GovXML "AddressLines" class (under the AccelaWireless Namespace).
	/// </summary>
	/// 
	[XmlType(Namespace="http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL", TypeName = "addressLines")]
	public class AddressLinesIFC : AddressLinesBase
	{
		public AddressLinesIFC()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
}