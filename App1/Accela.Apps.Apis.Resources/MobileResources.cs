using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Web;
using Accela.Infrastructure.Configurations;
using Accela.Core.Configurations;

namespace Accela.Apps.Apis.Resources
{
    /// <summary>
    /// Mobile Resources Manager class
    /// </summary>
    public class MobileResources
    {
        #region Fields

        private const string USER_PREFERRED_CULTURE_SESSION_KEY = "UserPreferredCulture";
        private const string USER_PREFERRED_CULTURE_COOKIE_KEY = "UserPreferredCulture";
        private static CultureInfo defaultSysCulture = new CultureInfo("en-US");
        private static global::System.Resources.ResourceManager resourceMan;

        private static IConfigurationReader ConfigurationSettings { get { return ConfigurationSettingsManager.Get(); } }

        #endregion Fields

        #region Construction

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MobileResources()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        private static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    resourceMan = new global::System.Resources.ResourceManager("Accela.Apps.Apis.Resources.MobileResources", typeof(MobileResources).Assembly);
                }

                return resourceMan;
            }
        }

        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static CultureInfo UserPreferredCulture
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return GetDefaultCulture();
                }

                CultureInfo culture = null;

                if (HttpContext.Current.Session != null)
                {
                    culture = HttpContext.Current.Session[USER_PREFERRED_CULTURE_SESSION_KEY] as CultureInfo;
                }

                if (culture == null)
                {
                    culture = GetDefaultCulture();
                }

                return culture;
            }

            set
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null)
                {
                    HttpContext.Current.Session[USER_PREFERRED_CULTURE_SESSION_KEY] = value;
                }

                SetCultureToCookie(value);
            }
        }

        #endregion Properties

        #region Private Methods

        /// <summary>
        /// Gets the default CultureInfo, which is set in configuration(web.config).
        /// If not configured, load the en-US as default CultureInfo.
        /// </summary>
        /// <returns>the default CultureInfo</returns>
        private static CultureInfo GetDefaultCulture()
        {
            try
            {
                string defaultCultString = ConfigurationSettings.Get("DefaultCulture", false);

                if (!String.IsNullOrWhiteSpace(defaultCultString))
                {
                    return new CultureInfo(defaultCultString);
                }
            }
            catch
            {
            }

            return defaultSysCulture;
        }

        /// <summary>
        /// set culture to cookie
        /// </summary>
        /// <param name="culture">the culture info</param>
        private static void SetCultureToCookie(CultureInfo culture)
        {
            if (HttpContext.Current == null || culture == null)
            {
                return;
            }

            HttpCookie theCookie = new HttpCookie(USER_PREFERRED_CULTURE_COOKIE_KEY);
            //theCookie.HttpOnly = true;

            if (HttpContext.Current.Request.Url.Scheme.ToLower() == "https")
            {
                theCookie.Secure = true;
            }

            theCookie.Value = culture.Name;
            theCookie.Expires = DateTime.UtcNow.AddDays(90);
            HttpContext.Current.Response.Cookies.Add(theCookie);
        }

        #endregion Private Methods

        #region Public Methods

        /// <summary>
        /// Read the resource file and return the string of specified culture
        /// </summary>
        /// <param name="name">The name of the resource to get.</param>
        /// <param name="culture">The System.Globalization.CultureInfo object that represents the culture for
        /// which the resource is localized. Note that if the resource is not localized
        /// for this culture, the lookup will fall back using the current thread's System.Globalization.CultureInfo.Parent
        /// property, stopping after looking in the neutral culture.If this value is
        /// null, the System.Globalization.CultureInfo is obtained using the current
        /// thread's System.Globalization.CultureInfo.CurrentUICulture property.</param>
        /// <returns>
        /// The value of the resource localized for the specified culture. If a best
        /// match is not possible, null is returned.
        /// </returns>
        public static string GetString(string name, CultureInfo culture)
        {
            return ResourceManager.GetString(name, culture);
        }

        /// <summary>
        /// Returns the value of the specified System.String resource.
        /// </summary>
        /// <param name="name">The name of the resource to get.</param>
        /// <returns>The value of the resource localized for the caller's current culture settings.
        /// If a match is not possible, null is returned.
        /// </returns>
        public static string GetString(string name)
        {
            return ResourceManager.GetString(name, UserPreferredCulture);
        }

        #endregion
    }
}
