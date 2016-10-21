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
    public class WSCreateAssetCABasicInfo : WSCreateAssetCABase
    {
        public static CreateAssetCARequest ToEntityModel(WSCreateAssetCABasicInfo wsCreateAssetCABasicInfo)
        {
            CreateAssetCARequest createAssetCARequest = null;
            if (wsCreateAssetCABasicInfo != null)
            {
                createAssetCARequest = new CreateAssetCARequest();
                createAssetCARequest.AssetCAModel = new AssetCAModel();
                
                createAssetCARequest.AssetCAModel.Asset = new AssetModel();
                createAssetCARequest.AssetCAModel.Asset.Id = wsCreateAssetCABasicInfo.AssetId;
                createAssetCARequest.AssetCAModel.Status = WSAssetCAStatus.ToEntityModel(wsCreateAssetCABasicInfo.Status);
                createAssetCARequest.AssetCAModel.Type = WSAssetCAType.ToEntityModel(wsCreateAssetCABasicInfo.Type);
                createAssetCARequest.AssetCAModel.ScheduleDate = wsCreateAssetCABasicInfo.ScheduleDate;
                createAssetCARequest.AssetCAModel.ScheduleTime = wsCreateAssetCABasicInfo.ScheduleTime;
                createAssetCARequest.AssetCAModel.InspectionDate = wsCreateAssetCABasicInfo.InspectionDate;
                createAssetCARequest.AssetCAModel.InspectionTime = wsCreateAssetCABasicInfo.InspectionTime;

                createAssetCARequest.AssetCAModel.Department = WSAssetCADepartment.ToEntityModel(wsCreateAssetCABasicInfo.Department);
                createAssetCARequest.AssetCAModel.StaffPerson = WSAssetCAStaffPerson.ToEntityModel(wsCreateAssetCABasicInfo.StaffPerson);

                createAssetCARequest.AssetCAModel.TimeSpent = wsCreateAssetCABasicInfo.TimeSpent;
                createAssetCARequest.AssetCAModel.Comment = wsCreateAssetCABasicInfo.Comment;
            }
            return createAssetCARequest;
        }
    }
}
