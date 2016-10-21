using System;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Apps.Apis.Repositories
{
    public class Utility
    {
        /// <summary>
        /// get data range
        /// </summary>
        /// <param name="from">date from(yyyyMMdd)</param>
        /// <param name="to">date to(yyyyMMdd)</param>
        /// <returns>date range(yyyy-MM-dd)</returns>
        public static DateRange GetDataRange(string from, string to)
        {
            DateRange range = null;
            if (!string.IsNullOrWhiteSpace(from) || !string.IsNullOrWhiteSpace(to))
            {
                range = new DateRange();
                if (!string.IsNullOrWhiteSpace(from))
                {
                    DateTime dtFrom = DateTime.ParseExact(from, "yyyyMMdd", System.Threading.Thread.CurrentThread.CurrentCulture);
                    range.from = dtFrom.ToString("yyyy-MM-dd");
                }
                if (!string.IsNullOrEmpty(to))
                {
                    DateTime dtTo = DateTime.ParseExact(to, "yyyyMMdd", System.Threading.Thread.CurrentThread.CurrentCulture);
                    range.to = dtTo.ToString("yyyy-MM-dd");
                }
            }

            return range;
        }
    }
}
