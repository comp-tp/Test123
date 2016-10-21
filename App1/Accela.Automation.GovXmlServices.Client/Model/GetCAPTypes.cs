using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for FGetCAPTypeListIn.
	/// </summary>
	public class GetCAPTypes
	{
		public GetCAPTypes()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "System")]
		public Sys system;

		[XmlElement(ElementName = "InspectionType")]
		public InspectionType inspectionType;

		[XmlElement(ElementName = "Licenses")]
		public Licenses licenses;

		[XmlElement(ElementName = "type")]
		public string type;

        [XmlElement(ElementName = "module")]
        public string Module;
	}
}
