using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IAppSettingsBusinessEntity : IBusinessEntity
    {
        AppSettingResponse GetAppSetting(AppSettingRequest request);

        AppSettingsResponse GetAppSettings(AppSettingsRequest request);        
    }
}
