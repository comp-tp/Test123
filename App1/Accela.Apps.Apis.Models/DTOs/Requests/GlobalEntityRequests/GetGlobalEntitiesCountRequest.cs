using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.GlobalEntityRequests
{
    public class GetGlobalEntitiesCountRequest : RequestBase
    {
        public DateTime OpenedDateFrom { get; set; }

        public DateTime OpenedDateTo { get; set; }

        public DateTime UpdatedDateFrom { get; set; }

        public DateTime UpdatedDateTo { get; set; }

        public string Statuses { get; set; }

        public string Agency { get; set; }

        public string EntityType { get; set; }

        public string Enviromment { get; set; }

    }
}
