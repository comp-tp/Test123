using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accela.Infrastructure.DocumentDB;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using System.IO;

namespace Accela.Infrastructure.Azure.DocumentDB
{
    /// <typeparam name="T"></typeparam>
    public class AzureDocumentDB<T> : IDocumentContext<T> where T : class
    {
        //private static string CONNECTION_STRING_PATTERN = "AccountEndpoint={0};AccountKey={1};Database={2};";

        private DocumentClient _client = null;
        private Database _db = null;

        public AzureDocumentDB()
        {
        }

        public void Init(string connectionString, IRetryPolicyConfiguration retryPolicyConfiguration)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException("Invalid DocumentDB connection string.");
            }

            try
            {
                DocumentDBAccount account = DocumentDBAccount.Parse(connectionString);
                _client = new DocumentClient(new Uri(account.Server), account.AccessKey);
                if (_client == null)
                {
                    throw new ArgumentException("Invalid DocumentDB account");
                }

                _db = _client.CreateDatabaseQuery().Where(c => c.Id == account.Database).ToArray().FirstOrDefault();
                if (_db == null)
                {
                    throw new ArgumentException("Invalid DocumentDB database");
                }
            }
            catch(AggregateException ex)
            {
                throw new ArgumentException("Invalid DocumentDB connection: " + ex.Message);
            }
            // Retry Policy TODO
        }

        public bool CollectionExists(string collection)
        {
            DocumentCollection docCollection = _client.CreateDocumentCollectionQuery(_db.SelfLink).Where(c => c.Id == collection).ToArray().FirstOrDefault();
            return (docCollection != null);
        }

        public async Task<bool> CreateCollectionAsync(string collection)
        {
            var docCollection = new DocumentCollection()
            {
                Id = collection
            };
            // TODO: RequestOptions like OfferThroughput = 400; the collection is also controllable from Azure portal
            var response = await _client.CreateDocumentCollectionAsync(_db.SelfLink, docCollection);
            var result = response.Resource;
            return (result!=null);
        }

        /// <summary>
        /// Create document entity
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        public async Task<string> CreateAsync(T entity, string collection)
        {
            // Azure DocumentDB returns:
            // AltLink	"dbs/UT/colls/UTCollection/docs/755511e8-a8e8-48c4-aeb1-7a38caa47976"	string
		    // ETag	"\"00005600-0000-0000-0000-570d832d0000\""	string
		    // Id	"755511e8-a8e8-48c4-aeb1-7a38caa47976"	string
		    // ResourceId	"vqwsAPzygwAXAAAAAAAAAA=="	string
		    // SelfLink	"dbs/vqwsAA==/colls/vqwsAPzygwA=/docs/vqwsAPzygwAXAAAAAAAAAA==/"	string
            // id is only unique inside collection so can't be used as global unique ID in the DocumentDB to update/delete a document
            // id is mandatory when updating existing document so must be returned when creating document
            DocumentCollection docCollection = _client.CreateDocumentCollectionQuery(_db.SelfLink).Where(c => c.Id == collection).ToArray().FirstOrDefault();
            if (docCollection == null)
            {
                throw new ArgumentNullException("Invalid DocumentDB collection.");
            }

            var response = await _client.CreateDocumentAsync(docCollection.SelfLink, entity);
            // Ex.
            // AltLink	"dbs/UT/colls/UTCollection/docs/f19f959e-b137-4113-88f1-a252284d70a0"	string
		    // Id	"f19f959e-b137-4113-88f1-a252284d70a0"	string
		    // SelfLink	"dbs/vqwsAA==/colls/vqwsAIfzrQA=/docs/vqwsAIfzrQADAAAAAAAAAA==/"	string

            //dynamic result = response.Resource;
            //result.DocKey = response.Resource.SelfLink;

            var result = response.Resource.Id;
            return result;
        }

        public async Task<string> CreateAsync(Stream content, string collection)
        {
            // Azure DocumentDB returns:
            // AltLink	"dbs/UT/colls/UTCollection/docs/755511e8-a8e8-48c4-aeb1-7a38caa47976"	string
            // ETag	"\"00005600-0000-0000-0000-570d832d0000\""	string
            // Id	"755511e8-a8e8-48c4-aeb1-7a38caa47976"	string
            // ResourceId	"vqwsAPzygwAXAAAAAAAAAA=="	string
            // SelfLink	"dbs/vqwsAA==/colls/vqwsAPzygwA=/docs/vqwsAPzygwAXAAAAAAAAAA==/"	string
            // id is only unique inside collection so can't be used as global unique ID in the DocumentDB to update/delete a document
            // id is mandatory when updating existing document so must be returned when creating document
            DocumentCollection docCollection = _client.CreateDocumentCollectionQuery(_db.SelfLink).Where(c => c.Id == collection).ToArray().FirstOrDefault();
            if (docCollection == null)
            {
                throw new ArgumentNullException("Invalid DocumentDB collection.");
            }

            var response = await _client.CreateDocumentAsync(docCollection.SelfLink, Document.LoadFrom<Document>(content));
            // Ex.
            // AltLink	"dbs/UT/colls/UTCollection/docs/f19f959e-b137-4113-88f1-a252284d70a0"	string
            // Id	"f19f959e-b137-4113-88f1-a252284d70a0"	string
            // SelfLink	"dbs/vqwsAA==/colls/vqwsAIfzrQA=/docs/vqwsAIfzrQADAAAAAAAAAA==/"	string

            //dynamic result = response.Resource;
            //result.DocKey = response.Resource.SelfLink;

            var result = response.Resource.Id;
            return result;
        }

        public async Task<string[]> CreateAsync(T[] entities, string collection)
        {
            DocumentCollection docCollection = _client.CreateDocumentCollectionQuery(_db.SelfLink).Where(c => c.Id == collection).ToArray().FirstOrDefault();
            if (docCollection == null)
            {
                throw new ArgumentNullException();
            }

            var tasks = new Task<ResourceResponse<Document>>[entities.Length];
            //var result = new T[entities.Length]; 
            var result = new string[entities.Length];   // document key

            for (var i = 0; i < entities.Length; i++ )
            {
                tasks[i] = _client.CreateDocumentAsync(docCollection.SelfLink, entities[i]);
            }

            await Task.WhenAll(tasks);
            for (var i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].Result!=null)
                {
                    //result[i] = (dynamic)tasks[i].Result.Resource;
                    //result[i].DocKey = tasks[i].Result.Resource.SelfLink;
                    result[i] = tasks[i].Result.Resource.Id;
                }
            }

            return result;
        }

        public async Task<T> UpdateAsync(string docId, string collection, T entity)
        {
            var docKey = string.Format("dbs/{0}/colls/{1}/docs/{2}", _db.Id, collection, docId);
            var response = await _client.ReplaceDocumentAsync(docKey, entity);
            return (dynamic)response.Resource;
        }

        public async Task<bool> DeleteAsync(string docId, string collection)
        {
            if (string.IsNullOrEmpty(docId))
            {
                throw new ArgumentNullException();
            }
            try
            {
                var docKey = string.Format("dbs/{0}/colls/{1}/docs/{2}", _db.Id, collection, docId);
                var response = await _client.DeleteDocumentAsync(docKey);
                return (response.Resource == null);
            }
            catch (Exception)   // TODO: Microsoft.Azure.Documents.NotFoundException
            {
                //throw new ArgumentNullException();
                return false;
            }
        }

        public async Task<bool> DeleteAsync(DocumentSearchOptions filter)
        {
            throw new NotImplementedException();
        }

        public async Task<T> ReadAsync(string docId, string collection)
        {
            if (docId == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                var docKey = string.Format("dbs/{0}/colls/{1}/docs/{2}", _db.Id, collection, docId);
                var response = await _client.ReadDocumentAsync(docKey);
                return (dynamic)response.Resource;
            }
            catch (DocumentClientException)
            {
                // not found
                return null;
            }
        }

        public async Task<PagedResults<T>> SearchAsync(DocumentSearchOptions searchOptions)
        {
            if (searchOptions == null)
            {
                throw new ArgumentNullException();
            }
            DocumentCollection collection = _client.CreateDocumentCollectionQuery(_db.SelfLink).Where(c => c.Id == searchOptions.Collection).ToArray().FirstOrDefault();
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            FeedOptions options = new FeedOptions { MaxItemCount = searchOptions.MaxResults };
            if (!String.IsNullOrWhiteSpace(searchOptions.ContinuationToken))
            {
                options.RequestContinuation = searchOptions.ContinuationToken;
            }

            var query = _client.CreateDocumentQuery<T>(collection.SelfLink, searchOptions.Filter, options).AsDocumentQuery();
            var feedResponse = await query.ExecuteNextAsync<T>();

            PagedResults<T> result = new PagedResults<T>();
            result.ContinuationToken = feedResponse.ResponseContinuation;
            result.Results = feedResponse.AsEnumerable();

            return result;
        }


        protected class DocumentDBAccount
        {
            public string Server = null;
            public string AccessKey = null;
            public string Database = null;

            public static DocumentDBAccount Parse(string connectionString)
            {
                DocumentDBAccount account = new DocumentDBAccount();
                Dictionary<string, string> paramMap = new Dictionary<string, string>();
                foreach (var param in connectionString.Split(';'))
                {
                    var keyValue = param.Split('=');
                    if (keyValue != null && keyValue.Length == 2)
                    {
                        paramMap.Add(keyValue[0], keyValue[1]);
                    }
                    else if (keyValue != null && keyValue.Length > 2)
                    {
                        string value = String.Join("=", keyValue);
                        paramMap.Add(keyValue[0], value.Substring(keyValue[0].Length+1));
                    }
                }
                
                if (paramMap.ContainsKey("AccountEndpoint"))
                {
                    account.Server = paramMap["AccountEndpoint"];
                }
                else
                {
                    throw new ArgumentException("AccountEndpoint is missing in DocumentDB connection string.");
                }

                if (paramMap.ContainsKey("AccountKey"))
                {
                    account.AccessKey = paramMap["AccountKey"];
                }
                else
                {
                    throw new ArgumentException("AccountKey is missing in DocumentDB connection string.");
                }

                if (paramMap.ContainsKey("Database"))
                {
                    account.Database = paramMap["Database"];
                }
                else
                {
                    throw new ArgumentException("Database is missing in DocumentDB connection string.");
                }
                return account;
            }
        }
    }
}
