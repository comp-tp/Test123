using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.Common
{
    [DataContract(Name = "getWorkOrderTemplateResponse")]
    public class WSSystemWorkOrderTemplateResponse : WSPagedResponse
    {
        [DataMember(Name = "templates", EmitDefaultValue = false)]
        public List<WSSystemWorkOrderTemplate> Templates { get; set; }


        /// <summary>
        /// Converts from the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>ws owners response</returns>
        public static WSSystemWorkOrderTemplateResponse FromEntityModel(WorkOrderTemplateResponse entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSSystemWorkOrderTemplateResponse()
                             {
                                 PageInfo = WSPagination.FromEntityModel(entityModel.PageInfo),
                                 Templates = GetWorkOrderTemplatesFromBiz(entityModel.Templates)
                             };

            return result;
        }

        private static List<WSSystemWorkOrderTemplate> GetWorkOrderTemplatesFromBiz(List<WorkOrderTemplateModel> models)
        {
            if (models == null)
            {
                return null;
            }

            List<WSSystemWorkOrderTemplate> systemWorkOrderTemplates = new List<WSSystemWorkOrderTemplate>();

            foreach (var model in models)
            {
                WSSystemWorkOrderTemplate tempalte = WSSystemWorkOrderTemplate.FromEntityModel(model);
                if (tempalte != null)
                {
                    systemWorkOrderTemplates.Add(tempalte);
                }
            }

            return systemWorkOrderTemplates;
        }
    }
}
