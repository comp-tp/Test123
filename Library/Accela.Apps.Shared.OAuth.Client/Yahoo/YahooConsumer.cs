//-----------------------------------------------------------------------
// <copyright file="YahooConsumer.cs" company="Outercurve Foundation">
//     Copyright (c) Outercurve Foundation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Accela.Apps.Shared.OAuth
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Web;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using DotNetOpenAuth.Messaging;
    using DotNetOpenAuth.OAuth;
    using DotNetOpenAuth.OAuth.ChannelElements;

    using Accela.Core.Ioc;
    using Accela.Core.Configurations;
    using Accela.Infrastructure.Configurations;

    /// <summary>
    /// A consumer capable of communicating with Yahoo.
    /// </summary>
    public static class YahooConsumer
    {
        /// <summary>
        /// The description of Yahoo's OAuth protocol URIs for use with actually reading/writing
        /// a user's private Yahoo data.
        /// </summary>
        public static readonly ServiceProviderDescription ServiceDescription = new ServiceProviderDescription
        {
            RequestTokenEndpoint = new MessageReceivingEndpoint("https://api.login.yahoo.com/oauth/v2/get_request_token", HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
            UserAuthorizationEndpoint = new MessageReceivingEndpoint("https://api.login.yahoo.com/oauth/v2/request_auth", HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
            AccessTokenEndpoint = new MessageReceivingEndpoint("https://api.login.yahoo.com/oauth/v2/get_token", HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
            TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new HmacSha1SigningBindingElement() },
        };

        /// <summary>
        /// The description of Yahoo's OAuth protocol URIs for use with their "Sign in with Yahoo" feature.
        /// </summary>
        public static readonly ServiceProviderDescription SignInWithYahooServiceDescription = new ServiceProviderDescription
        {
            RequestTokenEndpoint = new MessageReceivingEndpoint("https://api.login.yahoo.com/oauth/v2/get_request_token", HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
            UserAuthorizationEndpoint = new MessageReceivingEndpoint("https://api.login.yahoo.com/oauth/v2/request_auth", HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
            AccessTokenEndpoint = new MessageReceivingEndpoint("https://api.login.yahoo.com/oauth/v2/get_token", HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest),
            TamperProtectionElements = new ITamperProtectionChannelBindingElement[] { new HmacSha1SigningBindingElement() },
        };

        /// <summary>
        /// The URI to get a user's favorites.
        /// </summary>
        private static readonly MessageReceivingEndpoint GetFavoritesEndpoint = new MessageReceivingEndpoint("http://yahoo.com/favorites.xml", HttpDeliveryMethods.GetRequest);

        /// <summary>
        /// The URI to get the data on the user's home page.
        /// </summary>
        private static readonly MessageReceivingEndpoint GetFriendTimelineStatusEndpoint = new MessageReceivingEndpoint("http://yahoo.com/statuses/friends_timeline.xml", HttpDeliveryMethods.GetRequest);

        private static readonly MessageReceivingEndpoint UpdateProfileBackgroundImageEndpoint = new MessageReceivingEndpoint("http://yahoo.com/account/update_profile_background_image.xml", HttpDeliveryMethods.PostRequest | HttpDeliveryMethods.AuthorizationHeaderRequest);

        private static readonly MessageReceivingEndpoint UpdateProfileImageEndpoint = new MessageReceivingEndpoint("http://yahoo.com/account/update_profile_image.xml", HttpDeliveryMethods.PostRequest | HttpDeliveryMethods.AuthorizationHeaderRequest);

        private static readonly MessageReceivingEndpoint VerifyCredentialsEndpoint = new MessageReceivingEndpoint("http://api.yahoo.com/1/account/verify_credentials.xml", HttpDeliveryMethods.GetRequest | HttpDeliveryMethods.AuthorizationHeaderRequest);

        //private readonly static Func<IConfiguration> ConfigurationSettingsProvider;
        private static IConfigurationReader ConfigurationSettings { get { return ConfigurationSettingsManager.Get(); } }


        /// <summary>
        /// The consumer used for the Sign in to Yahoo feature.
        /// </summary>
        private static WebConsumer signInConsumer;

        /// <summary>
        /// The lock acquired to initialize the <see cref="signInConsumer"/> field.
        /// </summary>
        private static object signInConsumerInitLock = new object();

        /// <summary>
        /// Initializes static members of the <see cref="YahooConsumer"/> class.
        /// </summary>
        static YahooConsumer()
        {
            //ConfigurationSettingsProvider = ConfigurationProvider.Instance.Get; //IocContainer.Resolve<IConfiguration>();
            // Yahoo can't handle the Expect 100 Continue HTTP header. 
            ServicePointManager.FindServicePoint(GetFavoritesEndpoint.Location).Expect100Continue = false;
        }

        /// <summary>
        /// Gets a value indicating whether the Yahoo consumer key and secret are set in the web.config file.
        /// </summary>
        public static bool IsYahooConsumerConfigured
        {
            get
            {
                var consumerKey = ConfigurationSettings.Get(ConfigurationConstant.OAUTH_YAHOO_CONSUMER_KEY);
                var consumerSecret = ConfigurationSettings.Get(ConfigurationConstant.OAUTH_YAHOO_CONSUMER_SECRET);
                return !string.IsNullOrEmpty(consumerKey) && !string.IsNullOrEmpty(consumerSecret);
            }
        }

        /// <summary>
        /// Gets the consumer to use for the Sign in to Yahoo feature.
        /// </summary>
        /// <value>The yahoo sign in.</value>
        private static WebConsumer YahooSignIn
        {
            get
            {
                if (signInConsumer == null)
                {
                    lock (signInConsumerInitLock)
                    {
                        if (signInConsumer == null)
                        {
                            signInConsumer = new WebConsumer(SignInWithYahooServiceDescription, ShortTermUserSessionTokenManager);
                        }
                    }
                }

                return signInConsumer;
            }
        }

        private static InMemoryTokenManager ShortTermUserSessionTokenManager
        {
            get
            {
                var store = HttpContext.Current.Session;
                var tokenManager = (InMemoryTokenManager)store["YahooShortTermUserSessionTokenManager"];
                if (tokenManager == null)
                {
                    var consumerKey = ConfigurationSettings.Get(ConfigurationConstant.OAUTH_YAHOO_CONSUMER_KEY);
                    var consumerSecret = ConfigurationSettings.Get(ConfigurationConstant.OAUTH_YAHOO_CONSUMER_SECRET);

                    if (IsYahooConsumerConfigured)
                    {
                        tokenManager = new InMemoryTokenManager(consumerKey, consumerSecret);
                        store["YahooShortTermUserSessionTokenManager"] = tokenManager;
                    }
                    else
                    {
                        throw new InvalidOperationException("No Yahoo OAuth consumer key and secret could be found in configuratoin file.");
                    }
                }

                return tokenManager;
            }
        }

        public static XDocument GetUpdates(ConsumerBase yahoo, string accessToken)
        {
            IncomingWebResponse response = yahoo.PrepareAuthorizedRequestAndSend(GetFriendTimelineStatusEndpoint, accessToken);
            return XDocument.Load(XmlReader.Create(response.GetResponseReader()));
        }

        public static XDocument GetFavorites(ConsumerBase yahoo, string accessToken)
        {
            IncomingWebResponse response = yahoo.PrepareAuthorizedRequestAndSend(GetFavoritesEndpoint, accessToken);
            return XDocument.Load(XmlReader.Create(response.GetResponseReader()));
        }

        public static XDocument UpdateProfileBackgroundImage(ConsumerBase yahoo, string accessToken, string image, bool tile)
        {
            var parts = new[] {
				MultipartPostPart.CreateFormFilePart("image", image, "image/" + Path.GetExtension(image).Substring(1).ToLowerInvariant()),
				MultipartPostPart.CreateFormPart("tile", tile.ToString().ToLowerInvariant()),
			};
            HttpWebRequest request = yahoo.PrepareAuthorizedRequest(UpdateProfileBackgroundImageEndpoint, accessToken, parts);
            request.ServicePoint.Expect100Continue = false;
            IncomingWebResponse response = yahoo.Channel.WebRequestHandler.GetResponse(request);
            string responseString = response.GetResponseReader().ReadToEnd();
            return XDocument.Parse(responseString);
        }

        public static XDocument UpdateProfileImage(ConsumerBase yahoo, string accessToken, string pathToImage)
        {
            string contentType = "image/" + Path.GetExtension(pathToImage).Substring(1).ToLowerInvariant();
            return UpdateProfileImage(yahoo, accessToken, File.OpenRead(pathToImage), contentType);
        }

        public static XDocument UpdateProfileImage(ConsumerBase yahoo, string accessToken, Stream image, string contentType)
        {
            var parts = new[] {
				MultipartPostPart.CreateFormFilePart("image", "yahooPhoto", contentType, image),
			};
            HttpWebRequest request = yahoo.PrepareAuthorizedRequest(UpdateProfileImageEndpoint, accessToken, parts);
            IncomingWebResponse response = yahoo.Channel.WebRequestHandler.GetResponse(request);
            string responseString = response.GetResponseReader().ReadToEnd();
            return XDocument.Parse(responseString);
        }

        public static XDocument VerifyCredentials(ConsumerBase yahoo, string accessToken)
        {
            IncomingWebResponse response = yahoo.PrepareAuthorizedRequestAndSend(VerifyCredentialsEndpoint, accessToken);
            return XDocument.Load(XmlReader.Create(response.GetResponseReader()));
        }

        public static string GetUsername(ConsumerBase yahoo, string accessToken)
        {
            XDocument xml = VerifyCredentials(yahoo, accessToken);
            XPathNavigator nav = xml.CreateNavigator();
            return nav.SelectSingleNode("/user/screen_name").Value;
        }

        /// <summary>
        /// Prepares a redirect that will send the user to Yahoo to sign in.
        /// </summary>
        /// <param name="forceNewLogin">if set to <c>true</c> the user will be required to re-enter their Yahoo credentials even if already logged in to Yahoo.</param>
        /// <returns>The redirect message.</returns>
        /// <remarks>
        /// Call <see cref="OutgoingWebResponse.Send"/> or
        /// <c>return StartSignInWithYahoo().<see cref="MessagingUtilities.AsActionResult">AsActionResult()</see></c>
        /// to actually perform the redirect.
        /// </remarks>
        public static OutgoingWebResponse StartSignInWithYahoo(bool forceNewLogin)
        {
            var redirectParameters = new Dictionary<string, string>();
            if (forceNewLogin)
            {
                redirectParameters["force_login"] = "true";
            }
            Uri callback = MessagingUtilities.GetRequestUrlFromContext().StripQueryArgumentsWithPrefix("oauth_");
            var request = YahooSignIn.PrepareRequestUserAuthorization(callback, null, redirectParameters);
            return YahooSignIn.Channel.PrepareResponse(request);
        }

        /// <summary>
        /// Checks the incoming web request to see if it carries a Yahoo authentication response,
        /// and provides the user's Yahoo screen name and unique id if available.
        /// </summary>
        /// <param name="screenName">The user's Yahoo screen name.</param>
        /// <param name="userId">The user's Yahoo unique user ID.</param>
        /// <returns>
        /// A value indicating whether Yahoo authentication was successful;
        /// otherwise <c>false</c> to indicate that no Yahoo response was present.
        /// </returns>
        public static bool TryFinishSignInWithYahoo(out string screenName, out int userId)
        {
            screenName = null;
            userId = 0;
            var response = YahooSignIn.ProcessUserAuthorization();
            if (response == null)
            {
                return false;
            }

            screenName = response.ExtraData["screen_name"];
            userId = int.Parse(response.ExtraData["user_id"]);

            // If we were going to make this LOOK like OpenID even though it isn't,
            // this seems like a reasonable, secure claimed id to allow the user to assume.
            //OpenId.Identifier fake_claimed_id = string.Format(CultureInfo.InvariantCulture, "http://yahoo.com/{0}#{1}", screenName, userId);

            return true;
        }
    }
}
