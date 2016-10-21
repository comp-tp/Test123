using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.PersistedDataModels;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Apis.BusinessEntities.Interfaces;


namespace Accela.Apps.Apis.BusinessEntities
{
    public class PersistedDataBusinessEntity : IPersistedDataBusinessEntity
    {
        private IPersistedDataRepository persistedDataRepository;

        public PersistedDataBusinessEntity(IPersistedDataRepository persistedDataRepository)
        {
            this.persistedDataRepository = persistedDataRepository; //IocContainer.Resolve<IPersistedDataRepository>();
        }

        public List<PersistedDataModel> GetPersistedDatas(string agency)
        {
            return persistedDataRepository.GetPersistedDatas(agency);
        }

        public bool DeletePersistedDatas(string agency, string entityType)
        {
            return persistedDataRepository.DeletePersistedDatas(agency, entityType);
        }
    }
}
