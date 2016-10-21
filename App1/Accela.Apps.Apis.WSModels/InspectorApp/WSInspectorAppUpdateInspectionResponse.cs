using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract(Name = "updateInspectionResponse")]
    public class WSInspectorAppUpdateInspectionResponse
    {
        /// <summary>
        /// Gets or sets the inspection.
        /// </summary>
        /// <value>
        /// The inspection.
        /// </value>
        [DataMember(Name = "inspection")]
        public WSInspectorAppInspection Inspection { get; set; }

        public static WSInspectorAppUpdateInspectionResponse FromEntityModel(InspectionResponse model)
        {
            WSInspectorAppUpdateInspectionResponse result = null;

            if (model != null)
            {
                result = new WSInspectorAppUpdateInspectionResponse()
                {
                    Inspection = WSInspectorAppInspection.FromEntityModel(model.Inspection)
                };
            }

            return result;
        }
    }
}
