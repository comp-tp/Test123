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
    public class WSUpdateAssetCA : WSAssetCABase
    {
        public static UpdateAssetCARequest ToEntityModel(WSUpdateAssetCA wsUpdateAssetCA)
        {
            UpdateAssetCARequest updateAssetCARequest = null;
            if (wsUpdateAssetCA != null)
            {
                updateAssetCARequest = new UpdateAssetCARequest();
                updateAssetCARequest.AssetCAModel = new AssetCAModel();

                updateAssetCARequest.AssetCAModel.Identifier = wsUpdateAssetCA.Id;
                updateAssetCARequest.AssetCAModel.Display = wsUpdateAssetCA.Display;

                updateAssetCARequest.AssetCAModel.Asset = new AssetModel();
                updateAssetCARequest.AssetCAModel.Asset.Id = wsUpdateAssetCA.AssetId;
                updateAssetCARequest.AssetCAModel.Status = WSAssetCAStatus.ToEntityModel(wsUpdateAssetCA.Status);
                updateAssetCARequest.AssetCAModel.Type = WSAssetCAType.ToEntityModel(wsUpdateAssetCA.Type);
                updateAssetCARequest.AssetCAModel.ScheduleDate = wsUpdateAssetCA.ScheduleDate;
                updateAssetCARequest.AssetCAModel.ScheduleTime = wsUpdateAssetCA.ScheduleTime;
                updateAssetCARequest.AssetCAModel.InspectionDate = wsUpdateAssetCA.InspectionDate;
                updateAssetCARequest.AssetCAModel.InspectionTime = wsUpdateAssetCA.InspectionTime;

                updateAssetCARequest.AssetCAModel.Department = WSAssetCADepartment.ToEntityModel(wsUpdateAssetCA.Department);
                updateAssetCARequest.AssetCAModel.StaffPerson = WSAssetCAStaffPerson.ToEntityModel(wsUpdateAssetCA.StaffPerson);

                updateAssetCARequest.AssetCAModel.TimeSpent = wsUpdateAssetCA.TimeSpent;
                updateAssetCARequest.AssetCAModel.Comment = wsUpdateAssetCA.Comment;

                updateAssetCARequest.AssetCAModel.AdditionalInformations = WSASI.ToEntityModels(wsUpdateAssetCA.Attributes);
                updateAssetCARequest.AssetCAModel.Observations = WSASIT.ToEntityModels(wsUpdateAssetCA.Observations);
            }
            return updateAssetCARequest;
        }

        public static UpdateAssetCARequest ToEntityModel(WSUpdateAssetCABasicInfo wsUpdateAssetCABasicInfo, List<WSASI> attributes = null,  List<WSASIT> observations = null)
        {
            UpdateAssetCARequest updateAssetCARequest = null;
            if (wsUpdateAssetCABasicInfo != null)
            {
                updateAssetCARequest = new UpdateAssetCARequest();
                updateAssetCARequest.AssetCAModel = new AssetCAModel();

                updateAssetCARequest.AssetCAModel.Identifier = wsUpdateAssetCABasicInfo.Id;
                updateAssetCARequest.AssetCAModel.Display = wsUpdateAssetCABasicInfo.Display;

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

                updateAssetCARequest.AssetCAModel.AdditionalInformations = WSASI.ToEntityModels(attributes);
                updateAssetCARequest.AssetCAModel.Observations = WSASIT.ToEntityModels(observations);
            }
            return updateAssetCARequest;
        }

        public static WSUpdateAssetCA FromEntityModel(WSAssetCA wsAssetCA)
        {
            WSUpdateAssetCA wsUpdateAssetCA = null;
            if (wsAssetCA != null)
            {
                wsUpdateAssetCA = new WSUpdateAssetCA();
                if(wsAssetCA.Asset != null)
                {
                    wsUpdateAssetCA.AssetId = wsAssetCA.Asset.Id;
                }
                wsUpdateAssetCA.Attributes = wsAssetCA.Attributes;
                wsUpdateAssetCA.Comment = wsAssetCA.Comment;
                wsUpdateAssetCA.Department = wsAssetCA.Department;
                wsUpdateAssetCA.Display = wsAssetCA.Display;
                wsUpdateAssetCA.Id = wsAssetCA.Id;
                wsUpdateAssetCA.InspectionDate = wsAssetCA.InspectionDate;
                wsUpdateAssetCA.InspectionTime = wsAssetCA.InspectionTime;
                wsUpdateAssetCA.Observations = wsAssetCA.Observations;
                wsUpdateAssetCA.ScheduleDate = wsAssetCA.ScheduleDate;
                wsUpdateAssetCA.ScheduleTime = wsAssetCA.ScheduleTime;
                wsUpdateAssetCA.StaffPerson = wsAssetCA.StaffPerson;
                wsUpdateAssetCA.Status = wsAssetCA.Status;
                wsUpdateAssetCA.TimeSpent = wsAssetCA.TimeSpent;
                wsUpdateAssetCA.Type = wsAssetCA.Type;
            }
            return wsUpdateAssetCA;
        }
    }
}
