using Accela.Core.Ioc;
using Accela.Automation.GovXmlClient.Model.Communicators;
using Accela.Automation.GovXmlServices.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Automation.GovXmlClient.Ioc
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
            container.Register<ICommunicator, GovXmlCommunicator>(ServiceLifecycle.PerCall);
        }
    }
}
