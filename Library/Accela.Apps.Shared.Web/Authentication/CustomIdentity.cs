using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace Accela.Apps.Shared.Web.Authentication
{
    /// <summary>
    /// Custom idnetity
    /// </summary>
    public class CustomIdentity : IIdentity
    {
        /// <summary>
        /// Gets the area.
        /// </summary>
        public string Area { get; private set; }

        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <returns>The name of the user on whose behalf the code is running.</returns>
        public string Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomIdentity"/> class.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <param name="name">The name.</param>
        public CustomIdentity(string area, string name)
        {
            this.Area = area;
            this.Name = name;
        }

        /// <summary>
        /// Gets the type of authentication used.
        /// </summary>
        /// <returns>The type of authentication used to identify the user.</returns>
        public string AuthenticationType
        {
            get { return "Custom"; }
        }

        /// <summary>
        /// Gets a value that indicates whether the user has been authenticated.
        /// </summary>
        /// <returns>true if the user was authenticated; otherwise, false.</returns>
        public bool IsAuthenticated
        {
            get { return !String.IsNullOrWhiteSpace(this.Name); }
        }
    }
}
