using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for SpatialElement.
	/// </summary>
	public class SpatialElement
	{
		public SpatialElement()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="Keys")]
		public Keys Keys;
		
		[XmlElement(ElementName="IdentifierDisplay")]
		public string IdentifierDisplay;
		
		[XmlElement(ElementName="contextType")]
		public string contextType;
		
		[XmlElement(ElementName="Description")]
		public string Description;

		[XmlElement(ElementName="Text")]
		public string Text;
	}
}
