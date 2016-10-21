using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.GISModels;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests
{
    public class OwnersRequest : PageListRequest
    {
        public OwnersRequest()
        {
        }

        //public string[] OwnerIds;

        public OwnerModel OwnerWithNoId;

        public List<GISObjectModel> GisObjects;
    }
}
