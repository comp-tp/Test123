
using Accela.Core.Ioc;
using Accela.Core.Logging;
using System;
namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    public class GovXmlHelperBase
    {
        /// <summary>
        /// Get an ILog instance.
        /// </summary>
        protected static ILog Log
        {
            get
            {
                var logger = IocContainer.Resolve<ILogger>();
                return LogFactory.GetLog(logger);
            }
        }

        private const string BizVersion705 = "705";
        private const string BizVersion710 = "710";
        private const string BizVersion720 = "720";
        private const string BizVersion730 = "730";
        private const string BizVersion732 = "732";
        private const string BizVersion733 = "733";
        private const string BizVersion800 = "800";

        protected static string DefaultBizVersion()
        {
            return BizVersion720;
        }

        protected static string ConvertXMLVersion(string version)
        {
            if (string.IsNullOrWhiteSpace(version))
            {
                return DefaultBizVersion();
            }
            else if (BizVersion800.Equals(version))
            {
                return BizVersion733;
            }
            return version;
        }

        protected static bool IsBizVersion705(string version)
        {
            return !String.IsNullOrEmpty(version) && BizVersion705.Equals(version, StringComparison.InvariantCultureIgnoreCase);
        }

        protected static bool IsBizVersion710(string version)
        {
            return !String.IsNullOrEmpty(version) && BizVersion710.Equals(version, StringComparison.InvariantCultureIgnoreCase);
        }

        protected static bool IsBizVersion730AndLater(string version)
        {
            if (String.IsNullOrEmpty(version))
            {
                return false;
            }

            return !BizVersion705.Equals(version, StringComparison.InvariantCultureIgnoreCase)
                   && !BizVersion710.Equals(version, StringComparison.InvariantCultureIgnoreCase)
                   && !BizVersion720.Equals(version, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
