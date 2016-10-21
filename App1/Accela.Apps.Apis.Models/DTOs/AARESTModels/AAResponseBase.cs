using Accela.Apps.Apis.Models.DTOs;

namespace Accela.Apps.Apis.Repositories.Agency.AARESTModels
{
    public class AAResponseBase : ResponseBase
    {
        public int status { get; set; }
        public string message { get; set; }
        public int code { get; set; }
    }

    public class V4BizResponseBase
    {
        public int status { get; set; }

        public string message { get; set; }

        public string more { get; set; }

        public string code { get; set; }

        public string traceId { get; set; }
    }
}
