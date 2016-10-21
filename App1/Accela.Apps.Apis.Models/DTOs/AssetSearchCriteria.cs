using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs
{
    [DataContract]
    public class AssetSearchCriteria
    {
        [DataMember(Name = "gisObjects", EmitDefaultValue = false)]
        public List<AssetGisObject> GisObjects { get; set; }
    }

    [DataContract(Name = "gisObject")]
    public class AssetGisObject
    {
        [DataMember(Name = "id")]
        public string ID { get; set; }

        [DataMember(Name = "mapService")]
        public string MapService { get; set; }

        [DataMember(Name = "gisLayer")]
        public string GISLayer { get; set; }
    }
}
