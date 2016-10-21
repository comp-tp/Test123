using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CostModels;

namespace Accela.Apps.Apis.WSModels.RecordCosts
{
    [DataContract(Name = "costUnitOfMeasure")]
    public class WSCostUnitOfMeasure : WSIdentifierBase
    {
        /// <summary>
        /// Convert CostUnitOfMeasureIdModel to WSCostUnitOfMeasure.
        /// </summary>
        /// <param name="costUnitOfMeasureIdModel">CostUnitOfMeasureIdModel.</param>
        /// <returns>WSCostUnitOfMeasure.</returns>
        public static WSCostUnitOfMeasure FromEntityModel(CostUnitOfMeasureModel costUnitOfMeasureIdModel)
        {
            if (costUnitOfMeasureIdModel != null)
            {
                return new WSCostUnitOfMeasure()
                {
                    Id = costUnitOfMeasureIdModel.Identifier,
                    Display = costUnitOfMeasureIdModel.Display
                };
            }

            return null;
        }
    }
}
