#region Header

/**
* <pre>
*
*  Accela Mobile Office
*  File: Document.cs
*
*  Accela, Inc.
*  Copyright (C): 2009-2010
*
*  Description:
*  Create By TIM-XU
*  Notes:

*  Revision History:
*  Date                  Who                What
* </pre>
*/

#endregion Header

using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	public class Document
	{
		public Document()
		{
		}
		[XmlElement(ElementName = "globalId", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public string globalId;
		
		[XmlElement(ElementName = "ownerHistory", Namespace = "http://www.iai-international.org/ifcXML/ifc2x/IFC2X_FINAL")]
		public string ownerHistory;

		[XmlElement(ElementName = "Options")]
		public Options Options;
		
		[XmlElement(ElementName = "Keys")]
		public Keys Keys;
		
		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;
		
		[XmlElement(ElementName = "contextType")]
		public string contextType;
		
		[XmlElement(ElementName = "autodownload")]
		public string autodownload;

		[XmlElement(ElementName = "CAPId")]
		public CAPId capId;
		
		[XmlElement(ElementName = "InspectionId")]
		public InspectionId inspectionId;
		
		[XmlElement(ElementName = "Type")]
		public Type type;
		
		[XmlElement(ElementName = "Description")]
		public string description;
		
		[XmlElement(ElementName = "Date")]
		public string date;
		
		[XmlElement(ElementName = "Time")]
		public string time;
		
		[XmlElement(ElementName = "Status")]
		public Status status;
		
		[XmlElement(ElementName = "DocumentLocators")]
		public DocumentLocators documentLocators;
		
		[XmlElement(ElementName = "AdditionalInformation")]
		public AdditionalInformation additionalInformation;

		[XmlElement(ElementName = "content")]
		public string content;

        [XmlElement(ElementName = "EDMSAdapter")]
        public EDMSAdapter EDMSAdapter;

        [XmlElement(ElementName = "displayImage")]
        public string displayImage;
	}
}
