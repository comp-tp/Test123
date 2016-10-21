using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Analytics
{
    public class TraceFactory : ITraceFactory
    {
        private static ITraceFactory _traceFactory = null;
        private static ITrace _tracer = null;

        private TraceFactory()
        {

        }

        public static ITraceFactory Instance
        {
            get
            {
                if (_traceFactory == null)
                {
                    _traceFactory = new TraceFactory();
                }
                return _traceFactory;
            }
        }

        public ITrace GetTracer()
        {
            if (_tracer == null)
            {
                _tracer = new NLogTracer();
            }
            return _tracer;
        }
    }
}
