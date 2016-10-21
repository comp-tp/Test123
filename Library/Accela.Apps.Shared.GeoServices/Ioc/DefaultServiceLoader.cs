using Accela.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.GeoServices.Ioc
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
            container.Register<IGeocodeRepository, EsriGeocodeRepository>(ServiceLifecycle.Singleton);
       
        }
    }
}
