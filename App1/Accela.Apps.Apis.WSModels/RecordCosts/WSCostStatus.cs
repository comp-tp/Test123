using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CostModels;

namespace Accela.Apps.Apis.WSModels.RecordCosts
{
    [DataContract(Name = "status")]
    public class WSCostStatus
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Convert CostStatusModel to WSCostStatus.
        /// </summary>
        /// <param name="costStatusModel">CostStatusModel.</param>
        /// <returns>WSCostStatus.</returns>
        public static WSCostStatus FromEntityModel(CostStatusModel costStatusModel)
        {
            if (costStatusModel != null)
            {
                return new WSCostStatus()
                {
                    Id = costStatusModel.Id,
                    Display = costStatusModel.Display                    
                };
            }

            return null;
        }
    }
}
