using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.Scope;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IScopeRepository : IRepository
    {
        List<ScopeModel> GetScopes();
        List<ScopeGroupModel> GetScopeGroups();
    }
}
