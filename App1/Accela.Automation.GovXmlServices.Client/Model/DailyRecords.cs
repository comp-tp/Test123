using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Accela.Automation.GovXmlServices.Client.Model;

namespace Accela.Automation.GovXmlClient.Model
{
    public class DailyRecords
    {
        public DailyRecords()
        {
        }

        [XmlElement(ElementName = "DailyRecord", IsNullable = true)]
        public DailyRecord[] DailyRecord;
    }
}
