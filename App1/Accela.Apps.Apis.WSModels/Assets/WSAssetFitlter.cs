using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Assets
{
    [DataContract(Name = "filter")]
    public class WSAssetFitlter
    {
        [DataMember(Name = "gisObjects", EmitDefaultValue = false)]
        public List<GisObject> GisObjects { get; set; }
    }

    [DataContract(Name = "gisObject")]
    public class GisObject
    {
        [DataMember(Name = "id")]
        public string ID { get; set; }

        [DataMember(Name = "mapService")]
        public string MapService { get; set; }

        [DataMember(Name = "gisLayer")]
        public string GISLayer { get; set; }
    }
}
