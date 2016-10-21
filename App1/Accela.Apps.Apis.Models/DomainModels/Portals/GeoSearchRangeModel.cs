using System;


// TODO:
// This class does not belong to this project.
// It comes from the Admin subsystem.
// Remove it late.

namespace Accela.Apps.Apis.Models.DomainModels.Portals
{
    public class GeoSearchRangeModel
    {
        public string CenterLocationX { get; set; }

        public string CenterLocationY { get; set; }

        public int Radius { get; set; }

        public string Type { get; set; }
    }
}
