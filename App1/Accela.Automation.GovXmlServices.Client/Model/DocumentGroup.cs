using System;
using System.Xml.Serialization;


namespace Accela.Automation.GovXmlClient.Model
{
    public class DocumentGroup: element
    {
        public DocumentGroup()
        {
        }

        [XmlElement(ElementName = "ContextType")]
        public string contextType;

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;

        [XmlElement(ElementName = "DocumentTypes")]
        public DocumentTypes documentTypes;

    }
    public class DocumentGroups : ElementList
    {
        public DocumentGroups()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [XmlElement(ElementName = "DocumentGroup")]
        public DocumentGroup[] DocumentGroup;
    }


    public class DocumentGroupId : element
    {
        public DocumentGroupId()
        {
        }

        [XmlElement(ElementName = "ContextType")]
        public string contextType;

        [XmlElement(ElementName = "Keys")]
        public Keys keys;

        [XmlElement(ElementName = "IdentifierDisplay")]
        public string identifierDisplay;


    }

    public class DocumentGroupIds : ElementList
    {
        public DocumentGroupIds()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [XmlElement(ElementName = "DocumentGroupId")]
        public DocumentGroupId[] DocumentGroupId;

    }
}
