
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Shared.Contexts;
using System.Collections.Generic;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IStandardChoiceRepository : IRepository
    {
        IList<string> GetI18NLanguageSettings(GetStandardChoicesRequest request, IAgencyAppContext agencyContext);
    }
}
