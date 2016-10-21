using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.ReferenceModels
{
    /// <summary>
    /// Inspector data model
    /// </summary>
    [DataContract]
    public class Inspector : DataModel, IDataModel
    {
        /// <summary>
        /// Gets or sets the inspector key.
        /// </summary>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        /// <summary>
        /// Gets or sets the inspector.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }
    }
}
