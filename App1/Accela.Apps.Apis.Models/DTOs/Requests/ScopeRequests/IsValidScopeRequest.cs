using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.ScopeRequests
{
    public class IsValidScopeRequest
    {
        public string[] ScopesInToken { get; set; }
        public string RequestScope { get; set; }
    }
}
