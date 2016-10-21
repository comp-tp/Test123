using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.WSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace Accela.Apps.Shared.APIHandlers
{
    public class DataValidationFilter : ActionFilterAttribute
	{
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext context)
        {
            var modelState = context.ModelState;
            if (modelState.IsValid)       
            {
                base.OnActionExecuting(context);
            }
            else
            {
                // build a json string
                HttpMessage requestMessage = new HttpMessage(context.Request);
                string traceId = requestMessage.GetHeaderValue(ResponseHeaderConstants.X_Accela_Header_TraceId);
                int i = 0;
                StringBuilder sbErrors = new StringBuilder("{");
                foreach (KeyValuePair<string, ModelState> keyValue in modelState)
                {
                    string fieldName = keyValue.Key;
                    string[] values = keyValue.Value.Errors.Select(e => e.ErrorMessage).ToArray<string>();
                    if (values.Length == 0 || String.IsNullOrWhiteSpace(values[0]))
                    {
                        continue;
                    }
                    int postion = fieldName.IndexOf(".");
                    if (postion > -1)
                    {
                        fieldName = fieldName.Substring(postion + 1, fieldName.Length - postion - 1);
                    }
                        
                    // key is property name and value is the error message, 
                    // e.g:{"key1":"[\"v1\",\"v2\"]","key2":"[\"v1\",\"v2\"]"}
                    if (i > 0) sbErrors.Append(",");
                    sbErrors.Append("\"");
                    sbErrors.Append(fieldName);
                    sbErrors.Append("\":");
                    sbErrors.Append("[");
                    
                    if (values != null && values.Length > 0)
                    {
                        for (int j = 0; j < values.Length; j++)
                        {
                            if (j > 0) sbErrors.Append(",");

                            sbErrors.Append("\"").Append(values[j]).Append("\"");
                        }
                    }
                    
                    sbErrors.Append("]");

                    i++;
                }
                sbErrors.Append("}");
                string message = "invalid request data.";

                var error = new WSErrorResponse(HttpStatusCode.BadRequest, ErrorCodes.data_validation_error_400, message, sbErrors.ToString(), traceId);

                context.Response = HttpResponseHelper.BuildErrorResponse(context.Request,error, traceId);
            }
        }
	}
}