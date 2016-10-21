using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Core.Ioc;

namespace Accela.Core.Serialization
{
    public static class BinarySerializerService
    {
        public static IBinarySerializer Current { get; set; }

        static BinarySerializerService()
        {
            BinarySerializerService.Current = IocContainer.Resolve<IBinarySerializer>();
        }
    }
}
