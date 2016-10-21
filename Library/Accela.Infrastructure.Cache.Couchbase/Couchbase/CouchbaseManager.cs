using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Couchbase;
using Couchbase.Extensions;
using Enyim.Caching.Memcached;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Accela.Infrastructure.Cache.Couchbase
{
    public  class CouchbaseManager
    {
        private static volatile CouchbaseClient instance;
        private static object syncRoot = new Object();

        private CouchbaseManager()
        {
            //_instance = new CouchbaseClient();
        }

        public static CouchbaseClient Instance {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            try
                            {
                                instance = new CouchbaseClient();
                            }
                            catch (Exception ex) {
                                Debug.WriteLine(ex.Message);
                            }
                        }
                    }
                }
                return instance;
            } 
        }
    }
}
