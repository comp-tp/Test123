using System.Collections.Generic;

namespace Accela.Apps.Apis.Repositories.GovXmlQueries
{
    public class InspectionsQuery : QueryBase
    {
        /// <summary>
        /// This field caches DayBefore value.
        /// </summary>
        public int DaysBefore { get; set; }

        /// <summary>
        /// This field caches DayAfter value.
        /// </summary>
        public int DaysAfter { get; set; }

        /// <summary>
        /// This field caches inspector keys.
        /// </summary>
        public List<string> InspectorIds { get; set; }

        /// <summary>
        /// Gets or sets InspectionId
        /// </summary>
        public string InsepctionId { get; set; }

        /// <summary>
        /// Get or sets districts.
        /// </summary>
        public List<string> Districts { get; set; }
    }
}
