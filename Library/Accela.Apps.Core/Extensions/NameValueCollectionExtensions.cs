using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Accela.Apps.Core
{
    public static class NameValueCollectionExtensions
    {
        public static string ToNameValueString(this NameValueCollection instance)
        {
            StringBuilder queryString = new StringBuilder();
            foreach (string item in instance.Keys)
            {
                if (queryString.Length > 0)
                    queryString.Append("&");

                queryString.Append(HttpUtility.UrlEncode(item))
                    .Append("=")
                    .Append(HttpUtility.UrlEncode(instance[item]));
            }
            return queryString.ToString();
        }

        public static NameValueCollection ToNameValueCollection(this string instance)
        {
            NameValueCollection collection = new NameValueCollection();
            string[] nameValuePairs = instance.Split('&');
            for (int i = 0; i < nameValuePairs.Length; i++)
            {
                string[] nameValue = nameValuePairs[i].Split('=');
                if (nameValue.Length == 2)
                {
                    collection.Add(HttpUtility.UrlDecode(nameValue[0]), HttpUtility.UrlDecode(nameValue[1]));
                }
            }
            return collection;
        }
    }
}
