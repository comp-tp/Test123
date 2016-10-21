using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.PersistedDataModels;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IPersistedDataRepository : IRepository
    {
        List<PersistedDataModel> GetPersistedDatas(string agency);

        bool DeletePersistedDatas(string agency, string entityType);
    }
}
