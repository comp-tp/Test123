using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.Departments;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.Departments;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Common;
using Accela.Apps.Apis.WSModels.Departments;
using Accela.Apps.Apis.WSModels.Modules;
using Accela.Apps.Apis.WSModels.StandardComments;
using Accela.Apps.Shared;

using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/system")]
    [APIControllerInfoAttribute(Name = "Standard Comments", Group = "Entities", Order = 13, Description = "System Common REST API")]
    public class SystemCommonController : ControllerBase
    {
        //private static Dictionary<string, object> MakeConstructorParameters()
        //{
        //    Dictionary<string, object> tmpParams = new Dictionary<string, object>();

        //    tmpParams.Add("appId", Context.App);
        //    tmpParams.Add("agencyName", Context.Agency);
        //    tmpParams.Add("serviceProvCode", Context.ServProvCode);
        //    tmpParams.Add("agencyUserId", Context.CurrentUser.Id.ToString());
        //    tmpParams.Add("agencyUsername", Context.LoginName);
        //    tmpParams.Add("token", Context.SocialToken);
        //    tmpParams.Add("environmentName", Context.EnvName);
        //    tmpParams.Add("language", Context.Language);

        //    return tmpParams;
        //}

        //private IReferenceBusinessEntity _referenceBusinessEntity = null;
        private readonly IReferenceBusinessEntity referenceBusinessEntity;
        //{
        //    get
        //    {
        //        if (_referenceBusinessEntity == null)
        //        {
        //            Dictionary<string, object> ctorParams = MakeConstructorParameters();
        //            _referenceBusinessEntity = IocContainer.Resolve<IReferenceBusinessEntity>(ctorParams);
        //        }

        //        return _referenceBusinessEntity;
        //    }
        //}

        public SystemCommonController(IReferenceBusinessEntity referenceBusinessEntity)
        {
            this.referenceBusinessEntity = referenceBusinessEntity; 
        }

        [Route("standardComments")]
        [APIActionInfoAttribute(Name = "Get Standard Comments", Order = 2, Scope = "get_ref_standard_comments", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves standard comments for the standard comment group.")]
        public WSStandardCommentsResponse GetStandardComments(string groups = null, string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            var request = new StandardCommentRequest()
            {
                Groups = SpliteIdsToList(groups)
            };

            SetPageRangeToRequest(request, offset, limit);

            var tempResult = this.ExcuteV1_2<StandardCommentResponse, StandardCommentRequest>(
                (o) =>
                {
                    return referenceBusinessEntity.GetStandardComments(o);
                },
                request);

            var result = WSStandardCommentsResponse.FromEntityModel(tempResult);
            return result;
        }

        [Route("standardCommentGroups")]
        [APIActionInfoAttribute(Name = "Get Standard Comment Groups", Order =1, Scope = "get_ref_standard_comment_groups", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Retrieves standard comment groups from reference data.")]
        public WSStandardCommentGroupsResponse GetStandardCommentGroups(string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            var request = new StandardCommentGroupRequest();
            SetPageRangeToRequest(request, offset, limit);

            var tempResult = this.ExcuteV1_2<StandardCommentGroupResponse, StandardCommentGroupRequest>(
                (o) =>
                {
                    return referenceBusinessEntity.GetStandardCommentGroups(o);
                },
                request);

            var result = WSStandardCommentGroupsResponse.FromEntityModel(tempResult);
            return result;
        }        

        
        
    }
}
