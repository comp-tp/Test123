using System;
using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.GISModels;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Owners;
using Accela.Apps.Shared;

using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/owners")]
    [APIControllerInfoAttribute(Name = "Owners", Group = "Entities", Order=9, Description = "The following API is exposed to owners.")]
    public class OwnersController : ControllerBase
    {
        //private static Dictionary<string, object> MakeConstructorParameters()
        //{
        //    Dictionary<string, object> tmpParams = new Dictionary<string, object>();

        //    tmpParams.Add("appId", Context.App);
        //    tmpParams.Add("agencyName", Context.Agency);
        //    tmpParams.Add("serviceProvCode", Context.ServProvCode);
        //    tmpParams.Add("agencyUserId", Context.CurrentUser.Id.ToString());
        //    tmpParams.Add("agencyUsername", Context.CurrentUser.LoginName);
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

        public OwnersController(IReferenceBusinessEntity referenceBusinessEntity)
        {
            this.referenceBusinessEntity = referenceBusinessEntity;
        }

        [Route("")]
        [APIActionInfoAttribute(Name = "Search Owners", Scope = "get_owners", Order=1, Applicability = APIActionInfoAttribute.APPLICABILITY_BOTH, Description = "Retrieves owners meeting the query parameters.")]
        public WSOwnersResponse GetOwners(string fullName = null, string firstName = null, string middleNames = null, string lastName = null,
                                          string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {

            var request = new OwnersRequest();
            request.OwnerWithNoId = this.BuildOwnerModel(fullName, firstName, middleNames, lastName);
            SetPageRangeToRequest(request, offset, limit);
            var tempResult = this.ExcuteV1_2<OwnersResponse, OwnersRequest>(
                (o) =>
                {
                    return referenceBusinessEntity.GetOwners(o);
                },
                request);

            var result = WSOwnersResponse.FromEntityModel(tempResult);
            return result;

        }

        private OwnerModel BuildOwnerModel(string fullName, string firstName, string middleNames, string lastName)
        {
            if (String.IsNullOrWhiteSpace(fullName) && String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(middleNames) && String.IsNullOrWhiteSpace(lastName))
            {
                return null;
            }

            var result = new OwnerModel();
            result.FullName = fullName;
            result.GivenName = firstName;
            result.FamilyName = lastName;
            result.MiddleNames = !String.IsNullOrWhiteSpace(middleNames) ? middleNames.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList() : null;
            return result;
        }

        private List<GISObjectModel> BuildGisObjectModels(string gisObjectIds, string gisLayerIds, string mapServiceIds)
        {
            var gisObjectIdArray = !String.IsNullOrWhiteSpace(gisObjectIds) ? gisObjectIds.Split(new string[] { "," }, StringSplitOptions.None) : null;
            var gisLayerIdArray = !String.IsNullOrWhiteSpace(gisLayerIds) ? gisLayerIds.Split(new string[] { "," }, StringSplitOptions.None) : null;
            var mapServiceIdArray = !String.IsNullOrWhiteSpace(mapServiceIds) ? mapServiceIds.Split(new string[] { "," }, StringSplitOptions.None) : null;

            if (gisObjectIdArray == null || gisLayerIdArray == null && gisLayerIdArray == null)
            {
                return null;
            }

            var result = new List<GISObjectModel>();

            for (int i = 0; i < gisObjectIdArray.Length; i++)
            {
                var gisObject = new GISObjectModel();
                var gisObjectId = i < gisObjectIdArray.Length ? gisObjectIdArray[i] : String.Empty;
                var gisLayerId = i < gisLayerIdArray.Length ? gisLayerIdArray[i] : String.Empty;
                var mapServiceId = i < mapServiceIdArray.Length ? mapServiceIdArray[i] : String.Empty;
                gisObject.Id = gisObjectId;
                gisObject.GISLayerId = gisLayerId;
                gisObject.MapServiceId = mapServiceId;
                result.Add(gisObject);
            }

            return result;
        }
    }
}
