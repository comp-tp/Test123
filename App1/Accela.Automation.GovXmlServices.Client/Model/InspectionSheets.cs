using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectionSheets.
	/// </summary>
	public class InspectionSheets
	{
		public InspectionSheets()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="InspectionSheet")]
		public InspectionSheet[] inspectionSheet;
	}
}
