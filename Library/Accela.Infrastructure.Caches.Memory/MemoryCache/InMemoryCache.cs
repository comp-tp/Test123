using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;


namespace Accela.Infrastructure.Caches
{
    public class InMemoryCache : ICache
    {
        private System.Runtime.Caching.MemoryCache cache = null;
        private CacheItemPolicy defaultPolicy = null;
        private CacheItemPolicy policy = null;
        private CacheEntryRemovedCallback callback = null;

        public InMemoryCache(CacheItemPolicy defaultPolicy)
        {
            if (defaultPolicy == null)
            {
                throw new ArgumentException("Provide cache policy");
            }
            this.cache = new System.Runtime.Caching.MemoryCache("AccelaAPICache");
            this.defaultPolicy =  defaultPolicy;
        }


        public string Name
        {
            get { return this.cache.Name; }
        }



        public object Get(string key)
        {
            return this.cache.Get(key);
            //throw new NotImplementedException();
        }

        public T Get<T>()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            return (T)this.cache.Get(key);
            //throw new NotImplementedException();
        }

        public void Put(string key, object instance)
        {
            callback = new CacheEntryRemovedCallback(this.MyCachedItemRemovedCallback);
            policy = new CacheItemPolicy();
            policy.Priority = CacheItemPriority.Default;
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10.00);
            policy.RemovedCallback = callback;
            //policy.ChangeMonitors.Add(new HostFileChangeMonitor(FilePath));
            this.cache.Set(key, instance, policy);
            //throw new NotImplementedException();
        }

        public void Put<T>(T instance)
        {
            throw new NotImplementedException();
        }

        public void Put<T>(string key, T instance)
        {
            callback = new CacheEntryRemovedCallback(this.MyCachedItemRemovedCallback);
            policy = new CacheItemPolicy();
            policy.Priority = CacheItemPriority.Default;
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(10.00);
            policy.RemovedCallback = callback;
            //policy.ChangeMonitors.Add(new HostFileChangeMonitor(FilePath));
            this.cache.Set(key, instance, policy);
            //throw new NotImplementedException();
        }

        public void Put<T>(T instance, DateTime absoluteExpiration)
        {
            throw new NotImplementedException();
        }

        public void Put<T>(string key, T instance, DateTime absoluteExpiration)
        {
            callback = new CacheEntryRemovedCallback(this.MyCachedItemRemovedCallback);
            policy = new CacheItemPolicy();
            policy.Priority = CacheItemPriority.Default;
            policy.AbsoluteExpiration = absoluteExpiration;
            policy.RemovedCallback = callback;
            //policy.ChangeMonitors.Add(new HostFileChangeMonitor(FilePath));
            this.cache.Set(key, instance, policy);
        }

        public void Put<T>(object key, T instance, TimeSpan slidingExpiration)
        {
            throw new NotImplementedException();
        }

        public void Remove<T>()
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            this.cache.Remove(key);
        }

        public void Clear()
        {
            List<string> cacheKeys = this.cache.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                this.cache.Remove(cacheKey);
            }
        }
        private void MyCachedItemRemovedCallback(CacheEntryRemovedArguments arguments)
        {
            // Log these values from arguments list 
            String strLog = String.Concat("Reason: ", arguments.RemovedReason.ToString(), " | Key-Name: ", arguments.CacheItem.Key, " | Value-Object: ", arguments.CacheItem.Value.ToString());
        }




        public void Put<T>(string key, T instance, TimeSpan slidingExpiration)
        {
            
            callback = new CacheEntryRemovedCallback(this.MyCachedItemRemovedCallback);
            policy = new CacheItemPolicy();
            policy.Priority = CacheItemPriority.Default;
            policy.SlidingExpiration = slidingExpiration;
            policy.RemovedCallback = callback;
            //policy.ChangeMonitors.Add(new HostFileChangeMonitor(FilePath));
            this.cache.Set(key, instance, policy);
        }

        public void Touch(string key, TimeSpan slidingExpiration)
        {

            throw new NotImplementedException();

        }


        public void Add(string key, object instance)
        {
            //throw new NotImplementedException();
            Put(key, instance);
        }

        //public void Add<T>(string key, T instance)
        //{
        //    throw new NotImplementedException();
        //}

        public void Add<T>(string key, T instance, DateTime absoluteExpiration)
        {
            Put(key, instance, absoluteExpiration);
        }

        public void Add<T>(string key, T instance, TimeSpan slidingExpiration)
        {
            Put(key, instance, slidingExpiration);
        }
    }
}
