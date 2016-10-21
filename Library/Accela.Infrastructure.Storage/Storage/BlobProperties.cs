using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Storage
{
    /// <summary>
    /// Blob Information
    /// </summary>
    public class BlobProperties
    {
        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public long? Length { get; set; }

        /// <summary>
        /// Gets or sets the full blob file name.
        /// </summary>
        /// <value>
        /// The full blob name.
        /// </value>
        public string BlobName { get; set; }

        /// <summary>
        /// Gets or sets the blob Container.
        /// </summary>
        /// <value>
        /// The blob container.
        /// </value>
        public string ContainerName { get; set; }

        public string ContentEncoding { get; set; }

        public string ContentType { get; set; }
        /// <summary>
        /// Gets or sets last updated timestamp in utc.
        /// </summary>
        /// <value>
        /// LastUpdatedUtc.
        /// </value>
        public DateTime? LastModified { get; set; }
    }
}
