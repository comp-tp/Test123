using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectionDistrictIds.
	/// </summary>
	public class InspectionDistrictIds
	{
		public InspectionDistrictIds()
		{
		}
    [XmlElement(ElementName="InspectionDistrictId")]
    public InspectionDistrictId[] inspectionDistrictId;
	}
}
