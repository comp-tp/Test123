using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.Images
{
    public class Image
    {
        public Guid Id { get; set; }

        public Guid GlobalEntityID { get; set; }

        public string ImageURL { get; set; }

        public string BlobContainer { get; set; }

        public string BlobName { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedDate { get; set; }
    }
}
