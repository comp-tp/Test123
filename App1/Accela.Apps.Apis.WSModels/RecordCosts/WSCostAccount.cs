using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CostModels;

namespace Accela.Apps.Apis.WSModels.RecordCosts
{
    [DataContract(Name = "costAccount")]
    public class WSCostAccount : WSIdentifierBase
    {
        /// <summary>
        /// Convert CostAccountIdModel to WSCostAccount.
        /// </summary>
        /// <param name="costAccountIdModel">CostAccountIdModel.</param>
        /// <returns>WSCostAccount.</returns>
        public static WSCostAccount FromEntityModel(CostAccountModel costAccountIdModel)
        {
            if (costAccountIdModel != null)
            {
                return new WSCostAccount() 
                {
                    Id = costAccountIdModel.Identifier,
                    Display = costAccountIdModel.Display
                };
            }

            return null;
        }
    }
}
