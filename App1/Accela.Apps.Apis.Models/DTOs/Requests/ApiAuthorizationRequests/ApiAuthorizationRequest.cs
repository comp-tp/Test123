using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.ApiAuthorizationRequests
{
    public class ApiAuthorizationRequest
    {
        public Guid CloudUserId { get; set; }
        public string UriTemplate { get; set; }
        public string HttpMethod { get; set; }
    }
}
