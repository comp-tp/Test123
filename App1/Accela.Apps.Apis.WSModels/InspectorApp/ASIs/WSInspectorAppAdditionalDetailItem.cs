using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs.InspectorApp
{
    [DataContract(Name = "AdditionalDetailItem")]
    public class WSInspectorAppAdditionalDetailItem
    { 
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id{ get; set;}

        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        [DataMember(Name = "valueId", EmitDefaultValue = false)]
        public string ValueId { get; set; } 

        /// <summary>
        /// Convert WSASIItem to WSAdditionalDetailItem.
        /// </summary>
        /// <param name="wsASIItem">AdditionalItemModel.</param>
        /// <returns>WSAdditionalDetailItem.</returns>
        public static WSInspectorAppAdditionalDetailItem FromWSASIItem(WSInspectorAppASIItem wsASIItem)
        {
            if (wsASIItem != null)
            {
                var wsAdditionalDetailItem = new WSInspectorAppAdditionalDetailItem()
                {
                    Id = wsASIItem.Id,
                    ValueId = wsASIItem.ValueId,
                    Value = wsASIItem.Value
                };
                 
                return wsAdditionalDetailItem;
            }

            return null;
        }

        /// <summary>
        /// Convert WSASIItem list to WSAdditionalDetailItem list.
        /// </summary>
        /// <param name="wsASIItems">AdditionalItemModel list.</param>
        /// <returns>WSAdditionalDetailItem list.</returns>
        public static List<WSInspectorAppAdditionalDetailItem> FromWSASIItems(List<WSInspectorAppASIItem> wsASIItem)
        {
            var wsAdditionalDetailItems = new List<WSInspectorAppAdditionalDetailItem>();
            if (wsASIItem != null)
            {
                if (wsASIItem != null && wsASIItem.Count > 0)
                {                    
                    wsASIItem.ForEach(i => wsAdditionalDetailItems.Add(FromWSASIItem(i)));
                    return wsAdditionalDetailItems;
                }
            }
            return wsAdditionalDetailItems;
        }
    }
}
