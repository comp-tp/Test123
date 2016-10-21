using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectionDistricts.
	/// </summary>
	public class InspectionDistricts
	{
		public InspectionDistricts()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="InspectionDistrict")]
		public InspectionDistrict[] inspectionDistrict;
	}
}
