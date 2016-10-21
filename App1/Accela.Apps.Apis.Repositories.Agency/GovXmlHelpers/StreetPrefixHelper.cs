using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.ReferenceRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Automation.GovXmlClient.Model;
using Accela.GIS.GovXml.Model;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    public class StreetPrefixHelper
    {
        /*
        /// <summary>
        /// get streePrefixes frmo request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal static StreetPrefixesResponse GetClientStreetPrefixes(StreetPrefixesRequest request)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.GetStreetDirections = new GetStreetDirections();
            govXmlIn.GetStreetDirections.system = CommonHelper.GetSystem(request);

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.GetStreetDirections.system,
                (o) => o.GetStreetDirectionsResponse == null ? null : o.GetStreetDirectionsResponse.system);

            var results = StreetPrefixHelper.GetClientStreetPrefixes(response.GetStreetDirectionsResponse);

            return results;
        }
        //*/

        public static StreetPrefixesResponse GetClientStreetPrefixes(GetStreetDirectionsResponse xmlObj)
        {
            StreetPrefixesResponse results = new StreetPrefixesResponse();
            if (xmlObj.StreetDirections != null
                && xmlObj.StreetDirections.StreetDirectionsEnumerations != null
                && xmlObj.StreetDirections.StreetDirectionsEnumerations.Enumerations != null
                && xmlObj.StreetDirections.StreetDirectionsEnumerations.Enumerations.Length > 0)
            {
                results.StreetPrefixes = new List<StreetPrefixModel>();
                foreach (GISEnumeration gis in xmlObj.StreetDirections.StreetDirectionsEnumerations.Enumerations)
                {
                    StreetPrefixModel clientPrefix = new StreetPrefixModel();
                    clientPrefix.Identifier = gis.Keys.ToStringKeys();
                    clientPrefix.Display = gis.IdentifierDisplay;
                    results.StreetPrefixes.Add(clientPrefix);
                }
            }

            return results;
        }
    }
}
