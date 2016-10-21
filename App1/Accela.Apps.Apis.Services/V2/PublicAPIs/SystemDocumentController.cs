using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.AttachmentRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AttachmentResponses;
using Accela.Apps.Apis.Services.Attributes;
using Accela.Apps.Apis.WSModels.Attachments;
using Accela.Apps.Shared;

using System.Web.Http;

namespace Accela.Apps.Apis.Services
{
    [RoutePrefix("v3/system/document")]
    [APIControllerInfoAttribute(Name = "Documents",  Group = "Entities", Order = 12, Description = "These APIs expose to system document application.")]
    public class SystemDocumentController : ControllerBase
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

        public SystemDocumentController(IReferenceBusinessEntity referenceBusinessEntity)
        {
            this.referenceBusinessEntity = referenceBusinessEntity;
        }

        /// <summary>
        /// Get document type.
        /// </summary>
        /// <param name="lang">Lang.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="limit">Limit.</param>
        /// <returns>Document type list.</returns>
        [Route("types")]
        [APIActionInfoAttribute(Name = "Describe Document Types", Order = 1, Scope = "get_ref_document_types", Applicability = APIActionInfoAttribute.APPLICABILITY_AGENCY, Description = "Get a part of the attachment document types limited by 'offset' and 'limit'. ")]
        public WSDocumentTypeResponse GetDocumentType(string lang = null, int offset = 0, int limit = Constants.DEFAULT_ROW_LIMIST)
        {
            var request = new DocumentTypeRequest();
            SetPageRangeToRequest(request, offset, limit);

            var tempResult = this.ExcuteV1_2<DocumentTypesResponse, DocumentTypeRequest>(
              (o) =>
              {
                  return referenceBusinessEntity.GetDocumentType(o);
              },
              request);

            var result = WSDocumentTypeResponse.FromEntityModel(tempResult);
            return result;
        }
    }
}
