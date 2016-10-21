using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// This object is a succint encapsulation of a CAP.  The CAP object provides a fuller set.
	/// </summary>
	/// 
	
	public class CAPId
	{
		public CAPId()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[XmlElement(ElementName = "Keys")]
		public Keys keys;

		[XmlElement(ElementName = "IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName = "Value")]
		public string val;
	}
}
