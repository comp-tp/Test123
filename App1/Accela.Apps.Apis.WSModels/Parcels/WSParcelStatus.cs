using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ParcelModels;

namespace Accela.Apps.Apis.WSModels.Parcels
{
    [DataContract(Name = "parcelStatus")]
    public class WSParcelStatus
    {
        /// <summary>
        /// Gets or sets the record type id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the display for record type
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Convert ParcelStatusModel to ParcelStatusModel.
        /// </summary>
        /// <param name="parcelStatus">ParcelStatusModel.</param>
        /// <returns>WSParcelStatus.</returns>
        public static WSParcelStatus FromEntityModel(ParcelStatusModel parcelStatus)
        {
            if (parcelStatus != null)
            {
                return new WSParcelStatus()
                {
                    Id = parcelStatus.Identifier,
                    Display = parcelStatus.Display
                };
            }
            return null;
        }

        /// <summary>
        /// Convert WSParcelStatus to ParcelStatusModel.
        /// </summary>
        /// <param name="wsParcelStatus">WSParcelStatus.</param>
        /// <returns>ParcelStatusModel.</returns>
        public static ParcelStatusModel ToEntityModel(WSParcelStatus wsParcelStatus)
        {
            if (wsParcelStatus != null)
            {
                return new ParcelStatusModel()
                {
                    Identifier = wsParcelStatus.Id,
                    Display = wsParcelStatus.Display
                };
            }
            return null;
        }
    }
}
