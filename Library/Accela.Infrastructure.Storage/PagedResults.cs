using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure
{
    public class PagedResults<T> where T : class
    {
        public IEnumerable<T> Results
        {
            get;
            set;
        }

        public string ContinuationToken
        {
            get;
            set;
        }
    }
}
