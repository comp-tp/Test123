using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs
{
    /// <summary>
    /// Paged response
    /// </summary>
    [DataContract]
    public class PagedResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the page info.
        /// </summary>
        /// <value>
        /// The page info.
        /// </value>
        [DataMember(Name = "page", EmitDefaultValue = false)]
        public Pagination PageInfo 
        { 
            get; 
            set; 
        }
    }
}
