using Accela.Apps.Shared.Utils;
using System;
using System.Web;

namespace Accela.Apps.Shared.Web.Authentication
{
    /// <summary>
    /// Authentication helper to support Area's authentication
    /// </summary>
    public static class AuthenticationHelper
    {
        /// <summary>
        /// Authentication store suffix
        /// </summary>
        const string AUTHENTICATION_STORE_SUFFIX = "User";

        /// <summary>
        /// Determines whether the specified area name is authenticated.
        /// </summary>
        /// <param name="areaName">Name of the area.</param>
        /// <returns>
        /// <c>true</c> if the specified area name is authenticated; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAuthenticated(string areaName)
        {
            var loginName = GetLoginName(areaName);
            var result = !String.IsNullOrWhiteSpace(loginName);
            return result;
        }

        /// <summary>
        /// Gets the custom principal.
        /// </summary>
        /// <param name="areaName">Name of the area.</param>
        /// <returns>the custom principal.</returns>
        public static CustomPrincipal GetCustomPrincipal(string areaName)
        {
            CustomPrincipal result = null;
            var loginName = GetLoginName(areaName);

            if (!String.IsNullOrWhiteSpace(loginName))
            {
                var customIdentity = new CustomIdentity(areaName, loginName);
                var customPricipal = new CustomPrincipal(customIdentity);
                result = customPricipal;
            }

            return result;
        }

        /// <summary>
        /// Saves the user info.
        /// </summary>
        /// <param name="areaName">Name of the area.</param>
        /// <param name="loginName">Name of the user.</param>
        /// <param name="rememberMe">if set to <c>true</c> [remember me].</param>
        public static void SetUserInfoToSession(string areaName, string loginName, bool rememberMe)
        {
            SetLoginName(areaName, loginName);
        }

        /// <summary>
        /// Clears the user info.
        /// </summary>
        /// <param name="areaName">Name of the area.</param>
        public static void ClearUserInfoFromSession(string areaName)
        {
            SetLoginName(areaName, null);
        }

        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <param name="areaName">Name of the area.</param>
        /// <returns>the login name.</returns>
        public static string GetLoginName(string areaName)
        {
            string result = String.Empty;

            if (HttpContext.Current != null)
            {
                var storeKey = GetStoreKey(areaName);
                result = HttpContext.Current.Session[storeKey] as string;
            }

            return result;
        }

        /// <summary>
        /// Gets the store key.
        /// </summary>
        /// <param name="areaName">Name of the area.</param>
        /// <returns>the store key.</returns>
        private static string GetStoreKey(string areaName)
        {
            var applicationFullPath = UrlHelper.GetRequestApplicationFullPath();
            var result = String.Format("{0}_{1}_{2}", applicationFullPath, areaName, AUTHENTICATION_STORE_SUFFIX);
            return result;
        }

        /// <summary>
        /// Sets the name of the user.
        /// </summary>
        /// <param name="areaName">Name of the area.</param>
        /// <param name="loginName">Name of the user.</param>
        private static void SetLoginName(string areaName, string loginName)
        {
            if (HttpContext.Current != null)
            {
                var storeKey = GetStoreKey(areaName);
                HttpContext.Current.Session[storeKey] = loginName;
            }
        }
    }
}
