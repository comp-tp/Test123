using Accela.Infrastructure.Queue;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.SQLServer.Queue
{
    public class SQLServerQueueStorageRepository : ISQLServerQueueStorageRepository
    {
        private string _connectionString;

        public SQLServerQueueStorageRepository(string connectionString)
        {
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException("connectionString");
            }

            _connectionString = connectionString;
        }

        /// <summary>
        /// Initiates an asynchronous operation to create the queue if it does not already exist.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>  A System.Threading.Tasks.Task<TResult> object of type bool that represents the asynchronous operation.</returns>
        public async Task<bool> CreateIfNotExistsAsync(string queueName)
        {
            if (String.IsNullOrWhiteSpace(queueName))
            {
                throw new ArgumentNullException("queueName");
            }

            bool result = false;

            var outputParameter = new SqlParameter { ParameterName = "@existsQueue", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output};

            using (var dbContext = GetDbContext())
            {
   
                await dbContext.Database.ExecuteSqlCommandAsync(
                        @"[dbo].[createQueueIfNotExist] @queueName, @existsQueue output",
                         new SqlParameter("@queueName", queueName),
                         outputParameter
                        );
            }

            result = Convert.ToInt32(outputParameter.Value) == 1 ? true : false;

            return result;
        }

        /// <summary>
        /// Initiates an asynchronous operation to delete the queue if it already exists.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type bool that represents the asynchronous operation.</returns>
        public async Task<bool> DeleteIfExistsAsync(string queueName)
        {
            if (String.IsNullOrWhiteSpace(queueName))
            {
                throw new ArgumentNullException("queueName");
            }

            bool result = false;

            var outputParameter = new SqlParameter { ParameterName = "@existsQueue", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

            using (var dbContext = GetDbContext())
            {

                await dbContext.Database.ExecuteSqlCommandAsync(
                        @"[dbo].[deleteQueueIfExist] @queueName, @existsQueue output",
                         new SqlParameter("@queueName", queueName),
                         outputParameter
                        );
            }

            result = Convert.ToInt32(outputParameter.Value) == 1 ? true : false;

            return result;
        }

        /// <summary>
        /// Initiates an asynchronous operation to check the existence of the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type bool that represents the asynchronous operation.</returns>
        public async Task<bool> ExistsAsync(string queueName)
        {
            if (String.IsNullOrWhiteSpace(queueName))
            {
                throw new ArgumentNullException("queueName");
            }

            bool result = false;

            var outputParameter = new SqlParameter { ParameterName = "@result", SqlDbType = SqlDbType.Bit, Direction = ParameterDirection.Output };

            using (var dbContext = GetDbContext())
            {

                await dbContext.Database.ExecuteSqlCommandAsync(
                        @"[dbo].[existsQueue] @queueName, @result output",
                         new SqlParameter("@queueName", queueName),
                         outputParameter
                        );
            }

            result = Convert.ToInt32(outputParameter.Value) == 1 ? true : false;

            return result;
        }

        /// <summary>
        /// Initiates an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="queueEntity">A SQLServerQueueEntity object.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        public async Task InsertQueueEntityAsync(string queueName, SQLServerQueueEntity queueEntity)
        {
            if (String.IsNullOrWhiteSpace(queueName))
            {
                throw new ArgumentNullException("queueName");
            }

            if(queueEntity == null)
            {
                throw new ArgumentNullException("queueEntity");
            }

            using (var dbContext = GetDbContext())
            {
                await dbContext.Database.ExecuteSqlCommandAsync(
                        @"[dbo].[createQueueMessage] @queueName, @insertionTime, @expirationTime, @content",
                         new SqlParameter("@queueName", queueName),
                         new SqlParameter("@insertionTime", queueEntity.InsertionTime),
                         new SqlParameter("@expirationTime", queueEntity.ExpirationTime),
                         new SqlParameter("@content", queueEntity.Content)
                        );
            }
        }

        /// <summary>
        /// Initiates an asynchronous operation to add messages to the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="queueEntities">A SQLServerQueueEntity list.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        public async Task InsertQueueEntitiesAsync(string queueName, IEnumerable<SQLServerQueueEntity> queueEntities)
        {
            if (String.IsNullOrWhiteSpace(queueName))
            {
                throw new ArgumentNullException("queueName");
            }

            if (queueEntities == null)
            {
                throw new ArgumentNullException("queueEntities");
            }

            if(!queueEntities.Any())
            {
                return;
            }

            using (var dbContext = GetDbContext())
            {
                foreach (var queueEntity in queueEntities)
                {
                    await dbContext.Database.ExecuteSqlCommandAsync(
                            @"[dbo].[createQueueMessage] @queueName, @insertionTime, @expirationTime, @content",
                             new SqlParameter("@queueName", queueName),
                             new SqlParameter("@insertionTime", queueEntity.InsertionTime),
                             new SqlParameter("@expirationTime", queueEntity.ExpirationTime),
                             new SqlParameter("@content", queueEntity.Content)
                            );
                }
            }
        }

        /// <summary>
        /// Initiates an asynchronous operation to get a single message and removing it from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="deleteQueueEntity">true - will delete queue entity, false - will not delete queue entity.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object of type Accela.Infrastructure.Queue.QueueMessage that represents the asynchronous operation.</returns>
        public async Task<SQLServerQueueEntity> GetQueueEntityAsync(string queueName, bool deleteQueueEntity)
        {
            if (String.IsNullOrWhiteSpace(queueName))
            {
                throw new ArgumentNullException("queueName");
            }

            SQLServerQueueEntity result = null;


            using (var dbContext = GetDbContext())
            {
                var tempResult = dbContext.Database.SqlQuery<SQLServerQueueEntity>(
                        @"[dbo].[getQueueMessages] @queueName, @messageCount, @withDeleteQueueMessage"
                        , new SqlParameter("@queueName", queueName)
                        , new SqlParameter("@messageCount", 1)
                        , new SqlParameter("@withDeleteQueueMessage", deleteQueueEntity ? 1 : 0)
                      );

                result = await tempResult.FirstOrDefaultAsync();
            }

            return result;
        }

        /// <summary>
        /// Initiates an asynchronous operation to get the specified number of messages and removing them from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="deleteQueueEntity">true - will delete queue entity, false - will not delete queue entity.</param>
        /// <returns>A System.Threading.Tasks.Task<TResult> object that is an enumerable collection
        ///  of type Accela.Infrastructure.Queue.QueueMessage that represents the asynchronous operation.
        /// </returns>
        public async Task<IEnumerable<SQLServerQueueEntity>> GetQueueEntitiesAsync(string queueName, int messageCount, bool deleteQueueEntity)
        {
            if (String.IsNullOrWhiteSpace(queueName))
            {
                throw new ArgumentNullException("queueName");
            }

            List<SQLServerQueueEntity> result = null;

            using (var dbContext = GetDbContext())
            {
                var tempResult = dbContext.Database.SqlQuery<SQLServerQueueEntity>(
                        @"[dbo].[getQueueMessages] @queueName, @messageCount, @withDeleteQueueMessage"
                        , new SqlParameter("@queueName", queueName)
                        , new SqlParameter("@messageCount", messageCount)
                        , new SqlParameter("@withDeleteQueueMessage", deleteQueueEntity ? 1 : 0)
                      );

                result = await tempResult.ToListAsync();
            }

            return result;
        }

        /// <summary>
        /// Initiates an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="queueName">The name of the queue.</param>
        /// <returns>A System.Threading.Tasks.Task object that represents the asynchronous operation.</returns>
        public async Task ClearAsync(string queueName)
        {
            if (String.IsNullOrWhiteSpace(queueName))
            {
                throw new ArgumentNullException("queueName");
            }

            using (var dbContext = GetDbContext())
            {

                await dbContext.Database.ExecuteSqlCommandAsync(
                        @"[dbo].[clearQueueMessages] @queueName",
                         new SqlParameter("@queueName", queueName)
                        );
            }
        }


        private QueueDBContext GetDbContext()
        {
            return new QueueDBContext(_connectionString);
        }
    }
}
