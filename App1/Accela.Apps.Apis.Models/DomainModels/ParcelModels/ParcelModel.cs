using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.GISModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DomainModels.ParcelModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ParcelModel : ActionDataModel
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
        public ParcelStatusModel Status { get; set; }

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
        /// Gets or sets the owners.
        /// </summary>
        /// <value>
        /// The owners.
        /// </value>
        [DataMember(Name = "owners", EmitDefaultValue = false)]
        public List<OwnerModel> Owners { get; set; }

        [DataMember(Name = "addresses", EmitDefaultValue = false)]
        public List<AddressModel> Addresses { get; set; }

        public List<GISObjectModel> GISObjects { get; set; }
    }
}
