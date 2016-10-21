using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class TextDefaults
    {
        public TextDefaults()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        [XmlElement(ElementName = "TextDefault")]
        public TextDefault[] TextDefault;
    }   
}
