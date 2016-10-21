using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels
{
    [DataContract]
    public class ActionDataModel : DataModel
    {
        public const string NORMAL = "Normal";
        public const string ADDED = "Added";
        public const string UPDATED = "Updated";
        public const string DELETED = "Deleted";

        /// <summary>
        /// The action have below value
        /// "" or "Normal"
        /// "Added"
        /// "Deleted"
        /// "Updated"
        /// </summary>
        [DataMember(Name = "action", EmitDefaultValue = false)]
        public string Action { get; set; }
    }
}
