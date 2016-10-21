using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Automation.GovXmlClient.Model
{
    public class GetWorkOrderTemplates
    {
        public GetWorkOrderTemplates()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [XmlElement(ElementName = "System")]
        public Sys system;

        [XmlElement(ElementName = "contextType")]
        public string contextType;
    }
}
