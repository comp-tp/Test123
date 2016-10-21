using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace Accela.Apps.Apis.WSModels
{
    public static class WSResponseHandler
    {
        public static WSSystem GetOKResponse()
        {
            var wsSystem = new WSSystem();
            wsSystem.Status = (int)HttpStatusCode.OK;
            return wsSystem;
        }
    }
}
