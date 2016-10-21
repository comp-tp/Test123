using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Caches
{
 
    public interface ICache
    {
        object Get(string key);

        ///<summary>
        /// Gets state data stored with the default key.
        ///</summary>
        ///<typeparam name="T">The type of data to retrieve.</typeparam>
        ///<returns>An instance of <typeparamref name="T"/> or null if not found.</returns>
        T Get<T>(string key);

        /// <summary>
        /// Adds state data into the cache state with the specified key with no expiration.
        /// </summary>
        /// <param name="instance">An object</param>
        void Add(string key, object instance);

        /// <summary>
        /// Adds state data into the cache state with the specified key with the specified absolute expiration.
        /// </summary>
        /// <typeparam name="T">The type of data to put.</typeparam>
        /// <param name="key">An object representing the unique key with which the data is stored.</param>
        /// <param name="instance">An instance of <typeparamref name="T"/> to store.</param>
        /// <param name="absoluteExpiration">The date and time when the data from the cache will be removed.</param>
        void Add<T>(string key, T instance, DateTime absoluteExpiration);

        /// <summary>
        /// Adds state data into the cache state with the specified key with the specified sliding expiration
        /// </summary>
        /// <typeparam name="T">The type of data to put.</typeparam>
        /// <param name="key">An object representing the unique key with which the data is stored.</param>
        /// <param name="instance">An instance of <typeparamref name="T"/> to store.</param>
        /// <param name="slidingExpiration">A <see cref="TimeSpan"/> specifying the sliding expiration policy.</param>
        void Add<T>(string key, T instance, TimeSpan slidingExpiration);

        void Put(string key, object instance);

        /// <summary>
        /// Puts state data into the cache state with the specified key with no expiration.
        /// </summary>
        /// <typeparam name="T">The type of data to put.</typeparam>
        /// <param name="instance">An instance of <typeparamref name="T"/> to store.</param>
        void Put<T>(string key, T instance);

        /// <summary>
        /// Puts state data into the cache state with the specified key with the specified absolute expiration.
        /// </summary>
        /// <typeparam name="T">The type of data to put.</typeparam>
        /// <param name="key">An object representing the unique key with which the data is stored.</param>
        /// <param name="instance">An instance of <typeparamref name="T"/> to store.</param>
        /// <param name="absoluteExpiration">The date and time when the data from the cache will be removed.</param>
        void Put<T>(string key, T instance, DateTime absoluteExpiration);

     

        /// <summary>
        /// Puts state data into the cache state with the specified key with the specified sliding expiration
        /// </summary>
        /// <typeparam name="T">The type of data to put.</typeparam>
        /// <param name="key">An object representing the unique key with which the data is stored.</param>
        /// <param name="instance">An instance of <typeparamref name="T"/> to store.</param>
        /// <param name="slidingExpiration">A <see cref="TimeSpan"/> specifying the sliding expiration policy.</param>
        void Put<T>(string key, T instance, TimeSpan slidingExpiration);

        /// <summary>
        /// Removes state data stored in the cache with the default key.
        /// </summary>
        /// <typeparam name="T">The type of data to remove.</typeparam>
        void Remove<T>(string key);

     

        /// <summary>
        /// Removes state data stored in the cache state with the specified key.
        /// </summary>
        /// <typeparam name="T">The type of data to remove.</typeparam>
        /// <param name="key">An object representing the unique key with which the data was stored.</param>
        void Remove(string key);

        /// <summary>
        /// Clears all state stored in the cache.
        /// </summary>
        void Clear();


        ///// <summary>
        ///// Couchbase has no implementation for SlidingExpiration, Workaround to call Touch, after Get.
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="slidingExpiration"></param>
        //void Touch(string key, TimeSpan slidingExpiration);
    }
}
