using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Accela.Apps.Shared.Utils
{
    public static class DateTimeExtension
    {
        #region private properties

        /// <summary>
        /// Get yesterday start datatime. e.g: 2013-03-11 00:00:00
        /// </summary>
        /// <param name="date">the date. e.g: 2013-03-12</param>
        /// <returns>yesterdat begin datetime. e.g:2013-03-11 00:00:00</returns>
        public static DateTime YesterdayStart(this DateTime date)
        {
            DateTime yesterday = date.AddDays(-1);
            return new DateTime(yesterday.Year, yesterday.Month, yesterday.Day, 0, 0, 0);
        }

        /// <summary>
        /// Get yesterday end datatime. e.g: 2013-03-11 23:59:59
        /// </summary>
        /// <param name="date">the date. e.g: 2013-03-12</param>
        /// <returns>yesterdat end datetime. e.g:2013-03-11 23:59:59</returns>
        public static DateTime YesterdayEnd(this DateTime date)
        {
            DateTime yesterday = DateTime.UtcNow.AddDays(-1);

            return new DateTime(yesterday.Year, yesterday.Month, yesterday.Day, 23, 59, 59);
        }

        /// <summary>
        /// Get previours quarter start datetime. e.g: 2013-01-01 00:00:00
        /// </summary>
        /// <param name="date">the date.</param>
        /// <returns>datetime.</returns>
        public static DateTime PreviousQuarterStart(this DateTime date)
        {
            IEnumerable<DateTime> candidates =
               QuartersInYear(date.Year).Union(QuartersInYear(date.Year - 1));

            foreach (var dt in candidates)
            {
                string sdt = dt.ToString();
            }
            DateTime begin = candidates.Where(d => d <= date).OrderBy(d => d).Last().AddMonths(-2);

            return new DateTime(begin.Year, begin.Month, 1, 0, 0, 0);
        }

        /// <summary>
        /// Get previours quarter end datetime. e.g: 2013-03-31 23:59:59
        /// </summary>
        /// <param name="date">the date.</param>
        /// <returns>datetime.</returns>
        public static DateTime PreviousQuarterEnd(this DateTime date)
        {
            IEnumerable<DateTime> candidates = QuartersInYear(date.Year).Union(QuartersInYear(date.Year - 1));

            DateTime end = candidates.Where(d => d <= date).OrderBy(d => d).Last();
            return new DateTime(end.Year, end.Month, end.Day, 23, 59, 59);
        }

        /// <summary>
        /// Get Quarter string with Year. e.g 201301 means the 1st quarter of 2013
        /// </summary>
        /// <param name="date">the datetime</param>
        /// <returns>The quarter with year.e.g: 201301 means the 1st quarter of 2013</returns>
        public static string GetQuarter(this DateTime date)
        {
            int quarter = (date.Month - 1) / 3 + 1;

            switch (quarter)
            {
                case 1: return String.Format("{0}{1}", date.Year, "01");
                case 2: return String.Format("{0}{1}", date.Year, "02");
                case 3: return String.Format("{0}{1}", date.Year, "03");
                default: return String.Format("{0}{1}", date.Year, "04");
            }
        }

        /// <summary>
        /// Get Quarter string with Year. e.g 201301 means the 1st quarter of 2013
        /// </summary>
        /// <param name="date">the datetime</param>
        /// <param name="skipQuarters">skip quarter number.</param>
        /// <returns>The quarter with year.e.g: 201301 means the 1st quarter of 2013</returns>
        public static string GetQuarter(this DateTime date, int skipQuarters)
        {
            int skipMonths = skipQuarters * 3;
            int quarter = (date.AddMonths(skipMonths).Month - 1) / 3 + 1;
            int year = date.AddMonths(skipMonths).Year;
            switch (quarter)
            {
                case 1: return String.Format("{0}{1}", year, "01");
                case 2: return String.Format("{0}{1}", year, "02");
                case 3: return String.Format("{0}{1}", year, "03");
                default: return String.Format("{0}{1}", year, "04");
            }
        }

        private static IEnumerable<DateTime> QuartersInYear(int year)
        {
            return new List<DateTime>() {
               new DateTime(year, 3, 31),
               new DateTime(year, 6, 30),
               new DateTime(year, 9, 30),
               new DateTime(year, 12, 31),
            };
        }

        #endregion
    }
}
