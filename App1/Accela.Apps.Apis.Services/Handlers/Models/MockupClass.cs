using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using Accela.Apps.Shared;
using Accela.Core.Logging;

namespace Accela.Apps.Apis.Services.Handlers.Models
{
    public class MockupClass
    {
        /// <summary>
        /// Get an ILog instance.
        /// </summary>
        protected static ILog Log
        {
            get
            {
                return LogFactory.GetLog();
            }
        }

        public static T ProcessMockupData<T>(string fileName) where T : new()
        {
            T retu = default(T);
            try
            {
                if (IsMockUpRequest)
                {
                    string path = System.Web.HttpContext.Current.Server.MapPath("~/MockupData/") + fileName;
                    StreamReader reader = File.OpenText(path);
                    string content = reader.ReadToEnd();
                    retu = JsonConverter.FromJsonTo<T>(content);
                }
            }
            catch (Exception ex)
            {
                //don't throw exception again.
                Log.Error(ex);
            }

            return retu;
        }

        public static Stream ProcessMockupData(string fileName)
        {
            Stream retu = null;
            try
            {
                if (IsMockUpRequest)
                {
                    string path = System.Web.HttpContext.Current.Server.MapPath("~/MockupData/") + fileName;
                    retu = File.OpenRead(path);
                }
            }
            catch (Exception ex)
            {
                //don't throw exception again.
                Log.Error(ex);
            }

            return retu;
        }

        public static bool IsMockUpRequest
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Server != null
                   && HttpContext.Current.Request["IsMockUpRequest"] != null && HttpContext.Current.Request["IsMockUpRequest"].ToUpper() == "TRUE")
                {
                    return true;
                }

                return false;
            }
        }
    }
}
