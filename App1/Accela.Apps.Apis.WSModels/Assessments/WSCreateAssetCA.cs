using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Requests.AssetRequests;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;
using Accela.Apps.Apis.WSModels.Assets;
using Accela.Apps.Apis.WSModels.ASIs;

namespace Accela.Apps.Apis.WSModels.Assessments
{
    public class WSCreateAssetCA : WSAssetCABase
    {
        public static CreateAssetCARequest ToEntityModel(WSCreateAssetCA wsCreateAssetCA)
        {
            CreateAssetCARequest createAssetCARequest = null;
            if (wsCreateAssetCA != null)
            {
                createAssetCARequest = new CreateAssetCARequest();
                createAssetCARequest.AssetCAModel = new AssetCAModel();
                
                createAssetCARequest.AssetCAModel.Asset = new AssetModel();
                createAssetCARequest.AssetCAModel.Asset.Id = wsCreateAssetCA.AssetId;
                createAssetCARequest.AssetCAModel.Status = WSAssetCAStatus.ToEntityModel(wsCreateAssetCA.Status);
                createAssetCARequest.AssetCAModel.Type = WSAssetCAType.ToEntityModel(wsCreateAssetCA.Type);
                createAssetCARequest.AssetCAModel.ScheduleDate = wsCreateAssetCA.ScheduleDate;
                createAssetCARequest.AssetCAModel.ScheduleTime = wsCreateAssetCA.ScheduleTime;
                createAssetCARequest.AssetCAModel.InspectionDate = wsCreateAssetCA.InspectionDate;
                createAssetCARequest.AssetCAModel.InspectionTime = wsCreateAssetCA.InspectionTime;

                createAssetCARequest.AssetCAModel.Department = WSAssetCADepartment.ToEntityModel(wsCreateAssetCA.Department);
                createAssetCARequest.AssetCAModel.StaffPerson = WSAssetCAStaffPerson.ToEntityModel(wsCreateAssetCA.StaffPerson);

                createAssetCARequest.AssetCAModel.TimeSpent = wsCreateAssetCA.TimeSpent;
                createAssetCARequest.AssetCAModel.Comment = wsCreateAssetCA.Comment;

                createAssetCARequest.AssetCAModel.AdditionalInformations = WSASI.ToEntityModels(wsCreateAssetCA.Attributes);
                createAssetCARequest.AssetCAModel.Observations = WSASIT.ToEntityModels(wsCreateAssetCA.Observations);
            }
            return createAssetCARequest;
        }
    }
}
