using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Parcels
{
    [DataContract(Name = "filter")]
    public class WSParcelFilter
    {
        [DataMember(Name = "ids", EmitDefaultValue = false)]
        public List<string> ParcelIds { get; set; }

        [DataMember(Name = "number", EmitDefaultValue = false)]
        public string Number { get; set; }

        [DataMember(Name = "fraction", EmitDefaultValue = false)]
        public string Fraction { get; set; }

        [DataMember(Name = "prefix", EmitDefaultValue = false)]
        public string Prefix { get; set; }

        [DataMember(Name = "street", EmitDefaultValue = false)]
        public string Street { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "suffix", EmitDefaultValue = false)]
        public string Suffix { get; set; }

        [DataMember(Name = "unit", EmitDefaultValue = false)]
        public string Unit { get; set; }

        [DataMember(Name = "unitType", EmitDefaultValue = false)]
        public string UnitType { get; set; }

        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        [DataMember(Name = "zipCode", EmitDefaultValue = false)]
        public string ZipCode { get; set; }

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

        [DataMember(Name = "layerId")]
        public string LayerId
        {
            get;
            set;
        }
    }
}
