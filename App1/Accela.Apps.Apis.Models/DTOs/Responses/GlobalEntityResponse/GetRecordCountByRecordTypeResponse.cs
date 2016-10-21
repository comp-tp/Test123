using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Models.DTOs.Responses.GlobalEntityResponse
{
    public class GetRecordCountByRecordTypeResponse : ResponseBase
    {
        public Dictionary<string, int> RecordNumCounts { get; set; }
    }
}
