using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.Scope
{
    [Serializable]
    public class ScopeModel
    {
        public string Name { get; set; }

        public List<ScopeGroupModel> ScopeGroups { get; set; }
    }
}
