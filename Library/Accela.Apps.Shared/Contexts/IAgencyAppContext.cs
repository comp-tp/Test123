using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.Contexts
{
    public interface IAgencyAppContext : IGatewayContext
    {
        string App { get; set; }
        string AppName { get; set; }
        string AppSecret { get; set; }
        AppType AppType { get; set; }
        string AppVer { get; set; }
        string ClientIP { get; set; }
        int ContentLength { get; set; }
        string ContentType { get; set; }

        string HttpHeader { get; set; }
        string HttpMethod { get; set; }
        int Index { get; set; }
        bool IsAuthed { get; set; }
        IDictionary<string, object> Items { get; set; }
        string Language { get; set; }
        string LoginName { get; set; }
        string CivicId { get; set; }
        string RequestUri { get; set; }
        string RequestUriTemplate { get; set; }
        string ServProvCode { get; set; }
        string SocialToken { get; set; }
        string SubSystemCaller { get; set; }
        string Token { get; set; }

        IAgencyAppContext Clone();

        IContextUser ContextUser { get; set; }

    }

    public interface IGatewayContext
    {
        string Agency { get; set; }
        string EnvName { get; set; }
        string TraceID { get; set; }
    }

}
