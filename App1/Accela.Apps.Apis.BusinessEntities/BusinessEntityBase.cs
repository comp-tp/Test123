using Accela.Core.Ioc;
using Accela.Core.Logging;


namespace Accela.Apps.Apis.BusinessEntities
{
    public class BusinessEntityBase
    {
        /// <summary>
        /// Get an ILog instance.
        /// </summary>
        protected ILog Log
        {
            get
            {
                var logger = IocContainer.Resolve<ILogger>();
                return LogFactory.GetLog(logger);
            }
        }

        //protected ICacheStore Cache
        //{
        //    get
        //    {
        //        var cache = IocContainer.Resolve<IRedisProvider>();
        //        return cache.Instance;
        //    }
        //}

        public BusinessEntityBase()
        {

        }
    }        
}
