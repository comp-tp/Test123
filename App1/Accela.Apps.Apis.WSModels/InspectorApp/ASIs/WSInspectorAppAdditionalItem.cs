using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels;

namespace Accela.Apps.Apis.WSModels.ASIs.InspectorApp
{
    [DataContract(Name = "WSAdditionalItem")]
    public class WSInspectorAppAdditionalItem : WSInspectorAppASIColumn
    {
        [DataMember(Name = "valueId", EmitDefaultValue = false)]
        public string ValueId { get; set; }        

        /// <summary>
        /// Convert WSASIItem to WSAdditionalItem.
        /// </summary>
        /// <param name="wsASIItem">AdditionalItemModel.</param>
        /// <returns>WSAdditionalItem.</returns>
        public static WSInspectorAppAdditionalItem FromWSASIItem(WSInspectorAppASIItem wsASIItem)
        {
            if (wsASIItem != null)
            {
                var wsAdditionalItem = new WSInspectorAppAdditionalItem()
                {
                    DefaultValue = wsASIItem.DefaultValue,
                    Display = wsASIItem.Display,
                    Id = wsASIItem.Id,
                    InputRequired = wsASIItem.InputRequired,
                    MaxValue = wsASIItem.MaxValue,
                    MinValue = wsASIItem.MinValue,
                    Name = wsASIItem.Name,
                    Readonly = wsASIItem.Readonly,
                    Security = wsASIItem.Security,
                    Type = wsASIItem.Type,
                    UnitOfMeasurement = wsASIItem.UnitOfMeasurement,
                    ValueId = wsASIItem.ValueId 
                };

                if (wsASIItem.Enumerations != null)
                {
                    wsAdditionalItem.Enumerations = new List<WSInspectorAppEnumeration>();
                    wsASIItem.Enumerations.ForEach(item => wsAdditionalItem.Enumerations.Add(new WSInspectorAppEnumeration
                    {
                        Id = item.Id,
                        Display = item.Display
                    }));
                }

                return wsAdditionalItem;
            }

            return null;
        }

        /// <summary>
        /// Convert WSASIItem list to WSAdditionalItem list.
        /// </summary>
        /// <param name="wsASIItems">AdditionalItemModel list.</param>
        /// <returns>WSAdditionalItem list.</returns>
        public static List<WSInspectorAppAdditionalItem> FromWSASIItems(List<WSInspectorAppASIItem> wsASIItems)
        {
            var wsAdditionalItems = new List<WSInspectorAppAdditionalItem>();
            if (wsASIItems != null)
            {
                if (wsASIItems != null && wsASIItems.Count > 0)
                {                    
                    wsASIItems.ForEach(i => wsAdditionalItems.Add(FromWSASIItem(i)));
                    return wsAdditionalItems;
                }
            }

            return wsAdditionalItems;
        }
    }
}
