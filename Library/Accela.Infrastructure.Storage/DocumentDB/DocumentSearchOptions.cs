using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.DocumentDB
{
    public class DocumentSearchOptions
    {
        public string Collection { get; set; }
        /// <summary>
        /// Get or set filter condition string. only support RowKey and PartitionKey.
        /// </summary>
        public string Filter { get; set; }

        private int _maxResults = 25;
        public int MaxResults
        {
            get
            { 
                return _maxResults; 
            }
            set
            {
                if (value <= 0 || value > 1000)
                {
                    throw new Exception("value must be between 1 and 1000.");
                }
                else
                {
                    _maxResults = value;
                }
            }

        }

        public string ContinuationToken { get; set; }
    }


}
