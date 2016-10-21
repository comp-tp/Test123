using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Accela.Apps.Apis.WSModels.Parcels
{
    [DataContract(Name = "parcelSearchRequest")]
    public class WSParcelsSearchRequest : WSRequestBase
    {
        [DataMember(Name = "filter", EmitDefaultValue = false)]
        public WSParcelFilter ParcelFilter { get; set; }

    }
}
