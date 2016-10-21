//using Accela.Core.Ioc;
//using Accela.Core.Ioc.SimpleInjector;
//using Accela.Apps.Core.Log;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Accela.Apps.Apis.Services.Handlers
//{
//    public class AnalyticWriterHandler : DelegatingHandler
//    {
//        private ILogService logger;
//        public AnalyticWriterHandler()
//        {
//            logger = IocContainer.Resolve<ILogService>();
//        }

//        protected override async Task<HttpResponseMessage> SendAsync(
//            HttpRequestMessage request, CancellationToken cancellationToken)
//        {
//            var dtStart = DateTime.Now;         
//            //logging request body
//            string requestBody = await request.Content.ReadAsStringAsync();
//            logger.Info(() => requestBody);

//            //let other handlers process the request
//            return await base.SendAsync(request, cancellationToken)
//                .ContinueWith(task =>
//                {
//                    //once response is ready, log it
//                    var responseBody = task.Result.Content;
//                    logger.Info(() => responseBody);
//                    var dtEnd = DateTime.Now;
//                    var tsProcessingTime = dtEnd - dtStart;
//                    //Debug.WriteLine(tsProcessingTime);
//                    logger.Info(() => tsProcessingTime);
//                    return task.Result;
//                });
//        }
//    }
//}
