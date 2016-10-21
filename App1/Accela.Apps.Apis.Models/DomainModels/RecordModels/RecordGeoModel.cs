using System;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using System.Collections.Generic;

namespace Accela.Apps.Apis.Models.DomainModels.RecordModels
{
    public class RecordGeoModel : DataModel, IDataModel
    {
        public string Id { get; set; }

        public Guid GlobalEntityId { get; set; }

        public string Agency { get; set; }

        public string Environment { get; set; }

        public string Type { get; set; }

        public string OneLineAddress { get; set; }

        public decimal? CoordinateX { get; set; }

        public decimal? CoordinateY { get; set; }

        public string Creator { get; set; }

        public CloudUserModel User { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime? OpenedDate { get; set; }

        public List<string> ImageUrls { get; set; }

        public string AssignTo { get; set; }

        public int IsPrivate { get; set; }

        public DateTime? LastUpdatedDate { get; set; }
    }
}
