using Accela.Infrastructure.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.SQLServer.Tables
{
    [Serializable]
    [DataContract(Name = "sqlServerTableStorageEntity")]
    public class SQLServerTableStorageEntity : ITableEntity
    {
        [DataMember(Name = "id")]
        public long ID
        {
            get;
            set;
        }

        [DataMember(Name = "partitionKey")]
        public string PartitionKey
        {
            get;
            set;
        }

        [DataMember(Name = "rowKey")]
        public string RowKey
        {
            get;
            set;
        }

        [DataMember(Name = "timestamp")]
        public DateTimeOffset Timestamp
        {
            get;
            set;
        }

        [DataMember(Name = "content")]
        public string Content
        {
            get;
            set;
        }
    }
}
