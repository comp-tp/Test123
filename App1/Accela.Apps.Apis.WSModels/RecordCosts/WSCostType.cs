using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CostModels;

namespace Accela.Apps.Apis.WSModels.RecordCosts
{
    [DataContract(Name = "type")]
    public class WSCostType
    {
        /// <summary>
        /// Gets or sets the type id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the type display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        ///// <summary>
        ///// Gets or sets the type StandardCommentsGroupIds.
        ///// </summary>
        //[DataMember(Name = "standardCommentsGroupIds", EmitDefaultValue = false)]
        //public WSStandardCommentsGroupIds StandardCommentsGroups { get; set; }

        /// <summary>
        /// Convert CostTypeModel to WSCostType.
        /// </summary>
        /// <param name="costTypeModel">CostTypeModel.</param>
        /// <returns>WSCostType.</returns>
        public static WSCostType FromEntiyModel(CostTypeModel costTypeModel)
        {
            if (costTypeModel != null)
            {
                return new WSCostType()
                {
                    Id = costTypeModel.Id,
                    Display = costTypeModel.Display,
                    //StandardCommentsGroups = WSStandardCommentsGroupIds.FromEnitiyModel(costTypeModel.StandardCommentsGroups)
                };
            }

            return null;
        }
    }
}
