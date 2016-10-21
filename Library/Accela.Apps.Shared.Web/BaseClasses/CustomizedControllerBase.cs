using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
//using Accela.Apps.Shared.AzureHelpers;
using Accela.Core.Logging;
using Accela.Apps.Shared.Utils;
using Accela.Apps.Shared.Web.Attributes;
using Accela.Apps.Shared.Web.Authentication;
using System.Web.Security;
using Accela.Infrastructure.Configurations;
using Accela.Apps.Shared.Contexts;
using System.Runtime.Remoting.Messaging;
using Accela.Core.Configurations;

namespace Accela.Apps.Shared.Web.BaseClasses
{
    /// <summary>
    /// Customized controller base
    /// </summary>
    public abstract class CustomizedControllerBase : Controller
    {
        public CustomizedControllerBase()
        {
            this.ConfigurationSettings = ConfigurationSettingsManager.Get();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomizedControllerBase"/> class.
        /// </summary>
        public CustomizedControllerBase(IConfigurationReader configurationSettings)
        {
            this.ConfigurationSettings = configurationSettings;
        }

        protected IConfigurationReader ConfigurationSettings { get; private set; }

        /// <summary>
        /// area key
        /// </summary>
        const string Area_Key = "area";

        /// <summary>
        /// Login Redirect Url
        /// </summary>
        const string LOGIN_REDIRECT_URL = "LoginRedirectUrl";

        /// <summary>
        /// time tick when start execute method
        /// </summary>
        long timeStart;

        /// <summary>
        /// request parameters 
        /// </summary>
        string requestParam;

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public string Area { get; set; }

        /// <summary>
        /// Get an instance of ILog.
        /// </summary>
        protected ILog Log
        {
            get
            {
               return LogFactory.GetLog();
            }
        }

        /// <summary>
        /// Log exception.
        /// </summary>
        /// <param name="ex">The excepion.</param>
        /// <returns>return the log id.</returns>
        protected string LogException(Exception ex)
        {
            Log.Error(ex, LogHelper.GetCurrentMethodName());
            var context = (IAgencyAppContext)CallContext.LogicalGetData("ContextEntity");
            return context != null ? context.TraceID : LogUtil.NewTraceID();
        }

        protected bool IsAuthenticated()
        {
            var result = AuthenticationHelper.IsAuthenticated(this.Area);
            return result;
        }

        /// <summary>
        /// Executes the specified request context.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="requestContext"/> parameter is null.</exception>
        protected override void Execute(RequestContext requestContext)
        {
            //timeStart = DateTime.UtcNow.Ticks;
            requestParam = "Input Parameters:(" + requestContext.HttpContext.Request.Form.ToString() + ")";
            this.Area = this.GetAreaName(requestContext.RouteData);
            this.UpdateHttpContextUser(requestContext);
            base.Execute(requestContext);
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            //timeStart = DateTime.UtcNow.Ticks;
            requestParam = "Input Parameters:(" + requestContext.HttpContext.Request.Form.ToString() + ")";
            this.Area = this.GetAreaName(requestContext.RouteData);
            this.UpdateHttpContextUser(requestContext);
            return base.BeginExecute(requestContext, callback, state);
        }

        /// <summary>
        /// Called after the action result that is returned by an action method is executed.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action result</param>
        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
       
        /// <summary>
        /// Called before the action result that is returned by an action method is executed.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action result</param>
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        /// <summary>
        /// Called after the action method is invoked.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            //if (Log.IsDebugEnabled)
            //{
            //    //long timeEnd = System.DateTime.UtcNow.Ticks;
            //    //int timeSpan = Convert.ToInt32((new TimeSpan(timeEnd - timeStart).TotalMilliseconds));

            //    ActionDescriptor actDescriptor = filterContext.ActionDescriptor;
            //    ControllerDescriptor ctrDescriptor = filterContext.ActionDescriptor.ControllerDescriptor;
            //    Type type = ctrDescriptor.ControllerType;

            //    string methodName = type.Namespace + "." + type.Name + "." + actDescriptor.ActionName;
            //    //string detail = requestParam + "\r\n" + "Returned value:(" + filterContext.HttpContext.Response.Status.ToString() + ")";
            //    var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            //    // removed password for log
            //    if(requestParam != null && requestParam.Length > "Input Parameters:()".Length
            //        && "OAuth2Controller".Equals(controllerName,StringComparison.OrdinalIgnoreCase))
            //    {
            //        requestParam = ClearTextPasswordProtectionUtil.ReplaceClearTextPasswordForOAuthAPI(requestParam);
            //    }

            //    Log.Debug("OnActionExecuted Success", requestParam, methodName);
            //}
        }

        protected virtual void OnAuthenticationIgnored(ActionExecutingContext filterContext)
        {
        }

        /// <summary>
        /// Called before the action method is invoked.
        /// </summary>
        /// <param name="filterContext">Information about the current request and action.</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var isAuthenticationIgnored = this.IsAuthenticationIgnored(filterContext);

            if (!isAuthenticationIgnored)
            {
                var isAuthenticated = IsAuthenticated();

                if (!isAuthenticated)
                {
                    var redirectUrl = this.GetLoginRedirectUrl(this.Area);

                    if (String.IsNullOrWhiteSpace(redirectUrl))
                    {
                        throw new Exception("No configured Login Redirection Url.");
                    }

                    filterContext.Result = new EmptyResult();

                    filterContext.HttpContext.Response.Redirect(redirectUrl + "?returnUrl="
                                        + HttpUtility.UrlEncode(filterContext.HttpContext.Request.RawUrl));
                }
            }
            else
            {
                OnAuthenticationIgnored(filterContext);
            }

            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Updates the HTTP context user.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        private void UpdateHttpContextUser(RequestContext requestContext)
        {
            var loginName = AuthenticationHelper.GetLoginName(this.Area);

            if (!String.IsNullOrWhiteSpace(loginName))
            {
                requestContext.HttpContext.User = AuthenticationHelper.GetCustomPrincipal(this.Area);
            }
        }

        /// <summary>
        /// Determines whether current request is authentication ignored.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <returns>
        /// <c>true</c> if current request is authentication ignored; otherwise, <c>false</c>.
        /// </returns>
        private bool IsAuthenticationIgnored(ActionExecutingContext filterContext)
        {
            var controllerAttributes = filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(true);
            var actionAttributes = filterContext.ActionDescriptor.GetCustomAttributes(true);
            var hasIgnoreControllerAuthentication = controllerAttributes.Where(a => a is IgnoreAuthenticationAttribute).Count() > 0;
            var hasIgnoreActionAuthentication = actionAttributes.Where(a => a is IgnoreAuthenticationAttribute).Count() > 0;
            var result = hasIgnoreControllerAuthentication || hasIgnoreActionAuthentication;
            return result;
        }

        /// <summary>
        /// Gets the login redirect URL.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <returns>the login redirect URL.</returns>
        private string GetLoginRedirectUrl(string area)
        {
            string key_name = LOGIN_REDIRECT_URL;// String.Format("{0}{1}", area, LOGIN_REDIRECT_URL);
            string result = ConfigurationSettings.Get(key_name);

            if (String.IsNullOrWhiteSpace(result) && FormsAuthentication.IsEnabled)
            {
                result = FormsAuthentication.LoginUrl;
            }

            return result;
        }

        /// <summary>
        /// Gets the name of the area.
        /// </summary>
        /// <param name="routeData">The route data.</param>
        /// <returns>the name of the area.</returns>
        private string GetAreaName(RouteData routeData)
        {
            var result = routeData.DataTokens[Area_Key] as string;
            return result;
        }
    }
}
