using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.PartModels;

namespace Accela.Apps.Apis.WSModels.Parts
{
    [DataContract(Name = "partType")]
    public class WSPartType : WSIdentifierBase
    {
        /// <summary>
        /// Convert PartTypeModel to WSPartType.
        /// </summary>
        /// <param name="partTypeModel">partTypeModel.</param>
        /// <returns>WSPartType.</returns>
        public static WSPartType FromEntityModel(PartTypeModel partTypeModel)
        {
            if (partTypeModel == null)
            {
                return null;
            }

            return new WSPartType()
            {
                Id = partTypeModel.Identifier,
                Display = partTypeModel.Display
            };
        }

        public static PartTypeModel ToEntityModel(WSPartType wsPartType)
        {
            if (wsPartType == null)
            {
                return null;
            }

            return new PartTypeModel
            {
                Identifier = wsPartType.Id,
                Display = wsPartType.Display
            };
        }
    }
}
