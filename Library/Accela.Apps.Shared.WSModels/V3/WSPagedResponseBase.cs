﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Shared.WSModels
{
    [Serializable]
    [DataContract]
    public class WSPagedResponseBase : WSResponseBase
    {
        [DataMember(Name = "page", EmitDefaultValue = false, Order = 2)]
        public WSPagination PageInfo
        {
            get;
            set;
        }
    }
}