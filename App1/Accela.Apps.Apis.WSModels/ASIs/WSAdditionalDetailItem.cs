using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    [DataContract(Name = "AdditionalDetailItem")]
    public class WSAdditionalDetailItem
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
        public static WSAdditionalDetailItem FromWSASIItem(WSASIItem wsASIItem)
        {
            if (wsASIItem != null)
            {
                var wsAdditionalDetailItem = new WSAdditionalDetailItem()
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
        public static List<WSAdditionalDetailItem> FromWSASIItems(List<WSASIItem> wsASIItem)
        {
            var wsAdditionalDetailItems = new List<WSAdditionalDetailItem>();
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
