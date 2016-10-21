using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.PartModels;

namespace Accela.Apps.Apis.WSModels.Parts
{
    [DataContract(Name = "partInventory")]
    public class WSPartInventory : WSIdentifierBase
    {
        /// <summary>
        /// Convert PartInventoryModel to WSPartInventory.
        /// </summary>
        /// <param name="partInventoryModel">partInventoryIdModel.</param>
        /// <returns>WSPartInventory.</returns>
        public static WSPartInventory FromEntityModel(PartInventoryModel partInventoryModel)
        {
            if (partInventoryModel == null)
            {
                return null;
            }

            return new WSPartInventory()
            {
                Id = partInventoryModel.Identifier,
                Display = partInventoryModel.Display
            };
        }

        public static PartInventoryModel ToEntityModel(WSPartInventory wsPartInventory)
        {
            if (wsPartInventory == null)
            {
                return null;
            }

            return new PartInventoryModel
            {
                Identifier = wsPartInventory.Id,
                Display = wsPartInventory.Display
            };
        }
    }
}
