using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Models.DTOs.Responses.AssessmentResponses;
using Accela.Core.Ioc;

namespace Accela.Apps.Apis.BusinessEntities
{
    public class AssessmentBusinessEntity : BusinessEntityBase, IAssessmentBusinessEntity
    {
        
        public AssessmentBusinessEntity(IAssessmentRepository assessmentRepository)
        {
            this.assessmentRepository = assessmentRepository;
        }

        private readonly IAssessmentRepository assessmentRepository;
       

        public GetAssetCAsResponse SearchAssessments(AssessmentsSearchRequest request)
        {
            var searchAssetCAsResponse = new GetAssetCAsResponse();
            Pagination pageInfo;
            var assessmentModels = assessmentRepository.SearchAssessments(request, out pageInfo);
            searchAssetCAsResponse.AssetCAModels = assessmentModels;
            searchAssetCAsResponse.PageInfo = pageInfo;
            return searchAssetCAsResponse;
        }

        public UpdateAssetCAResponse UpdateAssetCA(UpdateAssetCARequest updateAssetCARequest)
        {
            return assessmentRepository.UpdateAssetCA(updateAssetCARequest);
        }

        public CreateAssetCAResponse CreateAssetCA(CreateAssetCARequest createAssetCARequest)
        {
            return assessmentRepository.CreateAssetCA(createAssetCARequest);
        }
    }

}
