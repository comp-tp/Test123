using Accela.Core.Serialization;
using NLog;

namespace Accela.Core.Analytics
{
    public class NLogTracer : ITrace
    {
        private static global::NLog.Logger _log = LogManager.GetLogger("analytics");

        public void Trace(StatsData data)
        {
            // convert to JSON to log
            var value = JsonSerializerService.Current.Serialize(data);
            _log.Trace(value);
        }
    }
}
