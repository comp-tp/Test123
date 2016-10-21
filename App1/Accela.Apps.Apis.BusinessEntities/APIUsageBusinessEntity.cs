using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Dev.WSModels.V2;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Core.Ioc;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class APIUsageBusinessEntity : IAPIUsageBusinessEntity
    {
        private readonly IAPIUsageRepository apiUsageRepository;
        private readonly IAgencyRepository agencyRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        public APIUsageBusinessEntity(IAPIUsageRepository apiUsageRepository, IAgencyRepository agencyRepository)
        {
            this.apiUsageRepository = apiUsageRepository; //IocContainer.Resolve<IAPIUsageRepository>();
            this.agencyRepository = agencyRepository; // IocContainer.Resolve<IAgencyRepository>();
        }

        /// <summary>
        /// Get the most active 9 agency list today .
        /// </summary>
        /// <returns>the top 9 active agency list.</returns>
        public List<string> MostActiveAgencies()
        {
            int topNum = 9;
            DateTime now = DateTime.UtcNow;
            DateTime start = now.AddDays(-1);
            DateTime end = now;
            List<string> list=apiUsageRepository.MostActiveAgencies(start, end);
            List<AgencyModel> agencyList = agencyRepository.GetAllAgencies();
            List<string> result = new List<string>();
            list.ForEach(agency =>
            {
                if (agencyList.Exists(item => string.Equals(item.Name, agency, StringComparison.InvariantCultureIgnoreCase) && item.IsForDemo == false))
                {
                    result.Add(agency);
                }
            });

            result = result.Take(topNum).ToList();

            return result;
        }

        /// <summary>
        /// Get the most active 9 app list today .
        /// </summary>
        /// <returns>the top 9 active app list.</returns>
        public List<string> MostActiveApps()
        {
            int topNum = 9;
            DateTime now = DateTime.UtcNow;
            DateTime start = now.AddDays(-1);
            DateTime end = now;
            List<string> appIds = apiUsageRepository.MostActiveApps(start, end);
            List<string> appNames = new List<string>();
            List<WSApp> appModels = null;
            
            if (appIds != null && appIds.Count > 0)
            {
                var appRepository = IocContainer.Resolve<IAppRepository>();
                appModels = appRepository.SearchApps(null);
            }
         
            if (appModels != null && appModels.Count > 0)
            {
                foreach (var id in appIds)
                {
                    foreach (var m in appModels)
                    {
                        if (m != null && m.AppId.Equals(id, StringComparison.OrdinalIgnoreCase) && m.Stage == 1 && m.Status == 1)
                        {
                            appNames.Add(m.AppName);
                            break;
                        }
                    }
                }
            }

            appNames = appNames.Take(topNum).ToList();

            return appNames;
        }
    }
}
