using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class CountDailyRecordsResponse : OperationResponse
    {
        [XmlElement(ElementName = "DailyRecords")]
        public DailyRecords DailyRecords;
    }
}
