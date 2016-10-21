using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    /// <summary>
    /// Interface for APIUsageRepository.
    /// </summary>
    public interface IAPIUsageRepository : IRepository
    {
        /// <summary>
        /// Get the most active agency list during date period.
        /// </summary>
        /// <param name="start">start datetime of period.</param>
        /// <param name="end">end datetime of period.</param>
        /// <returns>the agency list.</returns>
        List<string> MostActiveAgencies(DateTime start, DateTime end);

        /// <summary>
        /// Get the most active app list during date period.
        /// </summary>
        /// <param name="start">start datetime of period.</param>
        /// <param name="end">end datetime of period.</param>
        /// <returns>the app list.</returns>
        List<string> MostActiveApps(DateTime start, DateTime end);
    }
}
