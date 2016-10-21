using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.AppDataRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AppDataResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Core.Ioc;
using Accela.Apps.Shared;

namespace Accela.Apps.Apis.BusinessEntities
{
    /// <summary>
    /// App data business entity.
    /// </summary>
    public class AppDataBusinessEntity : IAppDataBusinessEntity
    {
        private IAppDataRepository appDataRepository = null;

        public AppDataBusinessEntity()
        {
            appDataRepository = IocContainer.Resolve<IAppDataRepository>();
        }

        public GetAppDataResponse GetAppData(GetAppDataRequest getAppDataRequest)
        {
            return appDataRepository.GetAppData(getAppDataRequest);
        }

        public SaveAppDataResponse SaveAppData(SaveAppDataRequest saveAppDataRequest)
        {
            return appDataRepository.SaveAppData(saveAppDataRequest);
        }

        public DeleteAppDataResponse DeleteAppData(DeleteAppDataRequest deleteAppDataRequest)
        {
            return appDataRepository.DeleteAppData(deleteAppDataRequest);
        }
    }
}
