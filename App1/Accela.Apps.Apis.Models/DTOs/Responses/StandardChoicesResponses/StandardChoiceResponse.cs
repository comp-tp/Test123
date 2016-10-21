using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.StandardChoicesModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.StandardChoicesResponses
{
    [DataContract(Name = "getStandardChoiceResponse")]
    public class StandardChoicesResponse : ResponseBase
    {
        /// <summary>
        /// AssetUnitType Info
        /// </summary>
        [DataMember(Name = "standardChoicesModels")]
        public List<StandardChoicesModel> StandardChoicesModels { get; set; } 
    }
}
