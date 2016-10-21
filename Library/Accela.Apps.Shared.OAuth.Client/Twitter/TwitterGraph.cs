//-----------------------------------------------------------------------
// <copyright file="TwitterGraph.cs" company="Outercurve Foundation">
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
    public class TwitterGraph
    {
        private static DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(TwitterGraph));

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

        public static TwitterGraph GetUserProfile(string accessToken)
        {
            TwitterGraph result = null;
            //var requestUrl = "https://graph.facebook.com/me?access_token=" + Uri.EscapeDataString(accessToken);
            //var restRequest = new RestRequest(requestUrl, Method.GET);
            //var restClient = new RestClient();
            //var restResponse = restClient.Execute<TwitterGraph>(restRequest);

            //if (restResponse.ResponseStatus == ResponseStatus.Completed && restResponse.StatusCode == HttpStatusCode.OK)
            //{
            //    result = restResponse.Data;
            //}

            return result;
        }

        public static TwitterGraph Deserialize(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentNullException("json");
            }

            return Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(json)));
        }

        public static TwitterGraph Deserialize(Stream jsonStream)
        {
            if (jsonStream == null)
            {
                throw new ArgumentNullException("jsonStream");
            }

            return (TwitterGraph)jsonSerializer.ReadObject(jsonStream);
        }
    }
}
