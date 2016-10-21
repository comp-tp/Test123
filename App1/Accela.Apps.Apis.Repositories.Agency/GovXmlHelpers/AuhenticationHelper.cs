using Accela.Apps.Apis.Models.DTOs.Responses.CommonResponses;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class AuhenticationHelper : GovXmlHelperBase 
    {
        /// <summary>
        /// Logs into Automaiton Biz Server. If successful, returns Biz server System State Token.
        /// </summary>
        /// <param name="agency">Agency name</param>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <param name="language">Language and Region code</param>
        /// <returns>loginResponse model</returns>
        public static BizLoginResponse Login(string agency, string userName, string password, string language,string environment)
        {
            BizLoginResponse result = null;

            GovXML govXML = new GovXML();
            govXML.authenticateUser = new AuthenticateUser();
            govXML.authenticateUser.system = CommonHelper.GetSystem(agency, userName, language,environment);
            govXML.authenticateUser.username = userName;
            govXML.authenticateUser.password = password;

            GovXML govXMLRet = CommonHelper.Post(govXML, agency, environment);
            Sys govSys = null;

            if (govXMLRet.authenticateUserResponse != null)
            {
                govSys = govXMLRet.authenticateUserResponse.system;
            }

            CommonHelper.ProcessGovXmlErrors(govSys, govXML.fSystemOut);

            if (govXMLRet != null && govXMLRet.authenticateUserResponse != null)
            {
                result = new BizLoginResponse();

                if (govXMLRet.authenticateUserResponse.system != null)
                {
                    result.ApplicationState = govXMLRet.authenticateUserResponse.system.applicationState;
                }

                if (govXMLRet.authenticateUserResponse.inspectorId != null && govXMLRet.authenticateUserResponse.inspectorId.keys != null)
                {
                    result.InspectorIdentifier = govXMLRet.authenticateUserResponse.inspectorId.keys.ToStringKeys();
                }
            }

            return result;
        }
    }
}
