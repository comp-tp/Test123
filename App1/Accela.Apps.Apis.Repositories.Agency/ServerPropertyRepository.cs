using Accela.Apps.Apis.Models.DomainModels.ServerPropertyModels;
//using Accela.Apps.Apis.Models.DTOs.V4.Agency;
using Accela.Apps.Apis.Repositories.Agency.AARESTModels;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.Gateway.Client;
using System;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class ServerPropertyRepository : RepositoryBase, IServerPropertyRepository
    {
        private IGatewayClient _gatewayClient;

        public ServerPropertyRepository(IAgencyAppContext contextEntity, IGatewayClient gatewayClient) : base(contextEntity)
        {
            _gatewayClient = gatewayClient;
        }

        public ServerPropertyV4Model GetServerProperties(string agencyName, string environment)
        {
            var requestUrl = "apis/serverProperties";
            //var aaRestClient = new AARestClient(agencyName, environment);
            var aaResult = _gatewayClient.Get<BizServerPropertiesResponse>(ApiTypes.NormalApi, requestUrl);

            if (aaResult == null)
            {
                throw new MobileException("No results returned from Biz server.");
            }

            if (aaResult.status != 200)
            {
                throw new MobileException(aaResult.message, aaResult.more, aaResult.code);
            }

            return new ServerPropertyV4Model()
            {
                Version = aaResult.result.version
            };
        }
    }
}
