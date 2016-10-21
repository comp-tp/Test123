using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Records
{
    [DataContract]
    public class WSBBox
    {
        [DataMember(Name = "xMax", EmitDefaultValue = false)]
        public string XMax { get; set; }

        [DataMember(Name = "xMin", EmitDefaultValue = false)]
        public string XMin { get; set; }

        [DataMember(Name = "yMax", EmitDefaultValue = false)]
        public string YMax { get; set; }

        [DataMember(Name = "yMin", EmitDefaultValue = false)]
        public string YMin { get; set; }
    }
}
