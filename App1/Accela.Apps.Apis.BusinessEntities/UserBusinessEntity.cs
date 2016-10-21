using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.UserRequest;
using Accela.Apps.Apis.Models.DTOs.Responses.UserReponses;
using Accela.Apps.Apis.Repositories.Interfaces.Admin;
using Accela.Apps.Shared;
using Accela.Core.Ioc;
using Accela.Apps.Admin.Agency.Client;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class UserBusinessEntity : IUserBusinessEntity
    {
        private readonly Admin.Agency.Client.IAgencySettingsService _agencyService;
        private readonly IUserRepository userRepository;
        public UserBusinessEntity(Admin.Agency.Client.IAgencySettingsService agencyService, IUserRepository userRepository)
        {
            this._agencyService = agencyService;
            this.userRepository = userRepository;
        }


        public UserProfileResponse GetUserProfile(UserProfileRequest request)
        {
            var agencyInfo = _agencyService.GetAgency(request.AgencyName);

            return userRepository.GetUserProfile(request);
        }
    }
}
