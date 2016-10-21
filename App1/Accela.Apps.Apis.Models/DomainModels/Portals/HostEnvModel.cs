using System;
using System.Collections.Generic;

// TODO:
// This class does not belong to this project.
// It comes from the Admin subsystem.
// Remove it late.

namespace Accela.Apps.Apis.Models.DomainModels.Portals
{
    [Serializable]
    public class HostModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        //public string ServiceProviderCode { get; set; }

        public List<HostEnvModel> Environments { get; set; }
    }

    [Serializable]
    public class HostEnvModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string GatewayUrl { get; set; }

        public string GatewayKey { get; set; }

        public string BizServerVersion { get; set; }

        public bool IsAABisServer { get; set; }

        public bool Status { get; set; }

        public bool Default { get; set; }

        public string GatewayVersion { get; set; }

        public List<BizServerModel> BizServers { get; set; }
    }

    [Serializable]
    public class BizServerModel
    {
        public string Id { get; set; }

        public string Url { get; set; }

        /// <summary>
        /// Web Server/BizServer
        /// </summary>
        public string Type { get; set; }

        public string Version { get; set; }

        public string Status { get; set; }
    }
}
