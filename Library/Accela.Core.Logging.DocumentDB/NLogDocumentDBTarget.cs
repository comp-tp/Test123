using Accela.Core.Logging;
using Accela.Infrastructure.Azure.Configurations;
using Accela.Infrastructure.Azure.DocumentDB;
using Accela.Infrastructure.DocumentDB;
using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Core.Logging.DocumentDB
{
    [Target("DocumentDB")] 
    public class NLogDocumentDBTarget : TargetWithLayout
    {
        private IDocumentContext<string> _documentDB = null;
        private HashSet<string> _collectionSet = new HashSet<string>();

        public NLogDocumentDBTarget()
        {
        }

        /// <summary>
        /// Key of the connection string
        /// Ex. Log_DocumentDBConnectionString
        /// Either ConnectionKey or ConnectionString is required.
        /// </summary>
        //[RequiredParameter]
        public string ConnectionKey { get; set; }

        /// <summary>
        /// Value of connection string.
        /// Ex. AccountEndpoint=https://xxx.documents.azure.com:443/;AccountKey=yyy;Database=zzz";
        /// Either ConnectionKey or ConnectionString is required.
        /// </summary>
        //[RequiredParameter]
        public string ConnectionString { get; set; }

        private Layout _collection = null;
        private string cachedCollectionName = null;

        /// <summary>
        /// Supports collection name pattern like log_${shortdate}
        /// </summary>
        [RequiredParameter]
        public Layout Collection
        {
            get
            {
                return _collection;
            }
            set
            {
                var simpleLayout = value as SimpleLayout;
                if (simpleLayout != null && !simpleLayout.Text.Contains('$'))
                {
                    cachedCollectionName = CleanupInvalidCollectionName(simpleLayout.Text);
                }
                else
                {
                    //clear cache
                    cachedCollectionName = null;
                }
                _collection = value;
            }
        }

        protected override void Write(LogEventInfo logEvent)
        {
            if (_documentDB == null)
            {
                // TODO: with Ioc, we could make the log independent on Azure
                if (string.IsNullOrEmpty(ConnectionString))
                {
                    ConnectionString = new AzureConfigurationReader().Get(ConnectionKey);
                }
                try {
                    _documentDB = new AzureDocumentDB<string>();
                    _documentDB.Init(ConnectionString, null);
                }catch(Exception ex)
                {
                    _documentDB = null;
                    System.Diagnostics.Debug.Fail("Failed to init DocumentDB " + ConnectionString, ex.ToString());
                    return;
                }
            }

            string collection = GetCollectionName(logEvent);
            // Ex. layout="${longdate} ${uppercase:${level}} ${message}"
            // TODO: for perforamnce, should not repeatedly check remotely with DocumentDB server
            if (!_collectionSet.Contains(collection))
            {
                if (!_documentDB.CollectionExists(collection))
                {
                    _documentDB.CreateCollectionAsync(collection);
                }
                _collectionSet.Add(collection);
            }

            string logMessage = this.Layout.Render(logEvent);
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(logMessage)))
            {
                // directly save stream
                _documentDB.CreateAsync(ms, collection);
            }
        }

        private string GetCollectionName(LogEventInfo logEvent)
        {
            return cachedCollectionName ?? CleanupInvalidCollectionName(this.Collection.Render(logEvent));
        }

        private string CleanupInvalidCollectionName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name.Trim().Replace('\\','-').Replace('/','-').Replace('#', '-').Replace('?', '-');
            }
            else
            {
                return name;
            }
        }
    }

}
