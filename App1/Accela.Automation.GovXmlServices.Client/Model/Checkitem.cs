using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Checkitem.
	/// </summary>
	/// 
	
	public class Checkitem
	{
		public Checkitem()
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

		[XmlElement(ElementName = "Description")]
		public string description;

		[XmlElement(ElementName = "Date")]
		public string date;

		[XmlElement(ElementName = "DataType")]
		public DataType dataType;

		[XmlElement(ElementName = "Value")]
		public string val;

		[XmlElement(ElementName = "RecordedBy")]
		public string recordedBy;

	}
}
