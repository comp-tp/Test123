using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.Inspections;
using Accela.Apps.Apis.WSModels.Records;
using Accela.Apps.Apis.WSModels.Comments;
using Accela.Apps.Apis.WSModels.ASIs.InspectorApp;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract(Name = "updateInspectionRequest")]
    public class WSInspectorAppUpdateInspectionRequest
    {
        [DataMember(Name = "inspection")]
        public WSInspectorAppInspection Inspection { get; set; }

        public static InspectionRequest ToEntityModel(string inspectionId, WSInspectorAppUpdateInspectionRequest wsInspectorAppUpdateInspectionRequest)
        {
            InspectionRequest result = null;

            if (wsInspectorAppUpdateInspectionRequest != null)
            {
                result = new InspectionRequest()
                {
                    InspectionId = inspectionId,
                    InspectionModel = WSInspectorAppInspection.ToEntityModel(wsInspectorAppUpdateInspectionRequest.Inspection)
                };
            }

            return result;
        }
    }
}
