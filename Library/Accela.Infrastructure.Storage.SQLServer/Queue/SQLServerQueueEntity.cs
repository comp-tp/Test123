using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.SQLServer.Queue
{
    [Serializable]
    [DataContract(Name = "sqlServerQueueEntity")]
    public class SQLServerQueueEntity
    {
        [DataMember(Name = "id")]
        public long Id
        {
            get;
            set;
        }

        [DataMember(Name = "insertionTime")]
        public DateTimeOffset InsertionTime
        {
            get;
            set;
        }

        [DataMember(Name = "expirationTime")]
        public DateTimeOffset ExpirationTime
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
