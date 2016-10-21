using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract(Name="inspectionTypeResponse")]
    public class WSInspectorAppInspectionTypeResponse : WSPagedResponse
    {
        /// <summary>
        /// Gets or sets the inspection types.
        /// </summary>
        /// <value>
        /// The inspection types.
        /// </value>
        [DataMember(Name = "inspectionTypes")]
        public List<WSInspectorAppInspectionType> InspectionTypes
        {
            get;
            set;
        }

        public static WSInspectorAppInspectionTypeResponse FromEntityModels(InspectionTypeResponse model)
        {
            WSInspectorAppInspectionTypeResponse result = null;

            if (model != null)
            {
                result = new WSInspectorAppInspectionTypeResponse()
                {
                    PageInfo = WSPagination.FromEntityModel(model.PageInfo),
                    InspectionTypes = WSInspectorAppInspectionType.FromEntityModels(model.InspectionTypes)
                };
            }

            return result;
        }
    }
}
