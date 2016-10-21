using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.WSModels
{
    /// <summary>
    /// Ex.
    /// "page": {
    ///     "offset": 0,
    ///     "limit": 25,
    ///     "hasmore": true
    /// }
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract()]
    [Serializable]
    public class PagedResultResponse<T> : GenericResultResponse<T>
    {
        public PagedResultResponse() : base()
        {
        }

        /// <summary>
        /// pagination info
        /// </summary>
        [DataMember(Name = "page", EmitDefaultValue = false)]
        public PaginationInfo Page { get; set; }
    }
}
