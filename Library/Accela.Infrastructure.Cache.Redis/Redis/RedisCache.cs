using Accela.Infrastructure.Caches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Cache.Redis
{
    public class RedisCache : ICache
    {
        public virtual object Get(string key)
        {
            return RedisManager.Instance.Get(key);
        }

        public virtual T Get<T>(string key)
        {
            return RedisManager.Instance.Get<T>(key);
        }

        public virtual void Put(string key, object instance)
        {
            RedisManager.Instance.Set(key, instance);
            //throw new NotImplementedException();
        }

        public virtual void Put<T>(string key, T instance)
        {
            RedisManager.Instance.Set(key, instance);
            //throw new NotImplementedException();
        }

        public virtual void Put<T>(string key, T instance, DateTime absoluteExpiration)
        {
            RedisManager.Instance.Set(key, instance, absoluteExpiration);
            //throw new NotImplementedException();
        }



        public virtual void Put<T>(string key, T instance, TimeSpan slidingExpiration)
        {
            RedisManager.Instance.Set(key, instance, slidingExpiration);
            //throw new NotImplementedException();
        }



        public virtual void Remove<T>(string key)
        {
            RedisManager.Instance.KeyDelete(key);
        }

        public virtual void Remove(string key)
        {
            //RedisManager.Instance.Remove(key);
            RedisManager.Instance.KeyDelete(key);
        }

        public virtual void Clear()
        {
            //http://stackoverflow.com/questions/24531421/remove-delete-all-one-item-from-stackexchange-redis-cache
            
            var connectionMultiplexer = RedisManager.GetConnectionMultiplexer(true);
            var endpoints = connectionMultiplexer.GetEndPoints(true);

            foreach (var endpoint in endpoints)
            {
                var server = connectionMultiplexer.GetServer(endpoint);
                server.FlushAllDatabases();
            }
        }


        public void Touch(string key, TimeSpan slidingExpiration)
        {
            throw new NotImplementedException("This method is not required in Redis Cache");
        }


        public void Add(string key, object instance)
        {
            Put(key, instance);
        }

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
