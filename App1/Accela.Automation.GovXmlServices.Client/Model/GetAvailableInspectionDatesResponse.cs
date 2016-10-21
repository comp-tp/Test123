using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class GetAvailableInspectionDatesResponse
    {
        public GetAvailableInspectionDatesResponse()
		{
		}

        [XmlElement(ElementName = "System")]
        public Sys system;

        [XmlElement(ElementName = "availableDate")]
        public string[] availableDate;
    }
}
