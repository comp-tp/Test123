using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.Services.Tests
{

    [TestClass]
    public class SSLClientTest
    {

        [TestMethod]
        public void TestClient()
        {
            ////List<string> strings = new List<string>() { "one", "two", "three" };
            ////var res = strings.Aggregate((current, next) => current == null? "" : string.Format("<span style='color:Red'>{0}</span><br/><span style='color:Red'>{1}</span><br/>", current, next));
            //string path = "https:/acaapps-accela.com////////gateway//////////////wireless//////////";
            //string[] pathParts = path.Split('/');
            //StringBuilder path3 = new StringBuilder();
            //pathParts.ToList().ForEach(p=>
            //    {
            //        path3.Append(string.IsNullOrEmpty(p) ? "" : p + "/");
            //    });

            //string str = "PUT /v4/payment";
            //string[] restrictedApis = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            //restrictedApis.ToList().ForEach(p =>
            //    {
            //        Console.WriteLine(p);
            //    });


            //Console.ReadLine();
            string[] gatewayUrl = new string[2] { "https://gwpt2.dec.accela.com/Gateway", "https://acaapps.accela.com/AA80Gateway" };
            //ServicePointManager.Expect100Continue = true;
            System.Diagnostics.Debug.Print("Default prototol: " + ServicePointManager.SecurityProtocol);
            ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol
        | SecurityProtocolType.Tls11
        | SecurityProtocolType.Tls12;

            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // allows for validation of SSL conversations
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
 
                foreach (string s in gatewayUrl)
                {
                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                    string requestUrl = string.Empty;
                    using (var client = new HttpClient())
                    {
                        // after client created and before sending request
                        //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        // allows for validation of SSL conversations
                        //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                        ///ServicePointManager.ServerCertificateValidationCallback = delegate { System.Diagnostics.Debug.Print("callback"); return true; };


                        //ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                        requestUrl = string.Format("{0}{1}apis/version", s, s.EndsWith("/") ? "" : "/");
                        System.Diagnostics.Debug.Print("Test: " + requestUrl);
                        client.BaseAddress = new Uri(requestUrl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        HttpResponseMessage response = null;
                        try
                        {
                            response = client.GetAsync(requestUrl).Result;
                            System.Diagnostics.Debug.Print("Success result: " + response.Content.ReadAsStringAsync().Result);
                        }
                        catch (WebException ex)
                        {
                            System.Diagnostics.Debug.Print("WebError on " + ex.Status);
                            System.Diagnostics.Debug.Print("WebException: " + ex.ToString());
                            //response = client.GetAsync(requestUrl).Result;
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.Print("Error on " + requestUrl);
                            Exception baseEx = ex.GetBaseException();
                            System.Diagnostics.Debug.Print("Exception: " + baseEx.ToString());
                            //response = client.GetAsync(requestUrl).Result;
                        }
                    }
                System.Diagnostics.Debug.Print("test done");
            }
        }
    }
}
