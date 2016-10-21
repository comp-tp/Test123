using System;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class GetWorkflow
    {
       public GetWorkflow()
       {
           
       }
       [XmlElement(ElementName = "System")]
       public Sys system;

       [XmlElement(ElementName = "CAPIds")]
       public CAPIds capIds;

       [XmlElement(ElementName = "contextType")]
       public string contextType;
    }
}
