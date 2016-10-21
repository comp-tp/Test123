using Accela.Infrastructure;
using Accela.Infrastructure.Azure.DocumentDB;
using Accela.Infrastructure.DocumentDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Analytics.Azure
{
    public class AzureDocumentDBTracer : ITrace
    {
        private AzureDocumentDB<StatsDataDocument> db = null;

        public AzureDocumentDBTracer(string docdbConnectionString)
        {
            db = new AzureDocumentDB<StatsDataDocument>();
            db.Init(docdbConnectionString, 
                new CustomRetryPolicyConfiguration() { RetryMethod = RetryMethod.Exponential, DeltaBackoff = TimeSpan.FromMilliseconds(200), MaxAttempts = 3 });
        }

        public async void Trace(StatsData data)
        {
            try
            {
                // collection is based on date of requestTime
                StatsDataDocument doc = new StatsDataDocument(data);
                string collection = String.Format("stats-{0}", data.RequestTime.ToString("yyyyMMdd")).ToLower();
                var result = await db.CreateAsync(doc, collection);
                
            }
            catch (Exception ex)
            {
                // TODO: error handling
            }
        }

        class DocumentDBConnectionStringSetting : IConnectionStringSetting
        {
            private string _connectionString = null;
            public DocumentDBConnectionStringSetting(string connectionString) {
                _connectionString = connectionString;
            }
            public string Get()
            {
                return _connectionString;
            }


            public string Get(string key)
            {
                throw new NotImplementedException();
            }
        }

        public class StatsDataDocument : StatsData, IDocumentEntity {

            public StatsDataDocument(StatsData data)
            {
                //this = (StatsDataDocument)data.Clone();
                //DocKey = data.Id.ToString();   // TODO
                Agency = data.Agency;
                App = data.App;
                User = data.User;
                Environment = data.Environment;
                Resource = data.Resource;
                RequestTime = data.RequestTime;
                RequestUri = data.RequestUri;
                // TODO
            }

            public string DocKey { get; set; }
        }
    }
}
