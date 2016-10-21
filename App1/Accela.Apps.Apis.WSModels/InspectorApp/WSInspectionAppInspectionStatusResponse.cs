using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract(Name = "inspectionStatusResponse")]
    public class WSInspectionAppInspectionStatusResponse : WSPagedResponse
    {
        /// <summary>
        /// Gets or sets the inspection statuses.
        /// </summary>
        /// <value>
        /// The inspection statuses.
        /// </value>
        [DataMember(Name = "inspectionStatuses")]
        public List<WSInspectorAppInspectionStatus> InspectionStatuses
        {
            get;
            set;
        }

        public static WSInspectionAppInspectionStatusResponse FromEntityModels(InspectionStatusResponse model)
        {
            WSInspectionAppInspectionStatusResponse result = null;

            if (model != null)
            {
                result = new WSInspectionAppInspectionStatusResponse()
                {
                    PageInfo = WSPagination.FromEntityModel(model.PageInfo),
                    InspectionStatuses = WSInspectorAppInspectionStatus.FromEntityModels(model.InspectionStatuses)
                };
            }

            return result;
        }
    }
}
