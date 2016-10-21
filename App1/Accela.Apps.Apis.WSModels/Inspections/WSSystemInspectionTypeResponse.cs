using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "getInspectionTypesResponse")]
    public class WSSystemInspectionTypeResponse : WSPagedResponse
    {
        [DataMember(Name = "inspectionTypes")]
        public List<WSSystemInspectionType> InspctionTypes { get; set; }

        /// <summary>
        /// convert ws entity from biz entity.
        /// </summary>
        /// <param name="systemInspectionTypeResponse"></param>
        /// <returns></returns>
        public  static WSSystemInspectionTypeResponse FromEntityModel(SystemInspectionTypeResponse systemInspectionTypeResponse)
        {
            return new WSSystemInspectionTypeResponse()
                       {
                           InspctionTypes = GetInspectionTypeFromBiz(systemInspectionTypeResponse.Types),
                           PageInfo = WSPagination.FromEntityModel(systemInspectionTypeResponse.PageInfo)

                       };
        }


        private static List<WSSystemInspectionType> GetInspectionTypeFromBiz(List<SystemInspectionTypeModel> models)
        {
            if (models == null)
            {
                return null;
            }

            List<WSSystemInspectionType> types = new List<WSSystemInspectionType>();
            foreach (var model in models)
            {
                types.Add(new WSSystemInspectionType()
                              {
                                  Id = model.Identifier,
                                  Display = model.Display,
                                  CheckListGroup =
                                      WSSystemInspectionChecklistGroup.FromEntityModel(model.ChecklistGroup),
                                  Status = WSSystemInspectionStatus.FromEntityModel(model.Status)
                              });
            }

            return types;
        }
    }
}
