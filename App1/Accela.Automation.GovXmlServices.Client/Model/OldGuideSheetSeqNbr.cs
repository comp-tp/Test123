using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Accela.Automation.GovXmlClient.Model
{
    public class OldGuideSheetSeqNbr
    {
        [XmlElement(ElementName = "Keys", IsNullable=true)]
        public Keys keys;
    }
}
