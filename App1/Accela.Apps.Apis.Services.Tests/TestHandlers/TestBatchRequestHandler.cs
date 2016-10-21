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
using Accela.Apps.Shared.Contexts;
using System.Runtime.Remoting.Messaging;


namespace Accela.Apps.Apis.Services.Tests.TestHandlers
{
    [TestFixture]
    public class TestBatchRequestHandler
    {
        internal const string PROPERTIES_KEY_RESOURCE_MODEL = "ResourceModel";
        private static string APP_ID = "1111";

        private static ResourceModel BatchRequestResourceModel = new ResourceModel
            {
                Api = "/v4/batch",
                HttpVerb = "POST",
                IsAAGovXMLAPI = 0,
                IsProxy = 0,
                AuthenticationType = 0
            };
        [SetUp]
        public void Init()
        {
            
        }

        private void InitContext(IAgencyAppContext context)
        {
            CallContext.LogicalSetData("ContextEntity", context);
        }

        [TearDown]
        public void Dispose()
        {

        }


        [Test]
        public void TestBatchRequestMessageHandler_ShouldSkipIfRequestIsNotBatchRequestAPI()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/records");

            var handler = new BatchRequestHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return TestHandler.Return200();
                })
            };

            var client = new HttpClient(handler);
            var context = new UnKownAgencyAppContext()
            {
                TraceID = "UT-" + Guid.NewGuid().ToString(),
                App = APP_ID
            };
            InitContext(context);

            var result = client.SendAsync(httpRequestMessage).Result;

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

        [Test]
        public void TestBatchRequestMessageHandler_ShouldThrowExceptionIfLoopIncudeBatchAPI()
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/batch");

            var handler = new BatchRequestHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return TestHandler.Return200();
                })
            };
            
            string batchRequestBody=@"
            [
                {
                ""method"": ""POST"",
                ""relativeUrl"": ""/v4/batch"",
                ""body"": {
                ""assetType"":{ }
                }
                }
              ]";
            httpRequestMessage.Content = new StringContent(batchRequestBody);


            var client = new HttpClient(handler);
            var traceId = "UT-" + Guid.NewGuid().ToString();

            var context = new UnKownAgencyAppContext()
            {
                TraceID = traceId,
                App = APP_ID
            };
            InitContext(context);

            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = BatchRequestResourceModel;

            var result = client.SendAsync(httpRequestMessage).Result;

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            
            string resultContent =result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);
            var errorResponse = JsonConvert.DeserializeObject<WSErrorResponse>(resultContent);

            Assert.IsNotNull(errorResponse);

            Assert.AreEqual((int)HttpStatusCode.BadRequest, errorResponse.Status);
            Assert.AreEqual(ErrorCodes.bad_request_400, errorResponse.Code);
            Assert.AreEqual("Invalid request body. Batch api is not allowed as child request.", errorResponse.Message);
            Assert.AreEqual(traceId, errorResponse.TraceId);
        }

        [Test]
        public void TestBatchRequestMessageHandler_ShouldSThrowExceptionIfRequestBodyIsNotJson()
        {

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/batch");

            var handler = new BatchRequestHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return TestHandler.Return200();
                })
            };

            string batchRequestBody = @"xmdka -invalid request body ";
            httpRequestMessage.Content = new StringContent(batchRequestBody);


            var client = new HttpClient(handler);
            var traceId = "UT-" + Guid.NewGuid().ToString();

            var context = new UnKownAgencyAppContext()
            {
                TraceID = traceId,
                App = APP_ID
            };
            InitContext(context);

            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = BatchRequestResourceModel;

            var result = client.SendAsync(httpRequestMessage).Result;

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

            string resultContent = result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);
            var errorResponse = JsonConvert.DeserializeObject<WSErrorResponse>(resultContent);

            Assert.IsNotNull(errorResponse);

            Assert.AreEqual((int)HttpStatusCode.BadRequest, errorResponse.Status);
            Assert.AreEqual(ErrorCodes.bad_request_400, errorResponse.Code);
            Assert.AreEqual("Invalid request body. Failed to parse request body as a json object.", errorResponse.Message);
            Assert.AreEqual(traceId, errorResponse.TraceId);
        }

        [Test]
        public void TestBatchRequestMessageHandler_ShouldSThrowExceptionIfRequestBodyIsEmpty()
        {

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/batch");

            var handler = new BatchRequestHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return TestHandler.Return200();
                })
            };

            string batchRequestBody = @"";
            httpRequestMessage.Content = new StringContent(batchRequestBody);


            var client = new HttpClient(handler);
            var traceId = "UT-" + Guid.NewGuid().ToString();

            var context = new UnKownAgencyAppContext()
            {
                TraceID = traceId,
                App = APP_ID
            };
            InitContext(context);

            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = BatchRequestResourceModel;

            var result = client.SendAsync(httpRequestMessage).Result;

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

            string resultContent = result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);
            var errorResponse = JsonConvert.DeserializeObject<WSErrorResponse>(resultContent);

            Assert.IsNotNull(errorResponse);

            Assert.AreEqual((int)HttpStatusCode.BadRequest, errorResponse.Status);
            Assert.AreEqual(ErrorCodes.bad_request_400, errorResponse.Code);
            Assert.AreEqual("Invalid request body, no child api is found.", errorResponse.Message);
            Assert.AreEqual(traceId, errorResponse.TraceId);
        }


        [Test]
        public void TestBatchRequestMessageHandler_ShouldSThrowExceptionIfRequestBodyMissedHttpMethod()
        {

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/batch");

            var handler = new BatchRequestHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return TestHandler.Return200();
                })
            };

            string batchRequestBody=@"
            [
                {
                ""relativeUrl"": ""/v4/records"",
                }
              ]";
            httpRequestMessage.Content = new StringContent(batchRequestBody);

            var client = new HttpClient(handler);
            var traceId = "UT-" + Guid.NewGuid().ToString();

            var context = new UnKownAgencyAppContext()
            {
                TraceID = traceId,
                App = APP_ID
            };
            InitContext(context);

            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = BatchRequestResourceModel;

            var result = client.SendAsync(httpRequestMessage).Result;

            string resultContent = result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);
            var errorResponse = JsonConvert.DeserializeObject<WSErrorResponse>(resultContent);
            Assert.IsNotNull(errorResponse);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, errorResponse.Status);
            Assert.AreEqual(ErrorCodes.bad_request_400, errorResponse.Code);
            Assert.AreEqual("Invalid request body. method and url are requied for each child request.", errorResponse.Message);
            Assert.AreEqual(traceId, errorResponse.TraceId);
        }


        [Test]
        public void TestBatchRequestMessageHandler_ShouldSThrowExceptionIfRequestBodyMissedUrl()
        {

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/batch");

            var handler = new BatchRequestHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return TestHandler.Return200();
                })
            };

            string batchRequestBody = @"
            [
                {
                ""method"": ""/v4/records"",
                }
              ]";
            httpRequestMessage.Content = new StringContent(batchRequestBody);

            var client = new HttpClient(handler);
            var traceId = "UT-" + Guid.NewGuid().ToString();

            var context = new UnKownAgencyAppContext()
            {
                TraceID = traceId,
                App = APP_ID
            };
            InitContext(context);

            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = BatchRequestResourceModel;

            var result = client.SendAsync(httpRequestMessage).Result;

            string resultContent = result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);
            var errorResponse = JsonConvert.DeserializeObject<WSErrorResponse>(resultContent);
            Assert.IsNotNull(errorResponse);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, errorResponse.Status);
            Assert.AreEqual(ErrorCodes.bad_request_400, errorResponse.Code);
            Assert.AreEqual("Invalid request body. method and url are requied for each child request.", errorResponse.Message);
            Assert.AreEqual(traceId, errorResponse.TraceId);
        }

        [Test]
        public void TestBatchRequestMessageHandler_ShouldSThrowExceptionIfChildRequestAmountSuccessMaxLimit()
        {

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/batch");

            var handler = new BatchRequestHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return TestHandler.Return200();
                })
            };
            // max = 25
            string batchRequestBody = @"
[
{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},

{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},
{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
},{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/BPTDEV-15EST-00000-00014""
}
]
";
            httpRequestMessage.Content = new StringContent(batchRequestBody);

            var client = new HttpClient(handler);
            var traceId = "UT-" + Guid.NewGuid().ToString();

            var context = new UnKownAgencyAppContext()
            {
                TraceID = traceId,
                App = APP_ID
            };
            InitContext(context);

            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = BatchRequestResourceModel;

            var result = client.SendAsync(httpRequestMessage).Result;

            string resultContent = result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);
            var errorResponse = JsonConvert.DeserializeObject<WSErrorResponse>(resultContent);
            Assert.IsNotNull(errorResponse);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, errorResponse.Status);
            Assert.AreEqual(ErrorCodes.bad_request_400, errorResponse.Code);
            Assert.AreEqual("Batch api only supports to maximum 25 apis.", errorResponse.Message);
            Assert.AreEqual(traceId, errorResponse.TraceId);
        }

        [Test]
        public void TestBatchRequestMessageHandler_ShouldSameResponseAmountAsRequest()
        {

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost/v4/batch");

            var handler = new BatchRequestHandler()
            {
                InnerHandler = new TestHandler((r, c) =>
                {
                    return Task.Factory.StartNew(
                () =>
                {
                    string content = @"{""status"":200,""result"":[{""status"":401,""code"":""unauthorized"",""message"":""Invalid token."",""traceId"":""150515033203215-5276e177""},{""status"":401,""code"":""unauthorized"",""message"":""Invalid token."",""traceId"":""150515033203215-5276e177""},{""status"":401,""code"":""unauthorized"",""message"":""Invalid token."",""traceId"":""150515033203215-5276e177""}]}";
                    var responses = new HttpResponseMessage(HttpStatusCode.OK);
                    responses.Content = new StringContent(content);
                    return responses;
                }
                    );
                })
            };

            string batchRequestBody = @"
[
{
""method"": ""GET"",
""relativeUrl"": ""/v4/records""
},
{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/123""
},
{
""method"": ""GET"",
""relativeUrl"": ""/v4/records/111""
}
]
";
            httpRequestMessage.Content = new StringContent(batchRequestBody);

            var client = new HttpClient(handler);
            var traceId = "UT-" + Guid.NewGuid().ToString();

            var context = new UnKownAgencyAppContext()
            {
                TraceID = traceId,
                App = APP_ID
            };
            InitContext(context);

            httpRequestMessage.Properties[PROPERTIES_KEY_RESOURCE_MODEL] = BatchRequestResourceModel;

            var result = client.SendAsync(httpRequestMessage).Result;

            string resultContent = result.Content.ReadAsStringAsync().Result;

            Assert.IsNotNullOrEmpty(resultContent);

            var response = JsonConvert.DeserializeObject<WSBatchResponse>(resultContent);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.result);
            Assert.AreEqual(3, response.result.Count);
  
        }
    }
}
