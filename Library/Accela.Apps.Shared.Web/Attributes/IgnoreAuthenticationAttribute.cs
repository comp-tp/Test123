using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accela.Apps.Shared.Web.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class IgnoreAuthenticationAttribute : Attribute
    {
        public IgnoreAuthenticationAttribute()
        {
        }
    }
}