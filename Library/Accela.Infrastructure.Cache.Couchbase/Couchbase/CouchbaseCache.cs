using Accela.Infrastructure.Caches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Cache.Couchbase
{
    public class CouchbaseCache: ICache
    {

        public virtual object Get(string key)
        {
            return CouchbaseManager.Instance.Get(key);
        }

        public virtual T Get<T>(string key)
        {
            return CouchbaseManager.Instance.Get<T>(key);
        }

        public virtual void Put(string key, object instance)
        {
            CouchbaseManager.Instance.Store(Enyim.Caching.Memcached.StoreMode.Set, key, instance);
            //throw new NotImplementedException();
        }

        public virtual void Put<T>(string key, T instance)
        {
            CouchbaseManager.Instance.Store(Enyim.Caching.Memcached.StoreMode.Set, key, instance);
            //throw new NotImplementedException();
        }

        public virtual void Put<T>(string key, T instance, DateTime absoluteExpiration)
        {
            CouchbaseManager.Instance.Store(Enyim.Caching.Memcached.StoreMode.Set, key, instance, absoluteExpiration);
            //throw new NotImplementedException();
        }



        public virtual void Put<T>(string key, T instance, TimeSpan slidingExpiration)
        {
            CouchbaseManager.Instance.Store(Enyim.Caching.Memcached.StoreMode.Set, key, instance, slidingExpiration);
            //throw new NotImplementedException();
        }



        public virtual void Remove<T>(string key)
        {
            CouchbaseManager.Instance.Remove(key);
            //throw new NotImplementedException();
        }

        public virtual void Remove(string key)
        {
            CouchbaseManager.Instance.Remove(key);
            //throw new NotImplementedException();
        }

        public virtual void Clear()
        {
            CouchbaseManager.Instance.FlushAll();
            //throw new NotImplementedException();
        }


        public void Touch(string key, TimeSpan slidingExpiration)
        {
            CouchbaseManager.Instance.Touch(key, slidingExpiration);
        }


        public void Add(string key, object instance)
        {
            throw new NotImplementedException();
        }

        //public void Add<T>(string key, T instance)
        //{
        //    throw new NotImplementedException();
        //}

        public void Add<T>(string key, T instance, DateTime absoluteExpiration)
        {
            throw new NotImplementedException();
        }

        public void Add<T>(string key, T instance, TimeSpan slidingExpiration)
        {
            throw new NotImplementedException();
        }
    }
}
