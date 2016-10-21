using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.PartModels;

namespace Accela.Apps.Apis.WSModels.Parts
{
    [DataContract(Name = "partDescription")]
    public class WSPartDescription : WSIdentifierBase
    {
        public static WSPartDescription FromEntityModel(PartDescriptionModel partDescriptionModel)
        {
            if (partDescriptionModel == null)
            {
                return null;
            }

            return new WSPartDescription()
            {
                Id = partDescriptionModel.Identifier,
                Display = partDescriptionModel.Display
            };
        }

        public static PartDescriptionModel ToEntityModel(WSPartDescription wsPartDescription)
        {
            if (wsPartDescription == null)
            {
                return null;
            }

            return new PartDescriptionModel
            {
                Identifier = wsPartDescription.Id,
                Display = wsPartDescription.Display
            };
        }
    }
}
