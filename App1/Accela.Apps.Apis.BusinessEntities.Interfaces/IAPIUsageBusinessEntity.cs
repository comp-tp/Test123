using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    /// <summary>
    /// Interface for IAPIUsageBusinessEntity.
    /// </summary>
    public interface IAPIUsageBusinessEntity : IBusinessEntity
    {
        /// <summary>
        /// Get the most active 10 agency list today .
        /// </summary>
        /// <returns>the top 10 active agency list.</returns>
        List<string> MostActiveAgencies();

        /// <summary>
        /// Get the most active 10 app list today .
        /// </summary>
        /// <returns>the top 10 active app list.</returns>
        List<string> MostActiveApps();
    }
}
