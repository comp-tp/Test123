using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.Portals;

// TODO:
// This class does not belong to this project.
// It comes from the Log subsystem.
// Remove it late.

namespace Accela.Apps.Apis.WSModels.Diagnostics
{
    [DataContract(Name = "logsResponse")]
    public class WSLogsResponse : WSResponseBase
    {
        [DataMember(Name = "logs", EmitDefaultValue = false)]
        public IList<LogEntry> Logs { get; set; }
    }

}
