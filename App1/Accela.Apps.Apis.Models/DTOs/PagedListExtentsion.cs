using System.Collections.Generic;
using System.Linq;

namespace Accela.Apps.Apis.Models.DTOs
{
    public static class PagedListExtensions
    {
        #region Pagination

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int startIndex = 0, int pageSize = 20)
        {
            return new PagedList<T>(source, startIndex, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int startIndex = 0, int pageSize = 20)
        {
            return new PagedList<T>(source, startIndex, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this List<T> source, int startIndex = 0, int pageSize = 20)
        {
            return new PagedList<T>(source, startIndex, 10);
        }

        #endregion Pagination
    }
}
