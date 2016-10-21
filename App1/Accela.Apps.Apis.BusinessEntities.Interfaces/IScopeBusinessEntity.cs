using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.Scope;
using Accela.Apps.Apis.Models.DTOs.Requests.ScopeRequests;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IScopeBusinessEntity : IBusinessEntity
    {
        List<ScopeModel> GetScopes();

        List<string> GetScopesByGroup(string groupName);

        List<ScopeGroupModel> GetScopeGroups();

        bool IsValidScope(IsValidScopeRequest request);
    }
}
