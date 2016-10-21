using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    [DataContract(Name = "getModulesResponse")]
    public class ModulesResponse : ResponseBase
    {
        public List<ModuleModel> Modules { get; set; }
    }
}
