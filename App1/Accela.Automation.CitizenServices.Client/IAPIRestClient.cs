//using Accela.Apps.Shared.Contants;
//using Accela.Automation.CitizenServices.Client.Models;
//using RestSharp;
//using System;
//namespace Accela.Automation.CitizenServices.Client
//{
//    public interface IAPIRestClient
//    {
//        System.IO.Stream DownloadStream(string resource);
//        string Execute(string resource);
//        T Execute<T>(string resource) where T : class, new();
//        T Execute<T>(string resource, object requestPostBody, Method method = Method.POST, string httpHeaderContentType = Constants.APPLICATION_JSON, string httpHeaderAccept = "") where T : class, new();
//        void Init(ApiCategory apiCategory, string agencyName, string environment, string traceId = null, int requestTimeOut = 0);
//    }
//}
