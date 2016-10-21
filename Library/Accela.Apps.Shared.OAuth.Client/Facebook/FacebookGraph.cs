//-----------------------------------------------------------------------
// <copyright file="FacebookGraph.cs" company="Outercurve Foundation">
//     Copyright (c) Outercurve Foundation. All rights reserved.
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
    public class FacebookGraph
    {
        private static DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(FacebookGraph));

        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "pictureUrl")]
        public string PictureUrl { get; set; }

        public static FacebookGraph GetUserProfile(string accessToken)
        {
            FacebookGraph result = null;
            var requestUrl = "https://graph.facebook.com/me?access_token=" + Uri.EscapeDataString(accessToken);
            var restRequest = new RestRequest(requestUrl, Method.GET);
            var restClient = new RestClient();
            var restResponse = restClient.Execute<FacebookGraph>(restRequest);

            if (restResponse.ResponseStatus == ResponseStatus.Completed && restResponse.StatusCode == HttpStatusCode.OK)
            {
                result = restResponse.Data;
            }

            if (result != null && result.Id > 0)
            {
                result.PictureUrl = String.Format("http://graph.facebook.com/{0}/picture", result.Id);
            }

            return result;
        }

        public static FacebookGraph Deserialize(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentNullException("json");
            }

            return Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(json)));
        }

        public static FacebookGraph Deserialize(Stream jsonStream)
        {
            if (jsonStream == null)
            {
                throw new ArgumentNullException("jsonStream");
            }

            return (FacebookGraph)jsonSerializer.ReadObject(jsonStream);
        }
    }
}
