
using Accela.Core.Converter;
using Accela.Core.Converter.Default;
using Accela.Core.Serialization;
using Accela.Core.Serialization.DataContract;
using Accela.Core.Serialization.JsonNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Ioc
{
    public class DefaultServiceLoader : IServiceLoader
    {
        public int SortOrder
        {
            //should be loaded before everyone else
            get { return Int32.MinValue; }
        }

        public void Load(IServiceLocator container)
        {
            container.Register<IConverterService, DefaultConverterService>(ServiceLifecycle.Singleton);
            container.Register<IJsonSerializer, JsonNetSerializer>(ServiceLifecycle.Singleton);
            container.Register<IBinarySerializer, BsonNetSerializer>(ServiceLifecycle.Singleton);
            container.Register<IXmlSerializer, XmlDataContractSerializer>(ServiceLifecycle.Singleton);

        }
    }
}
