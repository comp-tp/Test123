using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Accela.Apps.Apis.Services.Host.Contexts
{

    public class AgencyContextProvider
    {
        // private IAgencyAppContext _contextEntity {get;private set;}

        public static IAgencyAppContext Get()
        {
            var context = (IAgencyAppContext)CallContext.LogicalGetData("ContextEntity");

            if (context == null || context.App == null)
            {
                context = new UnKownAgencyAppContext();
            }
            if (context.ContextUser == null)
            {
                context.ContextUser = new UnKownContextUser();
            }
            return context;
        }
    }
}