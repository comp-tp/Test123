using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract]
    public class WSInspectionsResponse : WSPagedResponse
    {
        [DataMember(Name = "inspections")]
        public List<WSInspection> Inspections { get; set; }

        public static WSInspectionsResponse FromEntityModel(InspectionsResponse entityResponse)
        {
            var response = new WSInspectionsResponse
            {
                PageInfo = WSPagination.FromEntityModel(entityResponse.PageInfo),
                Inspections = new List<WSInspection>()
            };

            if (entityResponse.Inspections != null)
            {
                entityResponse.Inspections.ForEach(model => response.Inspections.Add(WSInspection.FromEntityModel(model)));
            }

            return response;
        }
    }
}
