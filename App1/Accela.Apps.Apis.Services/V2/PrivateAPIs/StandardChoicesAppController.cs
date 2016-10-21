using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AttributeRouting;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Shared;
using AttributeRouting.Web.Http;
using Accela.Apps.Apis.WSModels.StandardChoices;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.StandardChoicesResponses;

namespace Accela.Apps.Apis.Services.V2.PrivateAPIs
{
    [RoutePrefix("v3")]
    [APIControllerInfoAttribute(Name = "StandardChoicesApp", Description = "The following APIs are exposed to standardchoices apps.")]
    public class StandardChoicesAppController : ControllerBase
    {
        private static Dictionary<string, object> MakeConstructorParameters()
        {
            Dictionary<string, object> tmpParams = new Dictionary<string, object>();

            tmpParams.Add("appId", Context.App);
            tmpParams.Add("agencyName", Context.Agency);
            tmpParams.Add("serviceProvCode", Context.ServProvCode);
            tmpParams.Add("agencyUserId", Context.CurrentUser.Id.ToString());
            tmpParams.Add("agencyUsername", Context.LoginName);
            tmpParams.Add("token", Context.SocialToken);
            tmpParams.Add("environmentName", Context.EnvName);
            tmpParams.Add("language", Context.Language);

            return tmpParams;
        }

        private IReferenceBusinessEntity _referenceBusinessEntity = null;
        private IReferenceBusinessEntity ReferenceBusinessEntity
        {
            get
            {
                if (_referenceBusinessEntity == null)
                {
                    Dictionary<string, object> ctorParams = MakeConstructorParameters();
                    _referenceBusinessEntity = IocContainer.Resolve<IReferenceBusinessEntity>(ctorParams);
                }

                return _referenceBusinessEntity;
            }
        }

        [GET("workordertask/units/describe/{standardchoicetype}")]
        [APIActionInfoAttribute(Name = "Get Work Order Task Unit", Order = 3, Scope = "standardchoicesapp_get_workordertaskunit", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get describe standard choices.")]
        public WSGetStandardChoicesResponse GetStandardChoice(string standardChoiceType, string standardChoiceValue = null, string lang = null)
        {
            var request = new GetStandardChoicesRequest();
            request.StandardChoiceType = standardChoiceType;
            request.StandardChoiceValue = standardChoiceValue;

            var standardChoicesResponse = this.ExcuteV1_2<StandardChoicesResponse, GetStandardChoicesRequest>(
              (o) =>
              {
                  return ReferenceBusinessEntity.GetStandardChoices(o);
              },
              request);

            var result = WSGetStandardChoicesResponse.FromEntityModel(standardChoicesResponse);
            return result;
        }
    }
}
