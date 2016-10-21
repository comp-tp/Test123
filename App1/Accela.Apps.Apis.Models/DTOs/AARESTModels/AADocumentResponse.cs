using System.Collections.Generic;

namespace Accela.Apps.Apis.Repositories.Agency.AARESTModels
{
    public class AADocumentResponse : V4BizResponseBase
    {
        public List<AADocument> result { get; set; }
    }
}
