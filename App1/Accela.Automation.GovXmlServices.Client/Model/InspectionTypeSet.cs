using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for InspectionTypeSet.
	/// </summary>
	public class InspectionTypeSet
	{
		public InspectionTypeSet()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="InspectionTypes")]
		public InspectionTypes inspectionTypes;

		[XmlElement(ElementName="Keys")]
		public Keys keys;

		[XmlElement(ElementName="IdentifierDisplay")]
		public string identifierDisplay;

        [XmlElement(ElementName = "StandardCommentsGroupIds")]
        public StandardCommentsGroupIds standardCommentsGroupIds;
	}
}
