using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Automation.GovXmlClient.Model;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class CountDailyRecords
    {
        public CountDailyRecords()
        {
        }

        [XmlElement(ElementName = "System")]
        public Sys system;

        [XmlElement(ElementName = "RecordType")]
        public string RecordType;

        /// <summary>
        /// multiple module pattern: A@B@C, for example, Building@CMPD@Enforcement@Licenses@Planning
        /// </summary>
        [XmlElement(ElementName = "Module")]
        public string Module;

        [XmlElement(ElementName = "DateRange")]
        public DateRange DateRange;

        [XmlElement(ElementName = "ReturnType")]
        public string ReturnType;
    }
}
