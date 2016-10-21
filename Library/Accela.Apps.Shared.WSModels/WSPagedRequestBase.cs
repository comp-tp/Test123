using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Shared.WSModels
{
    [Serializable]
    [DataContract]
    public class WSPagedRequestBase : WSRequestBase
    {
        public int Offset { get; set; }

        public int Limit { get; set; }
    }
}
