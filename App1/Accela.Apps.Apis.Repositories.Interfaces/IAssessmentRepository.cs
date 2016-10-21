using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AssessmentResponses;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IAssessmentRepository : IRepository
    {
        /// <summary>
        /// Search Assessment
        /// </summary>
        /// <param name="request">AssessmentsSearchRequest.</param>
        /// <param name="pageInfo">PageInfo.</param>
        /// <returns>AssetCAModel list.</returns>
        List<AssetCAModel> SearchAssessments(AssessmentsSearchRequest request, out Pagination pageInfo);

        /// <summary>
        /// Update assessment.
        /// </summary>
        /// <param name="updateAssetCARequest">updateAssetCARequest.</param>
        /// <returns>UpdateAssetCAResponse.</returns>
        UpdateAssetCAResponse UpdateAssetCA(UpdateAssetCARequest updateAssetCARequest);

        /// <summary>
        /// Create asset ca.
        /// </summary>
        /// <param name="createAssetCARequest">CreateAssetCARequest.</param>
        /// <returns>CreateAssetCAResponse.</returns>
        CreateAssetCAResponse CreateAssetCA(CreateAssetCARequest createAssetCARequest);
    }
}
