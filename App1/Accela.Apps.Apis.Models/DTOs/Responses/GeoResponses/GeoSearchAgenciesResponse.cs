using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.Portals;

namespace Accela.Apps.Apis.Models.DTOs.Responses.GeoResponses
{
    [DataContract]
    public class GeoSearchAgenciesResponse : ResponseBase
    {
        // TODO:
        [DataMember(Name = "agencies")]
        public List<Admin.Agency.Client.Models.AgencyModel> Agencies { get; set; }
    }
}
