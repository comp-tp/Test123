using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectorResponses;

namespace Accela.Apps.Apis.WSModels.V1.Inspectors
{
    [DataContract(Name = "getInspectorsResponse")]
    public class WSSystemInspectorResponse : WSPagedResponse
    {
        [DataMember(Name = "inspectors", EmitDefaultValue = false)]
        public List<WSSystemInspector> Inspectors { get; set; }

        /// <summary>
        /// Convert biz response to service response. 
        /// </summary>
        public static WSSystemInspectorResponse FromEntityModel(SystemInspectorResponse systemInspectorResponse)
        {
            return new WSSystemInspectorResponse()
            {
                Inspectors   = GetInspectorsFromBiz(systemInspectorResponse.Inspectors),
                PageInfo = WSPagination.FromEntityModel(systemInspectorResponse.PageInfo)
            };
        }

        private static List<WSSystemInspector> GetInspectorsFromBiz(List<SystemInspectorModel> inspectorModels)
        {
            if(inspectorModels !=null)
            {
                List<WSSystemInspector> inspectors = new List<WSSystemInspector>();
                foreach (SystemInspectorModel model in inspectorModels)
                {
                    inspectors.Add(new WSSystemInspector
                                       {
                                           Id = model.Identifier,
                                           FirstName = model.GivenName,
                                           LastName = model.FamilyName
                                       });
                }

                return inspectors;
            }
            else
            {
                return null;
            }
        }
    }
}
