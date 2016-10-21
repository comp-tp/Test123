using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.EnvironmentRequests
{
    public class UpdateEnvironmentServerRequest : RequestBase
    {        
        public Guid ID { get; set; }
        
        public int? Status { get; set; }
       
        public string VersionNum { get; set; }

        public string ServerBaseUrl { get; set; }

        public int? ServerType { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string EnvironmentId { get; set; }

        public string Desc { get; set; }

    }
}
