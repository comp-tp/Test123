using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Runtime.Serialization;
using System.Web;

namespace Accela.Apps.Shared.OAuth.Token
{
    [Serializable]
    [DataContract]
    public class SimpleWebTokenModel
    {
        private const string KEY_ISSUER = "Issuer";
        private const string KEY_ExpiresOn = "ExpiresOn";
        private const string KEY_Audience = "Audience";
        private const string KEY_HMACSHA256 = "HMACSHA256";
        private List<string> _reservedKeys = new List<string> { KEY_Audience, KEY_ExpiresOn, KEY_HMACSHA256, KEY_ISSUER };

        private static readonly DateTime epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);

        [DataMember]
        private NameValueCollection claimKeyValuePairs;

        public SimpleWebTokenModel()
        {
            this.claimKeyValuePairs = new NameValueCollection();
        }

        private string _issuer;
        [DataMember]
        public string Issuer
        {
            get
            {
                return _issuer;
            }

            set
            {
                _issuer = value != null ? value.Trim() : null;
            }
        }

        private string _audience;
        [DataMember]
        public string Audience
        {
            get
            {
                return _audience;
            }

            set
            {
                _audience = value != null ? value.Trim() : null;
            }
        }

        [DataMember]
        public ulong ExpiresOn { get; private set; }

        public void AddClaim(string name, string value)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                return;
            }

            if (_reservedKeys.Contains(name))
            {
                throw new Exception("Conflict with reserved name: " + name);
            }

            this.claimKeyValuePairs.Add(name, value);
        }

        public void SetExpiresOnFromNowUtcOn(TimeSpan lifeTime)
        {
            TimeSpan ts = DateTime.UtcNow - epochStart + lifeTime;
            this.ExpiresOn = Convert.ToUInt64(ts.TotalSeconds);
        }

        public ulong GetExpiresIn()
        {
            TimeSpan ts = DateTime.UtcNow - epochStart;
            var result = this.ExpiresOn - Convert.ToUInt64(ts.TotalSeconds);

            return result;
        }

        public bool IsExpired()
        {
            bool result = false;
            TimeSpan ts = DateTime.UtcNow - epochStart;

            if (this.ExpiresOn > 0 && this.ExpiresOn < Convert.ToUInt64(ts.TotalSeconds))
            {
                result = true;
            }

            return result;
        }

        public NameValueCollection GetAllKeyValuePairs()
        {
            var allKeyValuePairs = new NameValueCollection();
            allKeyValuePairs.Add(KEY_ISSUER, this.Issuer);
            allKeyValuePairs.Add(KEY_ExpiresOn, this.ExpiresOn.ToString(CultureInfo.InvariantCulture));
            allKeyValuePairs.Add(KEY_Audience, this.Audience);

            if (this.claimKeyValuePairs != null && this.claimKeyValuePairs.Count > 0)
            {
                foreach (string key in this.claimKeyValuePairs.AllKeys)
                {
                    allKeyValuePairs.Add(key, this.claimKeyValuePairs[key]);
                }
            }

            return allKeyValuePairs;
        }

        public static SimpleWebTokenModel Parse(NameValueCollection items)
        {
            if (items == null || items.Count == 0)
            {
                return null;
            }

            var result = new SimpleWebTokenModel();

            foreach (string key in items.AllKeys)
            {
                string item = items[key];

                if (String.IsNullOrWhiteSpace(item))
                {
                    continue;
                }

                switch (key)
                {
                    case KEY_ISSUER:
                        result.Issuer = item;
                        break;
                    case KEY_Audience:
                        result.Audience = item;
                        break;
                    case KEY_ExpiresOn:
                        result.ExpiresOn = ulong.Parse(item);
                        break;
                    case KEY_HMACSHA256:
                        break;
                    default:
                        result.AddClaim(key, items[key]);
                        break;
                }
            }

            return result;
        }

        public static SimpleWebTokenModel Parse(string token)
        {
            var items = HttpUtility.ParseQueryString(token);
            var result = Parse(items);
            return result;
        }
    }
}
