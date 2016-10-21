using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class Modules
    {
        public Modules()
        {
        }

        [XmlElement(ElementName = "Module", IsNullable = true)]
        public Module[] Module;
    }
}
