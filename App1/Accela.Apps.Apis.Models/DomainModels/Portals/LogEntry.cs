using System;
using Accela.Apps.Shared.AzureHelpers;
using Microsoft.WindowsAzure.StorageClient;

// TODO:
// This class does not belong to this project.
// It comes from the Log subsystem.
// Remove it late.

namespace Accela.Apps.Apis.Models.DomainModels.Portals
{


    public class LogEntry : TableServiceEntity, ITableEntity
    {
        /// <summary>
        /// Gets or sets PartitionKey.
        /// </summary>
        public override string PartitionKey
        {
            get
            {
                return "LogEntry";
            }
            set
            {

            }
        }

        /// <summary>
        /// Gets or sets RowKey.
        /// </summary>
        public override string RowKey
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets entry id.
        /// </summary>
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets trace id.
        /// </summary>
        public string TraceId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets log level.
        /// </summary>
        public string LogLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets message.
        /// </summary>
        public string Message
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets detail.
        /// </summary>
        public string Detail
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets method name.
        /// </summary>
        public string MethodName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets method duration time.
        /// </summary>
        public int MethodDuration
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        public string UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets app name.
        /// </summary>
        public string AppName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets agency name.
        /// </summary>
        public string AgencyName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Blob Uri if the detail is stored to blob.
        /// </summary>
        public string BlobUri
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets blob size.
        /// </summary>
        public long BlobSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the entity create date.
        /// </summary>
        public DateTime DateCreated
        {
            get;
            set;
        }

        public int MethodInSize
        {
            get;
            set;
        }

        public int MethodOutSize
        {
            get;
            set;
        }
    }
}
