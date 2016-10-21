using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.GISModels;

namespace Accela.Apps.Apis.Models.DomainModels.AssetModels
{
    [DataContract]
    public class AssetTypeModel : IdentifierBase2
    {
        /// <summary>
        /// Gets or sets the gis id field name
        /// </summary>
        [DataMember(Name = "gisIDFieldName", EmitDefaultValue = false)]
        public string GISIDFieldName { get; set; }

        [DataMember(Name = "gisService", EmitDefaultValue = false)]
        public string GISService { get; set; }

        [DataMember(Name = "gisLayer", EmitDefaultValue = false)]
        public GISLayerModel GISLayer { get; set; }

        [DataMember(Name = "group", EmitDefaultValue = false)]
        public string Group { get; set; }
    }
}
