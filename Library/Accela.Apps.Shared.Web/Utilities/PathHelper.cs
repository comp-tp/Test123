namespace Accela.Apps.Shared.Web.Utilities
{
    /// <summary>
    /// Config class.
    /// </summary>
    public static class PathHelper
    {
        /// <summary>
        /// Gets root virtual path of application, like /myapp.
        /// If no virtual path, returns empty
        /// </summary>
        /// <returns>application </returns>
        public static string GetApplicationVirtualPath()
        {
            string virturalPath = System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;

            if (virturalPath == null) return string.Empty;

            if (virturalPath.EndsWith("/"))
            {
                virturalPath = virturalPath.Remove(virturalPath.Length - 1);
            }

            if (virturalPath.Length > 0 && !virturalPath.StartsWith("/"))
            {
                virturalPath = "/" + virturalPath;
            }

            return virturalPath;
        }
    }

}