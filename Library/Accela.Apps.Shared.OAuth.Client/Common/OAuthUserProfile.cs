using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Accela.Apps.Shared.OAuth
{
    [DataContract]
    [Serializable]
    public class OAuthUserProfile
    {
        private string _id;
        [DataMember(Name = "id")]
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value != null ? value.Trim() : null;
            }
        }

        private string _screenName;
        [DataMember(Name = "name")]
        public string ScreenName
        {
            get
            {
                return _screenName;
            }

            set
            {
                _screenName = value != null ? value.Trim() : null;
            }
        }

        private string _firstName;
        [DataMember(Name = "firstName")]
        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value != null ? value.Trim() : null;
            }
        }

        private string _lastName;
        [DataMember(Name = "lastName")]
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value != null ? value.Trim() : null;
            }
        }

        private string _email;
        [DataMember(Name = "email")]
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value != null ? value.Trim() : null;
            }
        }

        [DataMember(Name = "pictureUrl")]
        public string PictureUrl { get; set; }

        [DataMember(Name = "oAuthProvider")]
        public OAuthProvider OAuthProvider { get; set; }

        public string GetFullName()
        {
            var fullName = String.Format("{0} {1}", this.FirstName, this.LastName);
            var result = !String.IsNullOrWhiteSpace(fullName) ? fullName : this.ScreenName;
            return result;
        }
    }
}
