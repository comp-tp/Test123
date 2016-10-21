using System;


// TODO:
// This class does not belong to this project.
// It comes from the Admin subsystem.
// Remove it late.

namespace Accela.Apps.Apis.Models.DomainModels.Portals
{
    public class GeoCoordinateModel
    {
        public Guid GlobalEntityId { get; set; }

        public string CoordinateX { get; set; }

        public string CoordinateY { get; set; }

        public string EntityType { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime LastUpdatedDate { get; set; }
    }
}
