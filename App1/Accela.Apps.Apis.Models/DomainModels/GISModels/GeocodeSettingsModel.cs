using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.GISModels
{
    public class GeocodeSettingsModel
    {
        public string GeocodeServerUrl { get; set; }

        public string Token { get; set; }

        public string TokenServiceUrl { get; set; }

        public string TokenUserName { get; set; }

        public string TokenPassword { get; set; }

        public string TokenExpiration { get; set; }

        public string Referer { get; set; }

        public bool IsCustomService { get; set; }
    }
}
