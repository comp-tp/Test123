using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract(Name = "inspectionsResponse")]
    public class WSInspectorAppInspectionsResponse : WSPagedResponse
    {
        [DataMember(Name = "inspections", EmitDefaultValue = false)]
        public List<WSInspectorAppInspection> Inspections { get; set; }

        public static WSInspectorAppInspectionsResponse FromEntityModel(InspectionsResponse model)
        {
            WSInspectorAppInspectionsResponse result = null;

            if (model != null)
            {
                result = new WSInspectorAppInspectionsResponse()
                {
                    PageInfo = WSPagination.FromEntityModel(model.PageInfo),
                    Inspections = WSInspectorAppInspection.FromEntityModels(model.Inspections)
                };
            }

            return result;
        }
    }
}
