using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    [DataContract(Name = "ASIItem")]
    public class WSASIItem : WSASIColumn
    {
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        [DataMember(Name = "valueId", EmitDefaultValue = false)]
        public string ValueId { get; set; }

        /// <summary>
        /// Convert WSASIItem to AdditionalItemModel.
        /// </summary>
        /// <param name="wsASIItem">WSASIItem.</param>
        /// <returns>AdditionalItemModel.</returns>
        public static AdditionalItemModel ToEntityModel(WSASIItem wsASIItem)
        {
            if (wsASIItem != null)
            {
                var result = new AdditionalItemModel()
                {
                    Action = WSEntityState.ConvertEntityStateToAction(wsASIItem.EntityState),
                    DefaultValue = wsASIItem.DefaultValue,
                    Display = wsASIItem.Display,
                    Identifier = wsASIItem.Id,
                    InputRequired = wsASIItem.InputRequired,
                    MaxValue = wsASIItem.MaxValue,
                    MinValue = wsASIItem.MinValue,
                    Name = wsASIItem.Name,
                    Readonly = wsASIItem.Readonly,
                    Security = wsASIItem.Security,
                    Type = wsASIItem.Type,
                    UnitOfMeasurement = wsASIItem.UnitOfMeasurement,
                    Value = wsASIItem.Value
                };

                if (wsASIItem.Enumerations != null)
                {
                    result.Enumerations = new List<EnumerationModel>();

                    wsASIItem.Enumerations.ForEach(item => result.Enumerations.Add(new EnumerationModel
                                                                                    {
                                                                                        Identifier = item.Id,
                                                                                        Display = item.Display
                                                                                    }));
                }

                return result;
            }
            return null;
        }

        /// <summary>
        /// Convert AdditionalItemModel list to WSASIItem list.
        /// </summary>
        /// <param name="wsASIItems">WSASIItem list.</param>
        /// <returns>AdditionalItemModel list.</returns>
        public static List<AdditionalItemModel> ToEntityModels(List<WSASIItem> wsASIItems)
        {
            if (wsASIItems != null && wsASIItems.Count > 0)
            {
                var additionalItemModels = new List<AdditionalItemModel>();
                foreach (var wsASIItem in wsASIItems)
                {
                    additionalItemModels.Add(ToEntityModel(wsASIItem));
                };
                return additionalItemModels;
            }
            return null;
        }
    }
}
