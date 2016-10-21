using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http.Filters;
using Accela.Apps.Shared.WSModels;
using Accela.Core.Logging;
using Accela.Apps.Shared.Exceptions;
using System.IdentityModel.Tokens;

namespace Accela.Apps.Shared.APIHandlers
{
    public class MobileExceptionFilter : ExceptionFilterAttribute  
    {
        private ILog Log
        {
            get
            {
                return LogFactory.GetLog();
            }
        }

        public override void OnException(HttpActionExecutedContext context) 
        {
            HttpMessage message = new HttpMessage(context.Request);
            string traceId = message.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_TraceId);
            context.Response = ExceptionBuilder.BuildExceptionResponse(context.Request, context.Exception, traceId);
        } 
    } 
}
