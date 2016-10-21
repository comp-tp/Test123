using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.V4
{
    [DataContract]
    public abstract class WSIdentifierBaseV4
    {
        /// <summary>
        /// Gets or sets the record type keys.
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false, Order = 1)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the display for record type
        /// </summary>
        [DataMember(Name = "text", EmitDefaultValue = false, Order = 2)]
        public string Display { get; set; }
    }
}
