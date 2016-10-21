using System;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.Models.DTOs.Requests.EnvironmentRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.EnvironmentResponses;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Shared;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class EnvironmentBusinessEntity : BusinessEntityBase, IEnvironmentBusinessEntity
    {
        private IEnvironmentRepository _environmentRepository;
        private IAgencyAdministratorsRepository _agencyAdministratorsRepository;

        public EnvironmentBusinessEntity()
        {
            _environmentRepository = IocContainer.Resolve<IEnvironmentRepository>();
            _agencyAdministratorsRepository = IocContainer.Resolve<IAgencyAdministratorsRepository>();
        }

        public HostEnvModel GetAgencyDefaultEnvironment(string agencyName)
        {
            var result = _environmentRepository.GetAgencyEnvironment(agencyName, "");

            return result;
        }

        public GetEnvironmentResponse GetEnvironment(GetEnvironmentRequest getEnvironmentRequest)
        {
            var agencyId = _agencyAdministratorsRepository.GetAgencyIdByAdministratorId(getEnvironmentRequest.AdmininstratorID);
            return _environmentRepository.GetEnvironment(agencyId);        
        }

        public UpdateEnvironmentResponse UpdateServer(UpdateEnvironmentServerRequest updateEnvironmentServerRequest)
        {
            var updateEnvironmentResponse = new UpdateEnvironmentResponse();
            _environmentRepository.UpdateServer(updateEnvironmentServerRequest);
            return updateEnvironmentResponse;
        }

        public UpdateEnvironmentResponse AddServer(UpdateEnvironmentServerRequest updateEnvironmentServerRequest)
        {
            var updateEnvironmentResponse = new UpdateEnvironmentResponse();
            _environmentRepository.AddEnvironmentsDetail(updateEnvironmentServerRequest);
            return updateEnvironmentResponse;
        }

        public UpdateEnvironmentResponse DelServer(Guid detailId)
        {
            var updateEnvironmentResponse = new UpdateEnvironmentResponse();
            _environmentRepository.DelEnvironmentDetail(detailId);
            return updateEnvironmentResponse;
        }
    }
}
