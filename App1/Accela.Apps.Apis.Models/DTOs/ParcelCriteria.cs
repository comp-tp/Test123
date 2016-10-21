using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs
{
    [DataContract]
    public class ParcelCriteria
    {
        [DataMember(Name = "parcelIds", EmitDefaultValue = false)]
        public List<string> ParcelIds { get; set; }

        [DataMember(Name = "recordId", EmitDefaultValue = false)]
        public string RecordId { get; set; }

        [DataMember(Name = "recordStatus", EmitDefaultValue = false)]
        public string RecordStatus { get; set; }

        [DataMember(Name = "addressNumber", EmitDefaultValue = false)]
        public string AddressNumber { get; set; }

        [DataMember(Name = "addressFraction", EmitDefaultValue = false)]
        public string AddressFraction { get; set; }

        [DataMember(Name = "addressPrefix", EmitDefaultValue = false)]
        public string AddressPrefix { get; set; }

        [DataMember(Name = "addressStreet", EmitDefaultValue = false)]
        public string AddressStreet { get; set; }

        [DataMember(Name = "addressType", EmitDefaultValue = false)]
        public string AddressType { get; set; }

        [DataMember(Name = "addressSuffix", EmitDefaultValue = false)]
        public string AddressSuffix { get; set; }

        [DataMember(Name = "addressUnit", EmitDefaultValue = false)]
        public string AddressUnit { get; set; }

        [DataMember(Name = "addressUnitType", EmitDefaultValue = false)]
        public string AddressUnitType { get; set; }

        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        [DataMember(Name = "zip", EmitDefaultValue = false)]
        public string Zip { get; set; }

        [DataMember(Name = "tract", EmitDefaultValue = false)]
        public string Tract { get; set; }

        [DataMember(Name = "block", EmitDefaultValue = false)]
        public string Block { get; set; }

        [DataMember(Name = "lot", EmitDefaultValue = false)]
        public string Lot { get; set; }

        [DataMember(Name = "ownerFirstName", EmitDefaultValue = false)]
        public string OwnerFirstName { get; set; }

        [DataMember(Name = "ownerMiddleName", EmitDefaultValue = false)]
        public string OwnerMiddleName { get; set; }

        [DataMember(Name = "ownerLastName", EmitDefaultValue = false)]
        public string OwnerLastName { get; set; }

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
