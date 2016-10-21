using Accela.Apps.Shared.RestClients;
using Accela.Apps.User.WSModels.V2.CivicId;

using System.Web.Http;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Infrastructure.Configurations;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/civicusers")]
    [APIControllerInfoAttribute(Name = "Civic Users", Description = "")]
    public class CivicUsersController : ControllerBase
    {
        private readonly IConfigurationReader configurationReader;
        public CivicUsersController(IConfigurationReader configurationReader)
        {
            this.configurationReader = configurationReader;
        }

        [Route("register")]
        [APIActionInfoAttribute(Name = "Register Civic Id", Scope = "register_civic_id", Applicability = APIActionInfoAttribute.APPLICABILITY_CIVIC, Note = "Adds or overwrites a civic user, taking in his/her personal information.")]
        public WSCreateCivicIdResponse CreateCivicId(WSCreateCivicIdRequest request)
        {
            var client = new InternalAPIClient();
            var apiUrl = configurationReader.Get("Ref_InternalAPI_User");
            var requestUrl = Accela.Apps.Shared.Utils.UrlHelper.CombinePath(apiUrl, "/civicusers/register");
            var result = client.Execute<WSCreateCivicIdResponse>(requestUrl);
            return result;
        }
    }
}
