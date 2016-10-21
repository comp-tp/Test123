using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ParcelModels;

namespace Accela.Apps.Apis.WSModels.Parcels
{
    [DataContract(Name="parcel")]
    public class WSParcel : WSEntityState
    {
        /// <summary>
        /// Gets or sets the parcel Id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the parcel display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the text
        /// </summary>
        [DataMember(Name = "text", EmitDefaultValue = false)]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets legalDescription
        /// </summary>
        [DataMember(Name = "legalDescription", EmitDefaultValue = false)]
        public string LegalDescription { get; set; }

        /// <summary>
        /// Gets or sets status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public WSParcelStatus Status { get; set; }

        /// <summary>
        /// Gets or sets tract
        /// </summary>
        [DataMember(Name = "tract", EmitDefaultValue = false)]
        public string Tract { get; set; }

        /// <summary>
        /// Gets or sets block
        /// </summary>
        [DataMember(Name = "block", EmitDefaultValue = false)]
        public string Block { get; set; }

        /// <summary>
        /// Gets or sets lot
        /// </summary>
        [DataMember(Name = "lot", EmitDefaultValue = false)]
        public string Lot { get; set; }

        /// <summary>
        /// Gets or sets township
        /// </summary>
        [DataMember(Name = "township", EmitDefaultValue = false)]
        public string Township { get; set; }

        /// <summary>
        /// Gets or sets range
        /// </summary>
        [DataMember(Name = "range", EmitDefaultValue = false)]
        public string Range { get; set; }

        /// <summary>
        /// Gets or sets section
        /// </summary>
        [DataMember(Name = "section", EmitDefaultValue = false)]
        public string Section { get; set; }

        /// <summary>
        /// Gets or sets subdivision
        /// </summary>
        [DataMember(Name = "subdivision", EmitDefaultValue = false)]
        public string Subdivision { get; set; }

        /// <summary>
        /// Convert ParcelModel to WSParcel.
        /// </summary>
        /// <param name="parcel">ParcelModel.</param>
        /// <returns>WSParcel.</returns>
        public static WSParcel FromEntityModel(ParcelModel parcel)
        {
            if (parcel != null)
            {
                return new WSParcel()
                {
                    Id = parcel.Id,
                    Display = parcel.Display,
                    Description = parcel.Description,
                    Text = parcel.Text,
                    LegalDescription = parcel.LegalDescription,
                    Status = WSParcelStatus.FromEntityModel(parcel.Status),
                    Tract = parcel.Tract,
                    Block = parcel.Block,
                    Lot = parcel.Lot,
                    Township = parcel.Township,
                    Range = parcel.Range,
                    Section = parcel.Section,
                    Subdivision = parcel.Subdivision,
                    EntityState = ConvertActionToEntityState(parcel.Action)
                };
            }
            return null;
        }

        /// <summary>
        /// Convert WSParcel to ParcelModel.
        /// </summary>
        /// <param name="wsParcel">WSParcel.</param>
        /// <returns>ParcelModel.</returns>
        public static ParcelModel ToEntityModel(WSParcel wsParcel)
        {
            if (wsParcel != null)
            {
                return new ParcelModel() 
                {
                    Id = wsParcel.Id,
                    Display = wsParcel.Display,
                    Description = wsParcel.Description,
                    Text = wsParcel.Text,
                    LegalDescription = wsParcel.LegalDescription,
                    Status = WSParcelStatus.ToEntityModel(wsParcel.Status),
                    Tract = wsParcel.Tract,
                    Block = wsParcel.Block,
                    Lot = wsParcel.Lot,
                    Township = wsParcel.Township,
                    Range = wsParcel.Range,
                    Section = wsParcel.Section,
                    Subdivision = wsParcel.Subdivision,
                    Action = WSEntityState.ConvertEntityStateToAction(wsParcel.EntityState)
                };
            }
            return null;
        }
    }    
}
