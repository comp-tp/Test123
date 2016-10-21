using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    /// <summary>
    /// Additional value model
    /// </summary>
    [DataContract(Name = "additionalValue")]
    public class ASIValueModel : WSEntityState
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value
        {
            get;
            set;
        }

        [DataMember(Name = "valueId", EmitDefaultValue = false)]
        public string ValueId
        {
            get;
            set;
        }

        /// <summary>
        /// Convert ASIValueModel to AdditionalValueModel.
        /// </summary>
        /// <param name="asiValueModel">ASIValueModel.</param>
        /// <returns>AdditionalValueModel.</returns>
        public static AdditionalValueModel ToEntityModel(ASIValueModel asiValueModel)
        {
            if (asiValueModel != null)
            {
                return new AdditionalValueModel()
                {
                    Action = WSEntityState.ConvertEntityStateToAction(asiValueModel.EntityState),
                    Identifier = asiValueModel.Id,
                    Value = asiValueModel.Value,
                    ValueId = asiValueModel.ValueId
                };
            }
            return null;
        }

        /// <summary>
        /// Convert ASIValueModel list to AdditionalValueModel list.
        /// </summary>
        /// <param name="asiValueModels">ASIValueModel list.</param>
        /// <returns>AdditionalValueModel list.</returns>
        public static List<AdditionalValueModel> ToEntityModels(List<ASIValueModel> asiValueModels)
        {
            if (asiValueModels != null && asiValueModels.Count > 0)
            {
                var additionalValueModels = new List<AdditionalValueModel>();
                foreach (var asiValueModel in asiValueModels)
                {
                    additionalValueModels.Add(ToEntityModel(asiValueModel));
                };
                return additionalValueModels;

            };
            return null;
        }
    }
}
