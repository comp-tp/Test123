using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels
{
    [DataContract]
    public class WSPagedResponse : WSResponseBase
    {
        [DataMember(Name = "page", EmitDefaultValue = false, Order = 2)]
        public WSPagination PageInfo
        {
            get;
            set;
        }
    }
}
