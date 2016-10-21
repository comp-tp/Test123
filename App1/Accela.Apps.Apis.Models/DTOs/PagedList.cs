using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs
{
    [DataContract]
    public class PagedList<T> : IPagedList<T>
    {
        IList<T> _items = new List<T>();

        public PagedList()
        {
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            if (source != null)
            {
                this.TotalCount = source.Count();
                _pageSize = pageSize;
                this.PageIndex = pageIndex;
                _items = source.Skip(pageIndex * PageSize).Take(PageSize).ToList<T>();
            }
        }

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            if (source != null)
            {
                this.TotalCount = source.Count();
                _pageSize = pageSize;
                this.PageIndex = pageIndex;
                _items = source.Skip(pageIndex * PageSize).Take(PageSize).ToList<T>();
            }
        }

        public PagedList(IList<T> source, int pageIndex, int pageSize)
        {
            if (source != null)
            {
                this.TotalCount = source.Count();
                _pageSize = pageSize;
                this.PageIndex = pageIndex;
                _items = source.Skip(pageIndex * PageSize).Take(PageSize).ToList<T>();
            }
        }

        /// <summary>
        /// Page Index(default value is 0 indicates the first page).
        /// </summary>
        [DataMember(Order = 1)]
        public int PageIndex
        {
            get;
            set;
        }

        int _pageSize = 10;
        /// <summary>
        /// Page size.
        /// </summary>
        [DataMember(Order = 2)]
        public int PageSize
        {
            get
            {
                if (_pageSize < 1)
                {
                    _pageSize = 10000; // means return all
                }

                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }

        /// <summary>
        /// Total rows
        /// </summary>
        [DataMember(Order = 3)]
        public int TotalCount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the elements in the list.
        /// </summary>
        [DataMember(Order = 4)]
        public IList<T> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        /// <summary>
        /// Gets or sets previous resource URI.
        /// If the value is null or empty indicates no more previous data. 
        /// </summary>
        [DataMember(Order = 5)]
        public string Prev
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets next resource URI.
        /// </summary>
        [DataMember(Order = 6)]
        public string Next
        {
            get;
            set;
        }

        #region Get/SetEmitFields
        
        private List<string> _emitFields;

        /// <summary>
        /// Sets Emit fields. if empty or null, emit all fields.
        /// </summary>
        public void SetEmitFields(List<string> emitFields)
        {
            _emitFields = emitFields;
            IListExtension.SetEmitFields(this._items as IList, emitFields);
        }


        /// <summary>
        /// Sets Emit fields. if empty or null, emit all fields.
        /// </summary>
        public void SetEmitFields(string emitFields)
        {
            if (String.IsNullOrEmpty(emitFields))
            {
                return;
            }

            SetEmitFields(emitFields.Split(new char[]{','}).ToList<string>());
        }

        /// <summary>
        /// Gets Emit fields. if empty or null, emit all fields.
        /// </summary>
        public List<string> GetEmitFields()
        {
            return _emitFields;
        }

        #endregion

        #region Get/SetIgnoreEmitFields

        private List<string> _ignoreEmitFields;

        /// <summary>
        /// Sets ignore Emit fields.
        /// </summary>
        public void SetIgnoreEmitFields(List<string> ignoreEmitFields)
        {
            _ignoreEmitFields = ignoreEmitFields;

            IListExtension.SetIgnoreEmitFields(this._items as IList, ignoreEmitFields);
        }


        /// <summary>
        /// Override. Sets ignore Emit fields.
        /// </summary>
        public void SetIgnoreEmitFields(string ignoreEmitFields)
        {
            if (String.IsNullOrEmpty(ignoreEmitFields))
            {
                return;
            }

            SetIgnoreEmitFields(ignoreEmitFields.Split(new char[] { ',' }).ToList<string>());
        }

        /// <summary>
        /// Gets Emit fields. if empty or null, emit all fields.
        /// </summary>
        public List<string> GetIgnoreEmitFields()
        {
            return _ignoreEmitFields;
        }

        #endregion
    }
}
