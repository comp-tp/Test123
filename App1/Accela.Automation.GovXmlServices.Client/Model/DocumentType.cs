using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
     /// <summary>
    /// Summary description for DocumentType.
    /// </summary>
    public class DocumentType : element
    {
        public DocumentType()
        {
        }

        [XmlElement(ElementName = "ContextType")]
        public string contextType;

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        [XmlElement(ElementName = "AutoDownload")]
        public bool autoDownload;

        [XmlElement(ElementName = "Description")]
        public string description;

    }

    public class DocumentTypes : ElementList
    {
        public DocumentTypes()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [XmlElement(ElementName = "DocumentType")]
        public DocumentType[] DocumentType;

    }
}