using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Core
{
    public static class ValidationAttributeExtensions
    {
        public static ResourceManager GetResourceManager(this ValidationAttribute instance, ResourceManager defaultResourceManager = null)
        {
            ResourceManager rm = null;

            if (instance.ErrorMessageResourceType != null)
                rm = instance.ErrorMessageResourceType.GetProperty("ResourceManager", 
                    BindingFlags.Static | BindingFlags.Public | BindingFlags.GetProperty).GetValue(null) as ResourceManager;

            return (rm == null)
                ? defaultResourceManager : rm;
        }
    }
}
