using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for StandardComment.
	/// </summary>
	public class StandardComment
	{
		public StandardComment()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		[XmlElement(ElementName="Keys")]
		public Keys keys;

		[XmlElement(ElementName="IdentifierDisplay")]
		public string identifierDisplay;

		[XmlElement(ElementName="Text")]
		public string text;

		[XmlElement(ElementName="Type")]
		public Type type;
	}
}
