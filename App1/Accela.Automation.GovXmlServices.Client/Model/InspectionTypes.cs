using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectionTypes.
	/// </summary>
	public class InspectionTypes
	{
		public InspectionTypes()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "InspectionType")]
		public InspectionType[] inspectionType;
	}
}
