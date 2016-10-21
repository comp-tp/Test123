using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.WSModels.Inspections;

namespace Accela.Apps.Apis.WSModels.RecordInspections
{
    [DataContract(Name = "getRecordInspectionsResponse")]
    public class WSRecordInspectionsResponse : WSPagedResponse
    {
        /// <summary>
        /// The record inspection information.
        /// </summary>
        [DataMember(Name = "inspections", EmitDefaultValue = false)]
        public List<WSInspection> Inspections { get; set; }

        /// <summary>
        /// Converts from the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>ws owners response</returns>
        public static WSRecordInspectionsResponse FromEntityModel(RecordInspectionsResponse entityResponse)
        {
            var response = new WSRecordInspectionsResponse
            {
            };

            response.Inspections = new List<WSInspection>();

            if (entityResponse.Inspections != null)
            {
                entityResponse.Inspections.ForEach(model => response.Inspections.Add(WSInspection.FromEntityModel(model)));
            }

            return response;
        }
    }
}
