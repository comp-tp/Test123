using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.ChecklistRequests
{
    public class GetChecklistRequest : RequestBase
    {
        public string GroupID { get; set; }
    }
}
