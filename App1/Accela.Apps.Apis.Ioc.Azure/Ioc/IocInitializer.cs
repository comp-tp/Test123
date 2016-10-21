using Accela.Core.Ioc;
using Accela.Core.Ioc.SimpleInjector;
using Accela.Infrastructure.Azure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.Ioc
{
    public class IocInitializer
    {
        public static void Initialize()
        {
            // don't remove below dummy code, it fixes an issue that servicebus dll can not be copied to Accela.Apps.Admin.Portal.SQLServer bin folder
            // see http://stackoverflow.com/questions/15816769/dependent-dll-is-not-getting-copied-to-the-build-output-folder-in-visual-studio
            Microsoft.ServiceBus.TokenProvider dummyForDllCopy;

            var configurationReader = new AzureConfigurationReader();
            IocContainer.Current = new ServiceLocator(configurationReader);
        }
    }
}
