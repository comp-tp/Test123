//-----------------------------------------------------------------------
// <copyright file="WindowsLiveClient.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Accela.Apps.Shared.OAuth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DotNetOpenAuth.OAuth2;

    public class WindowsLiveClient : WebServerClient
    {
        private static AuthorizationServerDescription WindowsLiveDescription(bool forceNewLogin)
        {
            var authorizationQueryString = forceNewLogin ? "?auth_type=reauthenticate" : "";
            return new AuthorizationServerDescription
            {
                TokenEndpoint = new Uri("https://oauth.live.com/token"),
                AuthorizationEndpoint = new Uri("https://oauth.live.com/authorize" + authorizationQueryString),
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsLiveClient"/> class.
        /// </summary>
        public WindowsLiveClient(bool forceNewLogin)
            : base(WindowsLiveDescription(forceNewLogin))
        {
            this.AuthorizationTracker = new TokenManager();
        }

        public WindowsLiveGraph ProcessAllBasicSteps()
        {
            WindowsLiveGraph result = null;
            var authorization = this.ProcessUserAuthorization();

            if (authorization == null)
            {
                // Kick off authorization request
                this.RequestUserAuthorization(scope: new[] { Scopes.Basic, Scopes.Emails }); // this scope isn't even required just to log in
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(authorization.AccessToken))
                {
                    result = WindowsLiveGraph.GetUserProfile(authorization.AccessToken);
                }
                else
                {
                    var cancelException = new OAuthCancelException();
                    throw cancelException;
                }
            }

            return result;
        }

        /// <summary>
        /// Well-known scopes defined by the Windows Live service.
        /// </summary>
        /// <remarks>
        /// This sample includes just a few scopes.  For a complete list of scopes please refer to:
        /// http://msdn.microsoft.com/en-us/library/hh243646.aspx
        /// </remarks>
        public static class Scopes
        {
            /// <summary>
            /// The ability of an app to read and update a user's info at any time. Without this scope, an app can access the user's info only while the user is signed in to Live Connect and is using your app.
            /// </summary>
            public const string OfflineAccess = "wl.offline_access";

            /// <summary>
            /// Single sign-in behavior. With single sign-in, users who are already signed in to Live Connect are also signed in to your website.
            /// </summary>
            public const string SignIn = "wl.signin";

            /// <summary>
            /// Read access to a user's basic profile info. Also enables read access to a user's list of contacts.
            /// </summary>
            public const string Basic = "wl.basic";

            public const string Emails = "wl.emails";
        }
    }
}
