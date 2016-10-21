using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Automation.GovXmlClient.Model;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlServices.Client.Model
{
    public class DailyRecord
    {
        public DailyRecord()
        {
        }

        [XmlElement(ElementName = "Day", IsNullable = true)]
        public int? Day;

        [XmlElement(ElementName = "Modules", IsNullable = true)]
        public Modules Modules;
    }
}
