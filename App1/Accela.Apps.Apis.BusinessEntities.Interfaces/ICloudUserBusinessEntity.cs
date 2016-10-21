using System;
using System.IO;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs.Requests.CitizenRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.CitizenResponses;
using Accela.Apps.Shared.AzureHelpers;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface ICloudUserBusinessEntity
    {
        CloudUserModel GetCloudUserByLoginName(string loginName);  

        CreateCivicIdResponse CreateCivicId(CreateCivicIdRequest request);
    }
}
