using System;
using Accela.ACA.WSProxy;

namespace Accela.Apps.Apis.Repositories.CitizenHelpers
{
    public class CitizenRecordWorkDescriptionHelper
    {
        internal static CapWorkDesModel4WS ToCitizenRecordWorkDescription(string originalDescription)
        {
            CapWorkDesModel4WS result = new CapWorkDesModel4WS();

            if (!String.IsNullOrWhiteSpace(originalDescription))
            {
                result.description = originalDescription;
            }

            return result;
        }
    }
}
