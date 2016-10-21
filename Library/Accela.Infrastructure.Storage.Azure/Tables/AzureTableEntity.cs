using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Azure.Tables
{
    public interface IAzureTableEntity: ITableEntity, Accela.Infrastructure.Tables.ITableEntity
    {

    }

    public class AzureTableEntity : TableEntity, IAzureTableEntity
    {
        public new string PartitionKey
        {
            get;
            set;
        }

        public new string RowKey
        {
            get;
            set;
        }

        public new DateTimeOffset Timestamp
        {
            get;
            set;
        }
    }
}
