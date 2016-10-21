using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Persistence;
using Accela.Apps.Apis.Common;

namespace Accela.Apps.Apis.Repositories
{
    public class APIUsageRepository : IAPIUsageRepository
    {
        /// <summary>
        /// Get the most active agency list during date period.
        /// </summary>
        /// <param name="topNum">agency number.</param>
        /// <param name="start">start datetime of period.</param>
        /// <param name="end">end datetime of period.</param>
        /// <returns>the agency list.</returns>
        public List<string> MostActiveAgencies(DateTime startUtc, DateTime endUtc)
        {
            List<string> agencies = null;
            using (var objectContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                agencies = (from t in objectContext.UsageLogs
                            where (t.CreatedDate >= startUtc
                                   && t.CreatedDate <= endUtc 
                                   && t.Agency != null 
                                   && t.Agency != String.Empty)
                            group t by t.Agency into g
                            orderby g.Count() descending
                            select g.Key)
                            .ToList();
                               
            }

            

            return agencies;
        }

        /// <summary>
        /// Get the most active app list during date period.
        /// </summary>
        /// <param name="start">start datetime of period.</param>
        /// <param name="end">end datetime of period.</param>
        /// <returns>the app id list.</returns>
        public List<string> MostActiveApps(DateTime startUtc, DateTime endUtc)
        {
            List<string> apps = null;

            using (var objectContext = new ApiDataContext(ConnectionStrings.ApiDB))
            {
                apps = (from t in objectContext.UsageLogs
                        where (t.CreatedDate >= startUtc
                            && t.CreatedDate <= endUtc
                            && t.AppId != null
                            && t.AppId != String.Empty)
                            group t by t.AppId into g
                            orderby g.Count() descending
                            select g.Key).ToList();
            }

            return apps;
        }
    }
}
