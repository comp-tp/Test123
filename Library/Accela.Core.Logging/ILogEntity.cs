using System;
namespace Accela.Core.Logging
{
    public interface ILogEntity
    {
        string TraceId { get; set; }
        string AppId { get; set; }
        string EnvName { get; set; }
        string Agency { get; set; }
        string UserName { get; set; }
        string Message { get; set; }
        string Detail { get; set; }
        string Host { get; set; }
        int MethodExecuteTime { get; set; }
        int MethodInSize { get; set; }
        string MethodName { get; set; }
        int MethodOutSize { get; set; }
        int Order { get; set; }
        string ClientIP { get; set; }
        string RequestFrom { get; set; }
        string RequestTo { get; set; }

        string DetailBlobUri
        {
            get;
            set;
        }

    }
}
