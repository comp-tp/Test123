using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.GeoServices.Response
{
    [DataContract(Name = "tokenResponse")]
    public class TokenResponse
    {
        [DataMember(Name = "token")]
        public string Token { get; set; }

        [DataMember(Name = "expires")]
        public string Expires { get; set; }

        [DataMember(Name = "expireTime")]
        public DateTime ExpireTime { get; set; }

        [DataMember(Name = "ssl")]
        public string SSL { get; set; }

        [DataMember(Name = "error")]
        public ESRIError Error { get; set; }
    }
}
