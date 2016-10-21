using Accela.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Tables
{
    public static class TableStorageExtension
    {
        public static void CreateNewOrReplace<T>(this ITableStorage<T> storage, T entity, string tableName) where T : class, ITableEntity,new()
        {
            var t = Task.Run(async () =>
            {
                await storage.CreateNewOrReplaceAsync(entity, tableName);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (t.Status == TaskStatus.RanToCompletion)
            {
                return;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;

                throw new AccelaBaseException("Failed to access to TableStorage.", "Task is not RanToCompletion while calling CreateNewOrReplaceAsync(entity, tableName)." + taskException);
            }
        }

        public static void CreateNewOrReplace<T>(this ITableStorage<T> storage, T[] entities, string tableName) where T : class, ITableEntity, new()
        {
            var t = Task.Run(async () =>
            {
                await storage.CreateNewOrReplaceAsync(entities, tableName);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (t.Status == TaskStatus.RanToCompletion)
            {
                return;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;

                throw new AccelaBaseException("Failed to access to TableStorage.", "Task is not RanToCompletion while calling CreateNewOrReplaceAsync(entites, tableName)." + taskException);
            }
        }

        public static void DeleteIfExists<T>(this ITableStorage<T> storage, T entity, string tableName) where T : class, ITableEntity, new()
        {
            var t = Task.Run(async () =>
            {
                await storage.DeleteIfExistsAsync(entity, tableName);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (t.Status == TaskStatus.RanToCompletion)
            {
                return;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;

                throw new AccelaBaseException("Failed to access to TableStorage.", "Task is not RanToCompletion while calling DeleteIfExistsAsync()." + taskException);
            }
        }

        public static T Read<T>(this ITableStorage<T> storage, string tableName, string partitionKey, string rowKey) where T : class, ITableEntity, new()
        {
            var t = Task.Run(async () =>
            {
                return await storage.ReadAsync(tableName, partitionKey, rowKey);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (t.Status == TaskStatus.RanToCompletion)
            {
                return t.Result;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;

                throw new AccelaBaseException("Failed to access to TableStorage.", "Task is not RanToCompletion while calling ReadAsync()." + taskException);
            }

        }

        public static PagedResults<T> Search<T>(this ITableStorage<T> storage, TableSearchOptions searchOptions) where T : class, ITableEntity,new()
        {
            var t = Task.Run(async () =>
            {
                return await storage.SearchAsync(searchOptions);
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                if (ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (t.Status == TaskStatus.RanToCompletion)
            {
                return t.Result;
            }
            else
            {
                string taskException = t.Exception != null ? t.Exception.ToString() : null;

                throw new AccelaBaseException("Failed to access to TableStorage.", "Task is not RanToCompletion while calling SearchAsync()." + taskException);
            }
        }
    }
}
