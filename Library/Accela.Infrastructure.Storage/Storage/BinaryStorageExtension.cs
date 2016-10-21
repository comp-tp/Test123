using Accela.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Infrastructure.Storage
{
    public static class BinaryStorageExtension
    {
        public static bool Exists(this IBinaryStorage storage, string containerName, string blobName)
        {
            var t = Task.Run(async () =>
            {
                return await storage.ExistsAsync(containerName, blobName);
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
                throw new AccelaBaseException("Failed to access to BinaryStorage.", "Task is not RanToCompletion while calling ExistsAsync()." + taskException);
            }
        }

        public static BlobProperties ReadAttributes(this IBinaryStorage storage, string containerName, string blobName)
        {
            var t = Task.Run(async () =>
            {
                return await storage.ReadAttributesAsync(containerName, blobName);
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
                throw new AccelaBaseException("Failed to access to BinaryStorage.", "Task is not RanToCompletion while calling ReadAttributesAsync()." + taskException);
            }
        }

        public static Stream ReadAsStream(this IBinaryStorage storage, string containerName, string blobName)
        {
            var t = Task.Run(async () =>
            {
                return await storage.ReadAsStreamAsync(containerName, blobName);
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
                throw new AccelaBaseException("Failed to access to BinaryStorage.", "Task is not RanToCompletion while calling ReadAsStreamAsync()." + taskException);
            }
        }

        public static string ReadAsString(this IBinaryStorage storage, string containerName, string blobName)
        {
            var t = Task.Run(async () =>
            {
                return await storage.ReadAsStringAsync(containerName, blobName);
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
                throw new AccelaBaseException("Failed to access to BinaryStorage.", "Task is not RanToCompletion while calling ReadAsStringAsync()." + taskException);
            }
        }

        public static void CreateNew(this IBinaryStorage storage, string containerName, string blobName, Stream content)
        {
            var t = Task.Run(async () =>
            {
                await storage.CreateNewAsync(containerName, blobName, content);
            });

            try
            {
                t.Wait();
            }
            catch(AggregateException ae)
            {
                if(ae.InnerException != null)
                {
                    throw ae.InnerException;
                }
            }
            catch(Exception ex)
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

                throw new AccelaBaseException("Failed to access to BinaryStorage.", "Task is not RanToCompletion while calling CreateNewAsync()." + taskException);
            }
        }

        public static void CreateNew(this IBinaryStorage storage, string containerName, string blobName, string content)
        {
            var t = Task.Run(async () =>
            {
                await storage.CreateNewAsync(containerName, blobName, content);
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

                throw new AccelaBaseException("Failed to access to BinaryStorage.", "Task is not RanToCompletion while calling CreateNewAsync() for string content." + taskException);
            }
        }

        public static void CreateNewOrUpdate(this IBinaryStorage storage, string containerName, string blobName, Stream content)
        {
            var t = Task.Run(async () =>
            {
                await storage.CreateNewOrUpdateAsync(containerName, blobName, content);
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

                throw new AccelaBaseException("Failed to access to BinaryStorage.", "Task is not RanToCompletion while calling CreateNewOrUpdateAsync()." + taskException);
            }
        }

        public static void CreateNewOrUpdate(this IBinaryStorage storage, string containerName, string blobName, string content)
        {
            var t = Task.Run(async () =>
            {
                await storage.CreateNewOrUpdateAsync(containerName, blobName, content);
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

                throw new AccelaBaseException("Failed to access to BinaryStorage.", "Task is not RanToCompletion while calling CreateNewOrUpdateAsync() for string content." + taskException);
            }
        }

        public static bool DeleteIfExists(this IBinaryStorage storage, string containerName, string blobName)
        {
            var t = Task.Run(async () =>
            {
                return await storage.DeleteIfExistsAsync(containerName, blobName);
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

                throw new AccelaBaseException("Failed to access to BinaryStorage.", "Task is not RanToCompletion while calling DeleteIfExistsAsync()." + taskException);
            }
        }

        /// <summary>
        /// deletes the container if it already exists.
        /// </summary>
        /// <param name="containerName">container name.</param>
        /// <returns>true if the container did not already exist and was created; otherwise false.</returns>
        public static bool DeleteContainerIfExists(this IBinaryStorage storage, string containerName)
        {
            var t = Task.Run(async () =>
            {
                return await storage.DeleteContainerIfExistsAsync(containerName);
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

                throw new AccelaBaseException("Failed to access to BinaryStorage.", "Task is not RanToCompletion while calling DeleteContainerIfExistsAsync()." + taskException);
            }
        }


        public static BlobSearchResult Search(this IBinaryStorage storage, string containerName, BlobSearchOptions filter)
        {
            var t = Task.Run(async () =>
            {
                return await storage.SearchAsync(containerName, filter);
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

                throw new AccelaBaseException("Failed to access to BinaryStorage.", "Task is not RanToCompletion while calling SearchAsync()." + taskException);
            }
        }
    }
}
