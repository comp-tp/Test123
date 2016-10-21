using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
	/// <summary>
	/// Summary description for Identifier.
	/// </summary>
	public class Identifier
	{
		public Identifier()
		{
		}
    [XmlElement(ElementName = "Keys")]
    public Keys keys;

    [XmlElement(ElementName = "IdentifierDisplay")]
    public string identifierDisplay;

    [XmlElement(ElementName = "Value")]
    public string val;
	}
}
