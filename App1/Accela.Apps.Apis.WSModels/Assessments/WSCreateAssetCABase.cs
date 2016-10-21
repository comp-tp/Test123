﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.Assets;
using Accela.Apps.Apis.WSModels.ASIs;

namespace Accela.Apps.Apis.WSModels.Assessments
{
    [DataContract(Name = "createAssetCABase")]
    public class WSCreateAssetCABase : WSIdentifierBase
    {
        [DataMember(Name = "assetId", EmitDefaultValue = false, Order = 4)]
        public string AssetId { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false, Order = 4)]
        public WSAssetCAStatus Status { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false, Order = 5)]
        public WSAssetCAType Type { get; set; }

        [DataMember(Name = "scheduleDate", EmitDefaultValue = false, Order = 6)]
        public string ScheduleDate { get; set; }

        [DataMember(Name = "scheduleTime", EmitDefaultValue = false, Order = 7)]
        public string ScheduleTime { get; set; }

        [DataMember(Name = "inspectionDate", EmitDefaultValue = false, Order = 8)]
        public string InspectionDate { get; set; }

        [DataMember(Name = "inspectionTime", EmitDefaultValue = false, Order = 9)]
        public string InspectionTime { get; set; }

        [DataMember(Name = "department", EmitDefaultValue = false, Order = 10)]
        public WSAssetCADepartment Department { get; set; }

        [DataMember(Name = "staffPerson", EmitDefaultValue = false, Order = 11)]
        public WSAssetCAStaffPerson StaffPerson { get; set; }

        [DataMember(Name = "timeSpent", EmitDefaultValue = false, Order = 12)]
        public string TimeSpent { get; set; }

        [DataMember(Name = "comment", EmitDefaultValue = false, Order = 13)]
        public string Comment { get; set; }
    }
}