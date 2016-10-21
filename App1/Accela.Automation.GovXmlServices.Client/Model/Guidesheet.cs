using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Guidesheet.
	/// </summary>
	public class Guidesheet
	{
		public Guidesheet()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName = "globalId", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public string globalId;
		
		[XmlElement(ElementName = "ownerHistory", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public string ownerHistory;

		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName = "contextType")]
		public string contextType;

		[XmlElement(ElementName = "Type")]
		public Type type;

		[XmlElement(ElementName = "Label")]
		public string label;

		[XmlElement(ElementName = "Description")]
		public string description;

		[XmlElement(ElementName = "Date")]
		public string date;

		[XmlElement(ElementName = "Time")]
		public string time;

		[XmlElement(ElementName = "Guideitems")]
		public Guideitems guideitems;

//		[XmlElement(ElementName = "Text")]
//		public string text;

		[XmlElement(ElementName = "RecordedBy")]
		public string recordedBy;

		[XmlElement(ElementName = "EnumerationLists")]
		public EnumerationLists enumerationLists;

        [XmlElement(ElementName = "StandardCommentsGroupIds")]
        public StandardCommentsGroupIds standardCommentsGroups;

        [XmlElement(ElementName = "GuidesheetGroups")]
        public GuidesheetGroups guidesheetGroups;

        [XmlElement(ElementName = "OldGuideSheetSeqNbr", IsNullable=true)]
        public OldGuideSheetSeqNbr oldGuideSheetSeqNbr;
	}
}
