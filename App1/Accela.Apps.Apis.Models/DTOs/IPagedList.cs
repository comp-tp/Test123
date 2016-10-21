using System.Collections.Generic;

namespace Accela.Apps.Apis.Models.DTOs
{
    /// <summary>
    /// Define an IPagination interface.
    /// </summary>
    public interface IPagination
    {
        /// <summary>
        /// Total rows
        /// </summary>
        int TotalCount
        {
            get;
            set;
        }

        /// <summary>
        /// Page Index(default value is 0 indicates the first page).
        /// </summary>
        int PageIndex
        {
            get;
            set;
        }

        /// <summary>
        /// Page size.
        /// </summary>
        int PageSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets previous resource URI.
        /// If the value is null or empty indicates no more previous data. 
        /// </summary>
        string Prev
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets next resource URI.
        /// If the value is null or empty indicates no more data. 
        /// </summary>
        string Next
        {
            get;
            set;
        }
    }
    /// <summary>
    /// Define an IPageList interface.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list. </typeparam>
    public interface IPagedList<T> : IPagination
    {
        /// <summary>
        /// Gets the elements in the list.
        /// </summary>
        IList<T> Items
        {
            get;
            set;
        }

    }
}
