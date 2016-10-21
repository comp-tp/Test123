using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Tables
{
    public interface ITableEntity 
    {
        string RowKey { get; set; }
        string PartitionKey { get; set; }
        DateTimeOffset Timestamp { get; set; }
    }
}
