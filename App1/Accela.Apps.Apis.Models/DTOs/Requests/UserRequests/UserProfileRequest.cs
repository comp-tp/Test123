using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.UserRequest
{
    public class UserProfileRequest : RequestBase
    {
        public string AgencyName { get; set; }
    }
}
