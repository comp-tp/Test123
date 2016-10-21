using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class ModuleHelper : GovXmlHelperBase
    {
        /*
        /// <summary>
        /// get Modules from request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static ModulesResponse GetModules(ModulesRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getModules = new GetModules();
            govXmlIn.getModules.system = CommonHelper.GetSystem(request);

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.getModules.system,
                (o) => o.getModulesResponse == null ? null : o.getModulesResponse.system);

            ModulesResponse result = null;

            if (response != null && response.getModulesResponse != null && response.getModulesResponse.Modules != null && response.getModulesResponse.Modules.Module != null)
            {
                result = new ModulesResponse();
                result.Modules = response.getModulesResponse.Modules.Module.Select(m => new ModuleModel() { Key = m.Key, Value = m.Value }).ToList();
            }

            return result;
        }
        //*/
    }
}
