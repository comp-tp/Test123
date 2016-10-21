//-----------------------------------------------------------------------
// <copyright file="WindowsLiveGraph.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Accela.Apps.Shared.OAuth
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using RestSharp;
    using System.Net;

    [DataContract]
    public class WindowsLiveEmails
    {
        [DataMember(Name = "preferred")]
        public string Preferred { get; set; }

        [DataMember(Name = "account")]
        public string Account { get; set; }

        [DataMember(Name = "personal")]
        public string Personal { get; set; }

        [DataMember(Name = "business")]
        public string Business { get; set; }
    }

    [DataContract]
    public class WindowsLiveGraph
    {
        private static DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(WindowsLiveGraph));

        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [DataMember(Name = "emails")]
        public WindowsLiveEmails Emails { get; set; }

        [DataMember(Name = "link")]
        public Uri Link { get; set; }

        [DataMember(Name = "gender")]
        public string Gender { get; set; }

        [DataMember(Name = "updated_time")]
        public string UpdatedTime { get; set; }

        [DataMember(Name = "locale")]
        public string Locale { get; set; }

        [DataMember(Name = "pictureUrl")]
        public string PictureUrl { get; set; }

        public static WindowsLiveGraph GetUserProfile(string accessToken)
        {
            WindowsLiveGraph result = null;
            var requestUrl = "https://apis.live.net/v5.0/me?access_token=" + Uri.EscapeDataString(accessToken);
            var restRequest = new RestRequest(requestUrl, Method.GET);
            var restClient = new RestClient();
            var restResponse = restClient.Execute<WindowsLiveGraph>(restRequest);

            if (restResponse.ResponseStatus == ResponseStatus.Completed && restResponse.StatusCode == HttpStatusCode.OK)
            {
                result = restResponse.Data;
            }

            if (result != null && result.Emails != null)
            {
                result.Email = result.Emails.Account;
            }

            if (result != null && !String.IsNullOrWhiteSpace(result.Id))
            {
                result.PictureUrl = String.Format("https://apis.live.net/v5.0/{0}/picture", result.Id);
            }

            return result;
        }

        public static WindowsLiveGraph Deserialize(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentNullException("json");
            }

            return Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(json)));
        }

        public static WindowsLiveGraph Deserialize(Stream jsonStream)
        {
            if (jsonStream == null)
            {
                throw new ArgumentNullException("jsonStream");
            }

            return (WindowsLiveGraph)jsonSerializer.ReadObject(jsonStream);
        }
    }
}
