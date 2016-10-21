//-----------------------------------------------------------------------
// <copyright file="FacebookClient.cs" company="Outercurve Foundation">
//     Copyright (c) Outercurve Foundation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Accela.Apps.Shared.OAuth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using DotNetOpenAuth.Messaging;
    using DotNetOpenAuth.OAuth2;

    public class FacebookClient : WebServerClient
    {
        private static AuthorizationServerDescription FacebookDescription(bool forceNewLogin)
        {
            // about force login: https://developers.facebook.com/docs/authentication/reauthentication/
            var authorizationQueryString = forceNewLogin ? "?auth_type=reauthenticate" : "";
            return new AuthorizationServerDescription
            {
                TokenEndpoint = new Uri("https://graph.facebook.com/oauth/access_token"),
                AuthorizationEndpoint = new Uri("https://graph.facebook.com/oauth/authorize" + authorizationQueryString),
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FacebookClient"/> class.
        /// </summary>
        public FacebookClient(bool forceNewLogin)
            : base(FacebookDescription(forceNewLogin))
        {
            this.AuthorizationTracker = new TokenManager();
        }

        public FacebookGraph ProcessAllBasicSteps()
        {
            FacebookGraph result = null;
            var authorization = this.ProcessUserAuthorization();

            if (authorization == null)
            {
                // Kick off authorization request
                this.RequestUserAuthorization(scope: new[] { Scopes.Email }); // this scope isn't even required just to log in
            }
            else
            {
                if (!String.IsNullOrWhiteSpace(authorization.AccessToken))
                {
                    result = FacebookGraph.GetUserProfile(authorization.AccessToken);
                }
                else
                {
                    var cancelException = new OAuthCancelException();
                    throw cancelException;
                }
            }

            return result;
        }

        public static class Scopes
        {
            /// <summary>
            /// The ability of an app to read and update a user's info at any time. Without this scope, an app can access the user's info only while the user is signed in to Live Connect and is using your app.
            /// </summary>
            public const string OfflineAccess = "";

            /// <summary>
            /// Single sign-in behavior. With single sign-in, users who are already signed in to Live Connect are also signed in to your website.
            /// </summary>
            public const string SignIn = "";

            /// <summary>
            /// Read access to a user's basic profile info. Also enables read access to a user's list of contacts.
            /// </summary>
            public const string Basic = "";

            public const string Email = "email";
        }
    }
}
