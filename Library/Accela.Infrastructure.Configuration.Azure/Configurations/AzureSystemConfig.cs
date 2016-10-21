using Accela.Infrastructure.Configurations;
using System;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace Accela.Infrastructure.Configuration.Azure.Configurations
{
    public class AzureSystemConfig : ISystemConfig
    {
        public string GetInstanceId()
        {
            try
            {
                // this is azure dependency, due to close to release, quick do it, need to refactor to decouple azure dependency after 3.4 release. t
                if (RoleEnvironment.IsAvailable)
                {
                    return RoleEnvironment.CurrentRoleInstance.Id;
                }
            }
            catch (Exception ex)
            {
            }

            return string.Empty;
        }
    }
}
