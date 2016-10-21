using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DTOs.Responses.AssetResponse;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.AssessmentResponses;

namespace Accela.Apps.Apis.BusinessEntities.Interfaces
{
    public interface IAssessmentBusinessEntity : IBusinessEntity
    {
        /// <summary>
        /// Search Assessments
        /// </summary>
        /// <param name="assessmentsSearchRequest">AssessmentsSearchRequest</param>
        /// <param name="pageInfo">PageInfo.</param>
        /// <returns>AssetCAModel list</returns>
        GetAssetCAsResponse SearchAssessments(AssessmentsSearchRequest request);

        /// <summary>
        /// Update assessment.
        /// </summary>
        /// <param name="updateAssetCARequest">updateAssetCARequest.</param>
        /// <returns>UpdateAssetCAResponse.</returns>
        UpdateAssetCAResponse UpdateAssetCA(UpdateAssetCARequest updateAssetCARequest);

        /// <summary>
        /// Create assessment.
        /// </summary>
        /// <param name="createAssetCARequest">createAssetCARequest.</param>
        /// <returns>CreateAssetCAResponse.</returns>
        CreateAssetCAResponse CreateAssetCA(CreateAssetCARequest createAssetCARequest);
    }
}
