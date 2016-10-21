
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
namespace Accela.Apps.Apis.Models.DTOs.Requests.CitizenRequests
{
    public class CreateCivicIdRequest : RequestBase
    {
        // TODO:
        public CloudUserModel User { get; set; }
    }
}
