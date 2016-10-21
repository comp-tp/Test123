using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Core.Ioc;

namespace Accela.Core.Serialization
{
    public static class XmlSerializerService
    {
        public static IXmlSerializer Current { get; set; }

        static XmlSerializerService()
        {
            XmlSerializerService.Current = IocContainer.Resolve<IXmlSerializer>();
        }
    }
}
