using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Models.DTOs.Responses.StandardChoicesResponses;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Models.DomainModels.StandardChoicesModels;

namespace Accela.Apps.Apis.Repositories.Agency.GovXmlHelpers
{
    internal class StandardChoicesHelper
    {
        public static StandardChoicesResponse GetStandardChoices(GetStandardChoicesResponse response)
        {
            var result = new StandardChoicesResponse();

            if (response.system != null)
            {                
                result.Events = CommonHelper.GetClientEventMessage(response.system.eventMessages);
            }

            result.StandardChoicesModels = new List<StandardChoicesModel>();
            if (response.standardChoices != null &&
                response.standardChoices.AMOEnumeration != null &&
                response.standardChoices.AMOEnumeration.Length > 0)
            {
                foreach (var AssetUnitTypes in response.standardChoices.AMOEnumeration)
                {
                    var assetUnitTypesModel = new StandardChoicesModel();
                    assetUnitTypesModel.Id = KeysHelper.ToStringKeys(AssetUnitTypes.keys);
                    assetUnitTypesModel.IdentifierDisplay = AssetUnitTypes.identifierDisplay;
                    assetUnitTypesModel.Description = AssetUnitTypes.description;
                    assetUnitTypesModel.Type = AssetUnitTypes.enumerationType;
                    result.StandardChoicesModels.Add(assetUnitTypesModel);
                }
            }
            return result;
        }
    }
}
