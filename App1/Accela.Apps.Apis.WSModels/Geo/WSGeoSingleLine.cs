using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.WSModels.Geo
{
    [DataContract(Name = "geoSingleLines")]
    public class WSGeoSingleLine
    {
        [DataMember(Name = "objectID")]
        public int ObjectID { get; set; }

        [DataMember(Name = "SINGLELINEINPUT")]
        public string SingleLineInput { get; set; }
    }
}
