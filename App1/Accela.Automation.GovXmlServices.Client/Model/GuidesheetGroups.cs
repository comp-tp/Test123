using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class GuidesheetGroups
    {
        [XmlElement(ElementName = "GuidesheetGroup")]
        public GuidesheetGroup[] guidesheetGroups;
    }
}
