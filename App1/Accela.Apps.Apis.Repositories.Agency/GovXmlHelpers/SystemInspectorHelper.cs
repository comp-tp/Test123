using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class SystemInspectorHelper : GovXmlHelperBase
    {
        /*
        /// <summary>
        /// get all active (system) inspectors. 
        /// </summary>
        /// <returns></returns>
        public static IList<SystemInspectorModel> GetAllActiveInspectors()
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getInspectors = new GetInspectors();
            govXmlIn.getInspectors.system = CommonHelper.GetSystem();

            GovXML govXmlOut = CommonHelper.Post(govXmlIn, govXmlIn.getInspectors.system,
                                                 xmlOut =>
                                                 xmlOut.getInspectorsResponse == null
                                                     ? null
                                                     : xmlOut.getInspectorsResponse.system);


            IList<SystemInspectorModel>  systemInspectorModels = new List<SystemInspectorModel>();

            if (govXmlOut.getInspectorsResponse != null)
            {
                 
                if (govXmlOut.getInspectorsResponse.inspectors != null &&
                    govXmlOut.getInspectorsResponse.inspectors.inspector != null)
                {
                    
                    foreach (var inspector in govXmlOut.getInspectorsResponse.inspectors.inspector)
                    {
                        if (inspector.Active)
                        {
                            systemInspectorModels.Add(new SystemInspectorModel()
                                                        {
                                                            Identifier = inspector.keys.ToStringKeys(),
                                                            GivenName =
                                                                inspector.person != null
                                                                    ? inspector.person.givenName
                                                                    : string.Empty,
                                                            FamilyName =
                                                                inspector.person != null
                                                                    ? inspector.person.familyName
                                                                    : string.Empty,
                                                            Active = inspector.Active

                                                        });
                        }
                    }
                }

                 
            }

            return systemInspectorModels;
        }
        //*/

        public static IList<SystemInspectorModel> ToClientInspectors(GetInspectorsResponse getInspectorsResponse)
        {
            IList<SystemInspectorModel> systemInspectorModels = new List<SystemInspectorModel>();

            if (getInspectorsResponse != null)
            {

                if (getInspectorsResponse.inspectors != null &&
                    getInspectorsResponse.inspectors.inspector != null)
                {

                    foreach (var inspector in getInspectorsResponse.inspectors.inspector)
                    {
                        if (inspector.Active)
                        {
                            systemInspectorModels.Add(new SystemInspectorModel()
                            {
                                Identifier = inspector.keys.ToStringKeys(),
                                GivenName =
                                    inspector.person != null
                                        ? inspector.person.givenName
                                        : string.Empty,
                                FamilyName =
                                    inspector.person != null
                                        ? inspector.person.familyName
                                        : string.Empty,
                                Active = inspector.Active

                            });
                        }
                    }
                }


            }

            return systemInspectorModels;
        }
    }
}
