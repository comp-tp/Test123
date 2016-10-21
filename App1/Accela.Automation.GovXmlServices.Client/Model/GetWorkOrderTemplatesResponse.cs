using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Accela.Automation.GovXmlClient.Model;
using Accela.Automation.GovXmlServices.Client.Model;

namespace Accela.Automation.GovXmlClient.Model
{
    /// <summary>
    /// Get Work Order Template Response.
    /// </summary>
    public class GetWorkOrderTemplatesResponse
    {
        public GetWorkOrderTemplatesResponse()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [XmlElement(ElementName = "System")]
        public Sys system;

        [XmlElement(ElementName = "WorkOrderTemplates")]
        public WorkOrderTemplates workOrderTemplates;
    }
}
