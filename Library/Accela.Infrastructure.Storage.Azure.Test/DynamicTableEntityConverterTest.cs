using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Moq;
using Accela.Infrastructure.Azure.Tables;

namespace Accela.Infrastructure.Azure.Test
{
    [TestFixture]
    public class DynamicTableEntityConverterTest
    {
        private const string TABLE_NAME = "UTTableName";
        private const string PATITION_KEY = "UTPartitionKey";
        [Test]
        public void CreateInstance_ShouldReturnAzureITableEntity()
        {
            CustomTableEntity entity = new CustomTableEntity{
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = PATITION_KEY,
                Another = "another property"
            };

            Microsoft.WindowsAzure.Storage.Table.ITableEntity result = DynamicTableEntityConverter<CustomTableEntity>.ToAzureTableEntity(entity);

            Assert.IsNotNull(result);
            Assert.AreEqual(entity.RowKey, result.RowKey);
            Assert.AreEqual(entity.PartitionKey, result.PartitionKey);
        }

        [Test]
        public void CreateInstance_ShouldReturbCustomITableEntity()
        {
            AzureTableEntity2 entity = new AzureTableEntity2
            {
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = PATITION_KEY,
                ExpandName = "expand name",
                Another = "another property"
            };

            CustomTableEntity result = DynamicTableEntityConverter<CustomTableEntity>.ToITableEntity(entity);

            Assert.IsNotNull(result);
            Assert.AreEqual(entity.RowKey, result.RowKey);
            Assert.AreEqual(entity.PartitionKey, result.PartitionKey);
            Assert.AreEqual(entity.ExpandName, result.ExpandName);
            Assert.AreEqual(entity.Another, result.Another);

        }

        public class CustomTableEntity : Accela.Infrastructure.Tables.ITableEntity
        {

            public string RowKey
            {
                get;
                set;
            }

            public string PartitionKey
            {
                get;
                set;
            }

            public DateTimeOffset Timestamp
            {
                get;
                set;
            }

            public string Another
            {
                get;
                set;
            }

            public string ExpandName
            {
                get;
                set;
            }
        }


        public class AzureTableEntity2 : AzureTableEntity
        {
            public string Another
            {
                get;
                set;
            }
            public string ExpandName
            {
                get;
                set;
            }
        }
    }
}
