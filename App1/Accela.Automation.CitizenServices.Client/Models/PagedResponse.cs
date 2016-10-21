using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models
{
    [DataContract(Name = "pagedResponse")]
    public class PagedResponse : ResponseBase
    {
        [DataMember(Name = "startRow")]
        public int startRow
        {
            get;
            set;
        }

        [DataMember(Name = "searchAllStartRow")]
        public bool searchAllStartRow
        {
            get;
            set;
        }
    }
}
