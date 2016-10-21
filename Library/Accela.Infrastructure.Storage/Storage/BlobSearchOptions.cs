using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Storage
{
    public class BlobSearchOptions
    {
        public string NamePrefix {get;set;}

        private int _maxResults = 25;
        public int MaxResults
        {
            get
            { 
                return _maxResults; 
            }
            set
            {
                if(value <= 0)
                {
                    throw new IndexOutOfRangeException("value must be non-nagtive integate.");
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
