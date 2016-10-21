using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Core.Configurations;
using Accela.Core.Ioc;
using Accela.Core.Logging;
using Accela.Infrastructure.Configurations;
using System;
using System.IO;
using System.Text;
using System.Web;

namespace Accela.Apps.Shared.APIHandlers.Helpers
{
    public static class WebLogHelper
    {
        private static ILog Log
        {
            get
            {
                var logger = IocContainer.Resolve<ILogger>();
                return LogFactory.GetLog(logger);
            }
        }

        private static IConfigurationReader ConfigurationReader { get { return ConfigurationSettingsManager.Get(); } }

        public static void LogRequest(IAgencyAppContext context, HttpRequestBase request, string methodName=null)
        {
            try
            {
                StringBuilder requestContent = new StringBuilder();
                requestContent.Append("URL:").Append(request.Path).Append(";");
                requestContent.Append("Content-Type:").Append(request.ContentType).Append(";");
                requestContent.Append("Header:").Append(request.Headers).Append(";");

                if (request.HttpMethod.Equals("GET") && request.InputStream != null)
                {
                    requestContent.Append("Body:");
                    // TODO skip binary in the future
                    //if (request.Content is StreamContent && request.Content.Headers != null
                    //     && IsBinaryContent(request.Content.Headers))
                    //{
                    //    requestContent.Append("<binary>");
                    //}
                    //else
                    {
                        string requestData = GetRequestContents(request);
                        requestContent.Append(requestData);
                    }
                }

                LogEntity logData = new LogEntity()
                {
                    TraceId = context.TraceID,
                    MethodName = (methodName==null?"HttpRequest" : methodName),
                    RequestFrom = context.SubSystemCaller,
                    RequestTo = ConfigurationReader.Get(ConfigurationConstant.CURRENT_SUB_SYSTEM),
                    Detail = requestContent.ToString(),
                    AppId = context.App,
                    Agency = context.Agency,
                    EnvName = context.EnvName,
                    UserName = context.LoginName,
                };

                Log.Info(logData);
            }
            catch (Exception exception)
            {
                var logData = new LogEntity
                {
                    TraceId = context.TraceID,
                    Message = "Log Exception",
                    Detail = exception.ToString(),
                    MethodName = "LogRequest()"
                };
                Log.Error(logData);
            }

        }

        private static string GetRequestContents(HttpRequestBase request)
        {
            string contents;
            try {
                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        contents = readStream.ReadToEnd();
                    }
                }
            }catch(Exception e)
            {
                contents = "GetRequestContents.Exception " + e.ToString();
            }

            return contents;
        }

    }
}
