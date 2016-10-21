using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.WSModels.Assets
{
    public class WSAssetInCA : WSIdentifierBase
    {

    }

    [DataContract(Name = "assetCABasicInfo")]
    public class WSAssetCABasicInfo : WSIdentifierBase
    {
        [DataMember(Name = "asset", EmitDefaultValue = false, Order = 4)]
        public WSAssetInCA Asset { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false, Order = 5)]
        public WSAssetCAStatus Status { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false, Order = 6)]
        public WSAssetCAType Type { get; set; }

        [DataMember(Name = "scheduleDate", EmitDefaultValue = false, Order = 7)]
        public string ScheduleDate { get; set; }

        [DataMember(Name = "scheduleTime", EmitDefaultValue = false, Order = 8)]
        public string ScheduleTime { get; set; }

        [DataMember(Name = "inspectionDate", EmitDefaultValue = false, Order = 9)]
        public string InspectionDate { get; set; }

        [DataMember(Name = "inspectionTime", EmitDefaultValue = false, Order = 10)]
        public string InspectionTime { get; set; }

        [DataMember(Name = "department", EmitDefaultValue = false, Order = 11)]
        public WSAssetCADepartment Department { get; set; }

        [DataMember(Name = "staffPerson", EmitDefaultValue = false, Order = 12)]
        public WSAssetCAStaffPerson StaffPerson { get; set; }

        [DataMember(Name = "timeSpent", EmitDefaultValue = false, Order = 13)]
        public string TimeSpent { get; set; }

        [DataMember(Name = "comment", EmitDefaultValue = false, Order = 14)]
        public string Comment { get; set; }

        public static List<WSAssetCABasicInfo> FromWSAssetCAs(List<WSAssetCA> wsAssetCAs)
        {
            var wsAssetCAInfos = new List<WSAssetCABasicInfo>();
            if (wsAssetCAs != null && wsAssetCAs.Count > 0)
            {
                foreach (var wsAssetCA in wsAssetCAs)
                {
                    wsAssetCAInfos.Add(FromWSAssetCA(wsAssetCA));
                }
            }
            return wsAssetCAInfos;
        }        

        public static WSAssetCABasicInfo FromWSAssetCA(WSAssetCA wsAssetCA)
        {
            WSAssetCABasicInfo wsAssetCABasicInfo = null;
            if (wsAssetCA != null)
            {
                wsAssetCABasicInfo = new WSAssetCABasicInfo();
                wsAssetCABasicInfo.Id = wsAssetCA.Id;
                if (wsAssetCA.Asset != null)
                {
                    wsAssetCABasicInfo.Asset = new WSAssetInCA
                    {
                        Id = wsAssetCA.Asset.Id,
                        Display = wsAssetCA.Asset.Display
                    };
                }
                wsAssetCABasicInfo.Display = wsAssetCA.Display;
                wsAssetCABasicInfo.Comment = wsAssetCA.Comment;
                wsAssetCABasicInfo.Department = wsAssetCA.Department;
                wsAssetCABasicInfo.ScheduleDate = wsAssetCA.ScheduleDate;
                wsAssetCABasicInfo.ScheduleTime = wsAssetCA.ScheduleTime;
                wsAssetCABasicInfo.InspectionDate = wsAssetCA.InspectionDate;
                wsAssetCABasicInfo.InspectionTime = wsAssetCA.InspectionTime;
                wsAssetCABasicInfo.StaffPerson = wsAssetCA.StaffPerson;
                wsAssetCABasicInfo.Status = wsAssetCA.Status;
                wsAssetCABasicInfo.TimeSpent = wsAssetCA.TimeSpent;
                wsAssetCABasicInfo.Type = wsAssetCA.Type;
            }
            return wsAssetCABasicInfo;
        } 
    }
}
