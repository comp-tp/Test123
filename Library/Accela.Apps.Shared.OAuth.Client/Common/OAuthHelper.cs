using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetOpenAuth.OAuth2;
using System.Globalization;
using System.Web;
using Accela.Core.Ioc;
using Accela.Core.Configurations;
using Accela.Infrastructure.Configurations;

namespace Accela.Apps.Shared.OAuth
{
    public static class OAuthHelper
    {
        //private readonly static Func<IConfiguration> ConfigurationSettingsProvider;
        private static IConfigurationReader ConfigurationSettings { get { return ConfigurationSettingsManager.Get(); } }

        static OAuthHelper()
        {
            //ConfigurationSettingsProvider = ConfigurationProvider.Instance.Get; //IocContainer.Resolve<IConfiguration>();
        }

        public static OAuthUserProfile Login(OAuthProvider provider, bool forceNewLogin = false)
        {
            OAuthUserProfile result = null;

            switch (provider)
            {
                case OAuthProvider.Facebook:
                    result = LoginWithFacebook(forceNewLogin);
                    break;
                case OAuthProvider.Twitter:
                    result = LoginWithTwitter(forceNewLogin);
                    break;
                case OAuthProvider.WindowsLive:
                    result = LoginWithWindowsLive(forceNewLogin);
                    break;
                case OAuthProvider.GooglePlus:
                    //result = LoginWithGooglePlus();
                    break;
                case OAuthProvider.Yahoo:
                    //result = LoginWithYahoo();
                    break;
            }

            return result;
        }

        /// <summary>
        /// Builds the querystring, remove the keyValue with any empty of key or value.
        /// as some social service provider can't accept the key with no value.
        /// </summary>
        /// <param name="keyValuePair">The key value pair.</param>
        /// <returns>query string</returns>
        public static string BuildQuerystring(Dictionary<string, string> keyValuePair)
        {
            String result = String.Empty;
            var keyValuePattern = "{0}={1}";

            if (keyValuePair != null)
            {
                var filteredKeyValuePair = (from kv in keyValuePair
                                            where !String.IsNullOrWhiteSpace(kv.Key)
                                            && !String.IsNullOrWhiteSpace(kv.Value)
                                            select String.Format(keyValuePattern, kv.Key, HttpUtility.UrlEncode(kv.Value))).ToArray();

                if (filteredKeyValuePair != null && filteredKeyValuePair.Length > 0)
                {
                    result = String.Join("&", filteredKeyValuePair);
                }
            }

            return result;
        }

        public static OAuthProvider ParseProvider(string providerString)
        {
            providerString = providerString != null ? providerString.Trim() : null;
            var result = (OAuthProvider)Enum.Parse(typeof(OAuthProvider), providerString, true);
            return result;
        }

        private static OAuthUserProfile LoginWithFacebook(bool forceNewLogin = false)
        {
            OAuthUserProfile result = null;
            var client = new FacebookClient(forceNewLogin)
            {
                ClientIdentifier = ConfigurationSettings.Get(ConfigurationConstant.OAUTH_FACEBOOK_APP_ID),
                ClientCredentialApplicator = ClientCredentialApplicator.PostParameter(ConfigurationSettings.Get(ConfigurationConstant.OAUTH_FACEBOOK_APP_SECRET))
            };

            var userProfile = client.ProcessAllBasicSteps();

            if (userProfile != null)
            {
                result = new OAuthUserProfile()
                {
                    Email = userProfile.Email,
                    FirstName = userProfile.FirstName,
                    Id = userProfile.Id.ToString(CultureInfo.InvariantCulture),
                    LastName = userProfile.LastName,
                    ScreenName = userProfile.Name,
                    PictureUrl = userProfile.PictureUrl,
                    OAuthProvider = OAuthProvider.Facebook
                };
            }

            return result;
        }

        private static OAuthUserProfile LoginWithTwitter(bool forceNewLogin = false)
        {
            OAuthUserProfile result = null;

            string screenName;
            long userId;

            //second step
            if (TwitterConsumer.TryFinishSignInWithTwitter(out screenName, out userId))
            {
                var pictureUrl = TwitterConsumer.GetPictureUrl(screenName);

                result = new OAuthUserProfile()
                {
                    Id = userId.ToString(CultureInfo.InvariantCulture),
                    ScreenName = screenName,
                    PictureUrl = pictureUrl,
                    OAuthProvider = OAuthProvider.Twitter
                };
            }
            else
            {
                //first step(if set to false, once two different account login by this computer will confuse)
                TwitterConsumer.StartSignInWithTwitter(forceNewLogin).Send();
            }

            return result;
        }

        private static OAuthUserProfile LoginWithWindowsLive(bool forceNewLogin = false)
        {
            OAuthUserProfile result = null;
            var client = new WindowsLiveClient(forceNewLogin)
            {
                ClientIdentifier = ConfigurationSettings.Get(ConfigurationConstant.OAUTH_WINDOWS_LIVE_APP_ID),
                ClientCredentialApplicator = ClientCredentialApplicator.PostParameter(ConfigurationSettings.Get(ConfigurationConstant.OAUTH_WINDOWS_LIVE_APP_SECRET))
            };

            var userProfile = client.ProcessAllBasicSteps();

            if (userProfile != null)
            {
                result = new OAuthUserProfile()
                {
                    Email = userProfile.Email,
                    FirstName = userProfile.FirstName,
                    Id = userProfile.Id.ToString(CultureInfo.InvariantCulture),
                    LastName = userProfile.LastName,
                    ScreenName = userProfile.Name,
                    PictureUrl = userProfile.PictureUrl,
                    OAuthProvider = OAuthProvider.WindowsLive
                };
            }

            return result;
        }
    }
}
