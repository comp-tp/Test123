
namespace Accela.Apps.Apis.Repositories.GovXmlQueries
{
    public class QueryBase
    {
        ///// <summary>
        ///// Cloud User
        ///// </summary>
        //public CloudUser CloudUser {get; set; }

        /// <summary>
        /// Page start index. Used for Paging.
        /// </summary>
        public int RowStart { get; set; }

        /// <summary>
        /// Number of items in Page. Used for Paging.
        /// </summary>
        public int PageSize { get; set; }
    }
}
