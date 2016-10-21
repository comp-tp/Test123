using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses;

namespace Accela.Apps.Apis.WSModels.Parcels
{
    [DataContract(Name = "GetParcelResponse")]
    public class WSParcelResponse : WSPagedResponse
    {
        [DataMember(Name = "parcel", EmitDefaultValue = false)]
        public WSParcel ResponseParcel { get; set; }

        public static WSParcelResponse FromEntityModel(ParcelResponse parcelResponse)
        {
            return new WSParcelResponse()
            {
                ResponseParcel = WSParcel.FromEntityModel(parcelResponse.Parcel)
            };
        }
    }
}
