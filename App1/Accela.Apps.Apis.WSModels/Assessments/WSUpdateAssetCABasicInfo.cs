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
    public class WSUpdateAssetCABasicInfo : WSCreateAssetCABase
    {
        public static UpdateAssetCARequest ToEntityModel(WSUpdateAssetCABasicInfo wsUpdateAssetCABasicInfo)
        {
            UpdateAssetCARequest updateAssetCARequest = null;
            if (wsUpdateAssetCABasicInfo != null)
            {
                updateAssetCARequest = new UpdateAssetCARequest();
                updateAssetCARequest.AssetCAModel = new AssetCAModel();
                
                updateAssetCARequest.AssetCAModel.Asset = new AssetModel();
                updateAssetCARequest.AssetCAModel.Asset.Id = wsUpdateAssetCABasicInfo.AssetId;
                updateAssetCARequest.AssetCAModel.Status = WSAssetCAStatus.ToEntityModel(wsUpdateAssetCABasicInfo.Status);
                updateAssetCARequest.AssetCAModel.Type = WSAssetCAType.ToEntityModel(wsUpdateAssetCABasicInfo.Type);
                updateAssetCARequest.AssetCAModel.ScheduleDate = wsUpdateAssetCABasicInfo.ScheduleDate;
                updateAssetCARequest.AssetCAModel.ScheduleTime = wsUpdateAssetCABasicInfo.ScheduleTime;
                updateAssetCARequest.AssetCAModel.InspectionDate = wsUpdateAssetCABasicInfo.InspectionDate;
                updateAssetCARequest.AssetCAModel.InspectionTime = wsUpdateAssetCABasicInfo.InspectionTime;

                updateAssetCARequest.AssetCAModel.Department = WSAssetCADepartment.ToEntityModel(wsUpdateAssetCABasicInfo.Department);
                updateAssetCARequest.AssetCAModel.StaffPerson = WSAssetCAStaffPerson.ToEntityModel(wsUpdateAssetCABasicInfo.StaffPerson);

                updateAssetCARequest.AssetCAModel.TimeSpent = wsUpdateAssetCABasicInfo.TimeSpent;
                updateAssetCARequest.AssetCAModel.Comment = wsUpdateAssetCABasicInfo.Comment;
            }
            return updateAssetCARequest;
        }
    }
}
