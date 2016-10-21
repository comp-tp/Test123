using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Shared.Utils;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Repositories.Agency.GovXmlHelpers;
using Accela.Apps.Shared;
using Accela.Apps.Apis.Repositories.Agency.Admin;
using Accela.Automation.GovXmlServices.Client.Model;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class AssessmentRepository : RepositoryBase, IAssessmentRepository
    {
        //public AssessmentRepository(string appId, string agencyName, string serviceProvCode, string agencyUserId, string agencyUsername, string token, string environmentName, string language)
        //    : base(appId, agencyName, serviceProvCode, agencyUserId, agencyUsername, token, environmentName, language)
        //{
        //}


        public AssessmentRepository(IAgencyAppContext contextEntity)
            : base(contextEntity)
        {

        }

        public Accela.Apps.Apis.Models.DTOs.Responses.AssessmentResponses.CreateAssetCAResponse CreateAssetCA(CreateAssetCARequest createAssetCARequest)
        {
            GovXML govXmlIn = new GovXML();
            ToGovXmlCreateAssetCARequest(govXmlIn, createAssetCARequest);

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.CreateAssetCA.system,
                (o) => o.CreateAssetCAResponse == null ? null : o.CreateAssetCAResponse.system);

            return GetCreateAssetCAResponse(response.CreateAssetCAResponse);
        }

        private void ToGovXmlCreateAssetCARequest(GovXML govXmlIn, CreateAssetCARequest createAssetCARequest)
        {
            if (createAssetCARequest != null && createAssetCARequest.AssetCAModel != null)
            {
                govXmlIn.CreateAssetCA = new CreateAssetCA();
                govXmlIn.CreateAssetCA.system = CommonHelper.GetSystem(new RequestBase(), this.CurrentContext);

                govXmlIn.CreateAssetCA.assetCA = AssessmentHelper.ToCovXmlAssessment(createAssetCARequest.AssetCAModel);
            }
        }

        private static Accela.Apps.Apis.Models.DTOs.Responses.AssessmentResponses.CreateAssetCAResponse GetCreateAssetCAResponse(Accela.Automation.GovXmlServices.Client.Model.CreateAssetCAResponse xmlObj)
        {
            var result = new Accela.Apps.Apis.Models.DTOs.Responses.AssessmentResponses.CreateAssetCAResponse();

            if (xmlObj.system != null)
            {
                result.Events = CommonHelper.GetClientEventMessage(xmlObj.system.eventMessages);
                result.Id = xmlObj.AssetCAId;
            }

            return result;
        }

        public Accela.Apps.Apis.Models.DTOs.Responses.AssessmentResponses.UpdateAssetCAResponse UpdateAssetCA(UpdateAssetCARequest updateAssetCARequest)
        {
            GovXML govXmlIn = new GovXML();
            ToGovXmlUpdateAssetCARequest(govXmlIn, updateAssetCARequest);

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.UpdateAssetCA.system,
                (o) => o.UpdateAssetCAResponse == null ? null : o.UpdateAssetCAResponse.system);

            return GetUpdateAssetCAResponse(response.UpdateAssetCAResponse);
        }

        private static Accela.Apps.Apis.Models.DTOs.Responses.AssessmentResponses.UpdateAssetCAResponse GetUpdateAssetCAResponse(Accela.Automation.GovXmlClient.Model.UpdateAssetCAResponse xmlObj)
        {
            var result = new Accela.Apps.Apis.Models.DTOs.Responses.AssessmentResponses.UpdateAssetCAResponse();

            if (xmlObj.system != null)
            {
                result.Events = CommonHelper.GetClientEventMessage(xmlObj.system.eventMessages);
            }

            if (xmlObj.assetCA != null)
            {
                result.AssetCAModel = AssetHelper.GetClientAssetCA(xmlObj.assetCA);
            }

            return result;
        }

        private void ToGovXmlUpdateAssetCARequest(GovXML govXmlIn, UpdateAssetCARequest updateAssetCARequest)
        {
            if (updateAssetCARequest != null && updateAssetCARequest.AssetCAModel != null)
            {
                govXmlIn.UpdateAssetCA = new UpdateAssetCA();
                govXmlIn.UpdateAssetCA.system = CommonHelper.GetSystem(new RequestBase(), this.CurrentContext);

                govXmlIn.UpdateAssetCA.assetCA = AssessmentHelper.ToCovXmlAssessment(updateAssetCARequest.AssetCAModel);
            }
        }

        public List<AssetCAModel> SearchAssessments(AssessmentsSearchRequest searchAssessmentRequest, out  Pagination pageInfo)
        {
            GovXML govXmlIn = new GovXML();

            SetSearchAssessmentGovXmlRequest(searchAssessmentRequest, govXmlIn);

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.GetAssetCAs.system,
                (o) => o.GetAssetCAsResponse == null ? null : o.GetAssetCAsResponse.system);

            List<AssetCAModel> assetCAModels = new List<AssetCAModel>();
            if (response != null)
            {
                if (response.GetAssetCAsResponse != null)
                {
                    if (response.GetAssetCAsResponse.assetCAs != null)
                    {
                        if (response.GetAssetCAsResponse.assetCAs != null)
                        {
                            if (response.GetAssetCAsResponse.assetCAs.assetCA != null)
                            {
                                if (response.GetAssetCAsResponse.assetCAs.assetCA.Count() > 0)
                                {
                                    foreach (var assement in response.GetAssetCAsResponse.assetCAs.assetCA)
                                    {
                                        assetCAModels = AssetHelper.GetClientAssetCAs(response.GetAssetCAsResponse.assetCAs.assetCA.ToList());
                                    }
                                }
                            }
                        }
                    }
                }
            }

            pageInfo = new Pagination();
            if (response.GetAssetCAsResponse != null && response.GetAssetCAsResponse.system != null)
            {
                pageInfo = CommonHelper.GetPaginationFromSystem(response.GetAssetCAsResponse.system);
            }

            return assetCAModels;
        }

        private void SetSearchAssessmentGovXmlRequest(AssessmentsSearchRequest searchAssessmentRequest, GovXML govXmlIn)
        {
            if (searchAssessmentRequest != null)
            {
                govXmlIn.GetAssetCAs = new GetAssetCAs();

                govXmlIn.GetAssetCAs.system = CommonHelper.GetSystem(new RequestBase() { Offset = searchAssessmentRequest.Offset, Limit = searchAssessmentRequest.Limit }, this.CurrentContext);

                if (!string.IsNullOrWhiteSpace(searchAssessmentRequest.AssessmentId))
                {
                    govXmlIn.GetAssetCAs.assetCAId = searchAssessmentRequest.AssessmentId;
                }

                if (!string.IsNullOrWhiteSpace(searchAssessmentRequest.AssessmentTypeId))
                {
                    govXmlIn.GetAssetCAs.AssetCAType = new AssetCAType();
                    govXmlIn.GetAssetCAs.AssetCAType.keys = KeysHelper.CreateXMLKeys(searchAssessmentRequest.AssessmentTypeId);
                }

                if (!string.IsNullOrWhiteSpace(searchAssessmentRequest.AssessmentStatusId))
                {
                    govXmlIn.GetAssetCAs.AssetCAStatus = new Status();
                    govXmlIn.GetAssetCAs.AssetCAStatus.keys = KeysHelper.CreateXMLKeys(searchAssessmentRequest.AssessmentStatusId);
                    govXmlIn.GetAssetCAs.AssetCAStatus.name = searchAssessmentRequest.AssessmentStatusId;
                }

                if (!string.IsNullOrWhiteSpace(searchAssessmentRequest.AssetName))
                {
                    govXmlIn.GetAssetCAs.asset = new Asset();
                    govXmlIn.GetAssetCAs.asset.Name = searchAssessmentRequest.AssetName;
                }

                if (!string.IsNullOrWhiteSpace(searchAssessmentRequest.AssetTypeId))
                {
                    if (Environment.BizServerVersion != "705")
                    {
                        govXmlIn.GetAssetCAs.assetTypes = new AssetTypes();
                        govXmlIn.GetAssetCAs.assetTypes.assetType = new AssetType[1];
                        govXmlIn.GetAssetCAs.assetTypes.assetType[0] = new AssetType();
                        govXmlIn.GetAssetCAs.assetTypes.assetType[0].keys = KeysHelper.CreateXMLKeys(searchAssessmentRequest.AssetTypeId);
                    }
                }

                if (!string.IsNullOrWhiteSpace(searchAssessmentRequest.AssetId))
                {
                    govXmlIn.GetAssetCAs.AssetIds = new AssetIds();
                    govXmlIn.GetAssetCAs.AssetIds.assetId = new AssetId[1];
                    govXmlIn.GetAssetCAs.AssetIds.assetId[0] = new AssetId();
                    govXmlIn.GetAssetCAs.AssetIds.assetId[0].keys = KeysHelper.CreateXMLKeys(searchAssessmentRequest.AssetId);
                }

                if (!String.IsNullOrWhiteSpace(searchAssessmentRequest.AssetIdDisplay))
                {
                    govXmlIn.GetAssetCAs.AssetId = searchAssessmentRequest.AssetIdDisplay;
                }

                if (!String.IsNullOrWhiteSpace(searchAssessmentRequest.DepartmentId))
                {
                    govXmlIn.GetAssetCAs.Departments = new Departments();
                    govXmlIn.GetAssetCAs.Departments.Department = new Department[1];
                    govXmlIn.GetAssetCAs.Departments.Department[0] = new Department();
                    govXmlIn.GetAssetCAs.Departments.Department[0].keys = KeysHelper.CreateXMLKeys(searchAssessmentRequest.DepartmentId);
                }

                if (!String.IsNullOrWhiteSpace(searchAssessmentRequest.InspectorId))
                {
                    if (govXmlIn.GetAssetCAs.Departments == null)
                    {
                        govXmlIn.GetAssetCAs.Departments = new Departments();
                        govXmlIn.GetAssetCAs.Departments.Department = new Department[1];
                        govXmlIn.GetAssetCAs.Departments.Department[0] = new Department();
                    }

                    govXmlIn.GetAssetCAs.Departments.Department[0].Staff = new Staff();
                    govXmlIn.GetAssetCAs.Departments.Department[0].Staff.StaffPerson = new StaffPerson[1];
                    govXmlIn.GetAssetCAs.Departments.Department[0].Staff.StaffPerson[0] = new StaffPerson();
                    govXmlIn.GetAssetCAs.Departments.Department[0].Staff.StaffPerson[0].keys = KeysHelper.CreateXMLKeys(searchAssessmentRequest.InspectorId);
                }

                if (!string.IsNullOrWhiteSpace(searchAssessmentRequest.InspectionDateFrom) || !string.IsNullOrWhiteSpace(searchAssessmentRequest.InspectionDateTo))
                {
                    govXmlIn.GetAssetCAs.inspectionDateRanges = new DateRange();

                    if (!string.IsNullOrWhiteSpace(searchAssessmentRequest.InspectionDateFrom))
                    {
                        govXmlIn.GetAssetCAs.inspectionDateRanges.from = searchAssessmentRequest.InspectionDateFrom;
                    }

                    if (!string.IsNullOrWhiteSpace(searchAssessmentRequest.InspectionDateTo))
                    {
                        govXmlIn.GetAssetCAs.inspectionDateRanges.to = searchAssessmentRequest.InspectionDateTo;
                    }
                }

                if (!string.IsNullOrWhiteSpace(searchAssessmentRequest.ScheduledDateFrom) || !string.IsNullOrWhiteSpace(searchAssessmentRequest.ScheduledDateTo))
                {
                    govXmlIn.GetAssetCAs.scheduledDateRanges = new DateRange()
;
                    if (!string.IsNullOrWhiteSpace(searchAssessmentRequest.ScheduledDateFrom))
                    {
                        govXmlIn.GetAssetCAs.scheduledDateRanges.from = searchAssessmentRequest.ScheduledDateFrom;
                    }

                    if (!string.IsNullOrWhiteSpace(searchAssessmentRequest.ScheduledDateTo))
                    {
                        govXmlIn.GetAssetCAs.scheduledDateRanges.to = searchAssessmentRequest.ScheduledDateTo;
                    }

                }
            }
        }
    }
}
