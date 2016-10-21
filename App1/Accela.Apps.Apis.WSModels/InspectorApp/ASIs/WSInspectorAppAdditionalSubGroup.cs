using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs.InspectorApp
{
    /// <summary>
    /// it is for additional
    /// </summary>
    [DataContract(Name = "AdditionalSubGroup")]
    public class WSInspectorAppAdditionalSubGroup : WSEntityState
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
        /// Gets or sets the display.
        /// </summary>
        /// <value>
        /// The display.
        /// </value>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display
        {
            get;
            set;
        }

        [DataMember(Name = "items", EmitDefaultValue = false)]
        public List<WSInspectorAppAdditionalItem> Items { get; set; }

        [DataMember(Name = "security", EmitDefaultValue = false)]
        public string Security { get; set; }        

        /// <summary>
        /// Convert WSASISubGroup to WSAdditionalSubGroup.
        /// </summary>
        /// <param name="additionalSubGroupModel"></param>
        /// <returns>WSAdditionalSubGroup</returns>
        public static WSInspectorAppAdditionalSubGroup FromWSASISubGroup(WSInspectorAppASISubGroup wsASISubGroup)
        {
            if (wsASISubGroup != null)
            {
                return new WSInspectorAppAdditionalSubGroup()
                {
                    Id = wsASISubGroup.Id,
                    Display = wsASISubGroup.Display,
                    Security = wsASISubGroup.Security,
                    Items = WSInspectorAppAdditionalItem.FromWSASIItems(wsASISubGroup.Items)
                };
            }
            return new WSInspectorAppAdditionalSubGroup();
        }

        /// <summary>
        /// Convert WSASISubGroup list to WSAdditionalSubGroup list.
        /// </summary>
        /// <param name="additionalSubGroupModels"></param>
        /// <returns></returns>
        public static List<WSInspectorAppAdditionalSubGroup> FromWSASISubGroups(List<WSInspectorAppASISubGroup> wsASISubGroups)
        {
            var wsAdditionalSubGroups = new List<WSInspectorAppAdditionalSubGroup>();
            if (wsASISubGroups != null)
            {
                if (wsASISubGroups != null && wsASISubGroups.Count > 0)
                {                    
                    wsASISubGroups.ForEach(additionalSubGroupModel => wsAdditionalSubGroups.Add(FromWSASISubGroup(additionalSubGroupModel)));
                    return wsAdditionalSubGroups;
                }
            }
            return wsAdditionalSubGroups;
        }
    }
}
