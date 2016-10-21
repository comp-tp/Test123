using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net.Http;
using Accela.Apps.Apis.APIHandlers;
using System.Net;
using Accela.Apps.Shared;
using Accela.Apps.Apis.Models.DomainModels.ResourceModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Accela.Apps.Shared.WSModels;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Apis.WSModels.Common;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Core.Ioc;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Shared.Contexts;


namespace Accela.Apps.Apis.Services.Tests.TestHandlers
{ 
    [TestFixture]
    public class TestMultipleAgenciesRouteHandler : TestBase
    {
        internal const string PROPERTIES_KEY_RESOURCE_MODEL = "ResourceModel";
        private static string APP_ID_AGENCY = "1111";
        private static string APP_ID_CITIZEN = "2222";
        
        private static ResourceModel GetRecordsResource = new ResourceModel
            {
                Api = "/v4/records",
                HttpVerb = "GET",
                IsAAGovXMLAPI = 1,
                IsProxy = 1,
                AuthenticationType = 0
            };

        [SetUp]
        public void Init()
        {
            //container.Register<CacheStoreProvider, MemoryCacheStoreProvider>(ServiceLifecycle.Singleton);
            base.SetUp();
        }

        [TearDown]
        public void Dispose()
        {

        }


        [Test]
        public void TestMultipleAgenciesRouteHandler_ShouldSkipIfRequestIsNotDataAggregatin()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records");

            var handler = new MultipleAgenciesRouteHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return TestHandler.Return200();
                })
            };

            var client = new HttpClient(handler);
            Context.TraceID = "UT-" + Guid.NewGuid().ToString();
            Context.App = APP_ID_CITIZEN;

            var result = client.SendAsync(httpRequestMessage).Result;

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void TestMultipleAgenciesRouteHandler_ShouldThrowExceptionIfInvalidAgencyUser()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/batch");

            var handler = new MultipleAgenciesRouteHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return TestHandler.Return200();
                })
            };
            
            var client = new HttpClient(handler);
            var traceId = "UT-" + Guid.NewGuid().ToString();
            Context.TraceID = traceId;
            Context.App = APP_ID_AGENCY;
            Context.AppType = Shared.Contants.AppType.Agency;
            // not exist user
            Context.ContextUser = new ContextUser { Id =Guid.NewGuid()};

            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = GetRecordsResource;
            httpRequestMessage.Headers.TryAddWithoutValidation("x-accela-agencies", "Jackie-BPTDEV");
            var result = client.SendAsync(httpRequestMessage).Result;

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            
            string resultContent =result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);
            var errorResponse = JsonConvert.DeserializeObject<WSErrorResponse>(resultContent);

            Assert.IsNotNull(errorResponse);

            Assert.AreEqual((int)HttpStatusCode.BadRequest, errorResponse.Status);
            Assert.AreEqual(ErrorCodes.bad_request_400, errorResponse.Code);
            Assert.AreEqual("No account is linked to current Civic Id.", errorResponse.Message);
            Assert.AreEqual(traceId, errorResponse.TraceId);
        }

        [Test]
        public void TestMultipleAgenciesRouteHandler_ShouldThrowExceptionIfInvalidCitizenUser()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records");

            var handler = new MultipleAgenciesRouteHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return TestHandler.Return200();
                })
            };

            var client = new HttpClient(handler);
            var traceId = "UT-" + Guid.NewGuid().ToString();
            Context.TraceID = traceId;
            Context.App = APP_ID_CITIZEN;
            Context.AppType = Shared.Contants.AppType.Citizen;
            // not exist user
            Context.ContextUser = new ContextUser { Id = Guid.NewGuid() };

            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = GetRecordsResource;
            httpRequestMessage.Headers.TryAddWithoutValidation("x-accela-agencies", "Jackie-BPTDEV");
            var result = client.SendAsync(httpRequestMessage).Result;

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

            string resultContent = result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);
            var errorResponse = JsonConvert.DeserializeObject<WSErrorResponse>(resultContent);

            Assert.IsNotNull(errorResponse);

            Assert.AreEqual((int)HttpStatusCode.BadRequest, errorResponse.Status);
            Assert.AreEqual(ErrorCodes.bad_request_400, errorResponse.Code);
            Assert.AreEqual("No citizen account is linked to current Civic Id.", errorResponse.Message);
            Assert.AreEqual(traceId, errorResponse.TraceId);
        }

        [Test]
        public void TestMultipleAgenciesRouteHandler_ShouldThrowUnauthorizedIfBizTokenExpired()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records");
            var traceId = "UT-" + Guid.NewGuid().ToString();
            var handler = new MultipleAgenciesRouteHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return Task.Factory.StartNew(
                () =>
                {
                    string content = "{\"status\":401,\"code\":\"unauthorized\",\"message\":\"SSO authentication failed.\",\"traceId\":\"" + traceId + "\"}";
                    
                    var responses = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    responses.Content = new StringContent(content);
                    return responses;
                }
                    );
                })
            };

            var client = new HttpClient(handler);
            
            Context.TraceID = traceId;
            Context.App = APP_ID_CITIZEN;
            Context.AppType = Shared.Contants.AppType.Citizen;
            Context.EnvName = "PROD";
            // jyu@accela.com
            Context.ContextUser = new ContextUser { Id = Guid.Parse("04F2DBB7-92D9-4D56-A235-39D9E4193747") };
          
            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = GetRecordsResource;
            httpRequestMessage.Headers.TryAddWithoutValidation("x-accela-agencies", "ALL");
            var result = client.SendAsync(httpRequestMessage).Result;

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));

            string resultContent = result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);
            var errorResponse = JsonConvert.DeserializeObject<WSErrorResponse>(resultContent);

            Assert.IsNotNull(errorResponse);

            Assert.AreEqual((int)HttpStatusCode.Unauthorized, errorResponse.Status);
            Assert.AreEqual(ErrorCodes.unauthorized_401, errorResponse.Code);
            Assert.AreEqual("SSO authentication failed.", errorResponse.Message);
            Assert.AreEqual(traceId, errorResponse.TraceId);
        }

        [Test]
        public void TestMultipleAgenciesRouteHandler_ShouldAggregationAll()
        {
            string contentPerOneAgency = @"{
  ""result"": [
    {

      ""id"": ""15EST-00000-00014"",
	  ""resource"": {
        ""agency"": ""Jackie-BPTDEV"",
        ""environment"": ""PROD""
      }
	}
  ],
  ""status"": 200
}";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records");
            var traceId = "UT-" + Guid.NewGuid().ToString();
            var handler = new MultipleAgenciesRouteHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return Task.Factory.StartNew(
                () =>
                {
                    var responses = new HttpResponseMessage(HttpStatusCode.OK);
                    responses.Content = new StringContent(contentPerOneAgency);
                    return responses;
                }
                    );
                })
            };

            var client = new HttpClient(handler);

            Context.TraceID = traceId;
            Context.App = APP_ID_CITIZEN;
            Context.AppType = Shared.Contants.AppType.Citizen;
            Context.EnvName = "PROD";
            // jyu@accela.com
            Context.ContextUser = new ContextUser { Id = Guid.Parse("04F2DBB7-92D9-4D56-A235-39D9E4193747") };

            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = GetRecordsResource;
            httpRequestMessage.Headers.TryAddWithoutValidation("x-accela-agencies", "ALL");
            var result = client.SendAsync(httpRequestMessage).Result;

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            string resultContent = result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);

            string exceptedValue = @"{
  ""result"": [
    {
      ""id"": ""15EST-00000-00014"",
      ""resource"": {
        ""agency"": ""Jackie-BPTDEV"",
        ""environment"": ""PROD""
      }
    },
    {
      ""id"": ""15EST-00000-00014"",
      ""resource"": {
        ""agency"": ""Jackie-DOS"",
        ""environment"": ""PROD""
      }
    }
  ],
  ""status"": 200
}";
            Assert.AreEqual(exceptedValue, resultContent);
        }



        [Test]
        public void TestMultipleAgenciesRouteHandler_ShouldAggregation2Agencies()
        {
            string contentPerOneAgency = @"{
  ""result"": [
    {

      ""id"": ""15EST-00000-00014"",
	  ""resource"": {
        ""agency"": ""Jackie-BPTDEV"",
        ""environment"": ""PROD""
      }
	}
  ],
  ""status"": 200
}";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records");
            var traceId = "UT-" + Guid.NewGuid().ToString();
            var handler = new MultipleAgenciesRouteHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return Task.Factory.StartNew(
                () =>
                {
                    var responses = new HttpResponseMessage(HttpStatusCode.OK);
                    responses.Content = new StringContent(contentPerOneAgency);
                    return responses;
                }
                    );
                })
            };

            var client = new HttpClient(handler);

            Context.TraceID = traceId;
            Context.App = APP_ID_CITIZEN;
            Context.AppType = Shared.Contants.AppType.Citizen;
            Context.EnvName = "PROD";
            // jyu@accela.com
            Context.ContextUser = new ContextUser { Id = Guid.Parse("04F2DBB7-92D9-4D56-A235-39D9E4193747") };

            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = GetRecordsResource;
            httpRequestMessage.Headers.TryAddWithoutValidation("x-accela-agencies", "Jackie-BPTDEV,Jackie-DOS");
            var result = client.SendAsync(httpRequestMessage).Result;

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            string resultContent = result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);

            string exceptedValue = @"{
  ""result"": [
    {
      ""id"": ""15EST-00000-00014"",
      ""resource"": {
        ""agency"": ""Jackie-BPTDEV"",
        ""environment"": ""PROD""
      }
    },
    {
      ""id"": ""15EST-00000-00014"",
      ""resource"": {
        ""agency"": ""Jackie-DOS"",
        ""environment"": ""PROD""
      }
    }
  ],
  ""status"": 200
}";
            Assert.AreEqual(exceptedValue, resultContent);
        }

        [Test]
        public void TestMultipleAgenciesRouteHandler_ShouldThrowUnauthorizedIfNotLinkedAgencyAccount()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records");
            var traceId = "UT-" + Guid.NewGuid().ToString();
            var handler = new MultipleAgenciesRouteHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return Task.Factory.StartNew(
                () =>
                {
                    string content = "{\"status\":400,\"code\":\"bad_request\",\"message\":\"No account is linked to current Civic Id.\",\"traceId\":\"" + traceId+ "\"}";
                    var responses = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    responses.Content = new StringContent(content);
                    return responses;
                }
                    );
                })
            };

            var client = new HttpClient(handler);

            Context.TraceID = traceId;
            Context.App = APP_ID_AGENCY;
            Context.AppType = Shared.Contants.AppType.Agency;
            Context.EnvName = "PROD";
            // jyu@accela.com
            Context.ContextUser = new ContextUser { Id = Guid.Parse("04F2DBB7-92D9-4D56-A235-39D9E4193747") };

            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = GetRecordsResource;
            httpRequestMessage.Headers.TryAddWithoutValidation("x-accela-agencies", "ALL");
            var result = client.SendAsync(httpRequestMessage).Result;

            string resultContent = result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);
            var errorResponse = JsonConvert.DeserializeObject<WSErrorResponse>(resultContent);

            Assert.IsNotNull(errorResponse);

            Assert.AreEqual((int)HttpStatusCode.BadRequest, errorResponse.Status);
            Assert.AreEqual(ErrorCodes.bad_request_400, errorResponse.Code);
            Assert.AreEqual("No account is linked to current Civic Id.", errorResponse.Message);
            Assert.AreEqual(traceId, errorResponse.TraceId);
        }

        [Test]
        public void TestMultipleAgenciesRouteHandler_ShouldThrowBadRequestIfNoToken()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records");
            var traceId = "UT-" + Guid.NewGuid().ToString();
            var handler = new MultipleAgenciesRouteHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return Task.Factory.StartNew(
                () =>
                {
                    string content = "{\"status\":400,\"code\":\"bad_request\",\"message\":\"Token is required for data aggregation.\",\"traceId\":\"" + traceId + "\"}";
                    var responses = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                    responses.Content = new StringContent(content);
                    return responses;
                }
                    );
                })
            };

            var client = new HttpClient(handler);

            Context.ContextUser = null;
            Context.TraceID = traceId;
            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = GetRecordsResource;
            httpRequestMessage.Headers.TryAddWithoutValidation("x-accela-agencies", "ALL");
            var result = client.SendAsync(httpRequestMessage).Result;

            string resultContent = result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);
            var errorResponse = JsonConvert.DeserializeObject<WSErrorResponse>(resultContent);

            Assert.IsNotNull(errorResponse);

            Assert.AreEqual((int)HttpStatusCode.BadRequest, errorResponse.Status);
            Assert.AreEqual(ErrorCodes.bad_request_400, errorResponse.Code);
            Assert.AreEqual(traceId, errorResponse.TraceId);
        }

        
        [Test]
        public void TestMultipleAgenciesRouteHandler_ShouldAggregateEvenIfNoResult()
        {
 string contentPerOneAgency = @"{
  ""status"": 200
}";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records");
            var traceId = "UT-" + Guid.NewGuid().ToString();
            var handler = new MultipleAgenciesRouteHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return Task.Factory.StartNew(
                () =>
                {
                    var responses = new HttpResponseMessage(HttpStatusCode.OK);
                    responses.Content = new StringContent(contentPerOneAgency);
                    return responses;
                }
                    );
                })
            };

            var client = new HttpClient(handler);

            Context.TraceID = traceId;
            Context.App = APP_ID_CITIZEN;
            Context.AppType = Shared.Contants.AppType.Citizen;
            Context.EnvName = "PROD";
            // jyu@accela.com
            Context.ContextUser = new ContextUser { Id = Guid.Parse("04F2DBB7-92D9-4D56-A235-39D9E4193747") };

            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = GetRecordsResource;
            httpRequestMessage.Headers.TryAddWithoutValidation("x-accela-agencies", "Jackie-BPTDEV,Jackie-DOS");
            var result = client.SendAsync(httpRequestMessage).Result;

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            string resultContent = result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);

            string exceptedValue = @"{
  ""status"": 200
}";
            Assert.AreEqual(exceptedValue, resultContent);
        }
    }


}
