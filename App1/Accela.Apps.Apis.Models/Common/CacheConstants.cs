using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.Models.Common
{
    public class CacheConstants
    {
        // Ex. apicachedata-160630
        public static string API_TEMPDATA_CONTAINER_PREFIX = "apicachedata-";
        public static string API_TEMPDATA_CONTAINER_DATEFORMAT = "yyyyMMdd";
        public static int API_TEMPDATA_ASYNCDATA_DAYS = 7;
        public static int API_TEMPDATA_V3PERSISTEDDATA_DAYS = 7;
    }
}
