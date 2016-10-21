using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectionSheet.
	/// </summary>
	public class InspectionSheet
	{
		public InspectionSheet()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="Inspections")]
		public Inspections inspections;

		[XmlElement(ElementName="IdentifierDisplay")]
		public string identifierDisplay;
	}
}
