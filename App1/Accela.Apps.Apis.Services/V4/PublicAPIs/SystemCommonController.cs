using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.StandardComments.V4;
using Accela.Apps.Shared;

using System.Web.Http;
using System.Collections.Generic;

namespace Accela.Apps.Apis.Services.V4
{
    [RoutePrefix("v4/settings")]
    public class SystemCommonV4Controller : ControllerBase
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

        public SystemCommonV4Controller(IReferenceBusinessEntity referenceBusinessEntity)
        {
            this.referenceBusinessEntity = referenceBusinessEntity;
        }

        [Route("comments")]
        public WSStandardCommentsV4Response GetStandardComments(string groups = null, string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
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

            var result = WSStandardCommentsV4Response.FromEntityModel(tempResult);
            return result;
        }

        [Route("comments/groups")]
        public WSStandardCommentGroupsV4Response GetStandardCommentGroups(string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            var request = new StandardCommentGroupRequest();
            SetPageRangeToRequest(request, offset, limit);

            var tempResult = this.ExcuteV1_2<StandardCommentGroupResponse, StandardCommentGroupRequest>(
                (o) =>
                {
                    return referenceBusinessEntity.GetStandardCommentGroups(o);
                },
                request);

            var result = WSStandardCommentGroupsV4Response.FromEntityModel(tempResult);
            return result;
        }
    }
}
