using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs.InspectorApp
{
    /// <summary>
    /// it is for additionalDetail
    /// </summary>
    [DataContract(Name = "AdditionalDetailSubGroup")]
    public class WSInspectorAppAdditionalDetailSubGroup
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
         
        [DataMember(Name = "items", EmitDefaultValue = false)]
        public List<WSInspectorAppAdditionalDetailItem> Items { get; set; }

        /// <summary>
        /// Convert WSASISubGroup to WSAdditionalDetailSubGroup.
        /// </summary>
        /// <param name="additionalSubGroupModel"></param>
        /// <returns>WSAdditionalDetailSubGroup</returns>
        public static WSInspectorAppAdditionalDetailSubGroup FromWSASISubGroup(WSInspectorAppASISubGroup wsASISubGroup)
        {
            if (wsASISubGroup != null)
            {
                return new WSInspectorAppAdditionalDetailSubGroup()
                {
                    Id = wsASISubGroup.Id,
                    Items = WSInspectorAppAdditionalDetailItem.FromWSASIItems(wsASISubGroup.Items)
                };
            }
            return null;
        }

        /// <summary>
        /// Convert WSASISubGroup list to WSAdditionalDetailSubGroup list.
        /// </summary>
        /// <param name="additionalSubGroupModels"></param>
        /// <returns></returns>
        public static List<WSInspectorAppAdditionalDetailSubGroup> FromWSASISubGroups(List<WSInspectorAppASISubGroup> wsASISubGroups)
        {
            var wsAdditionalDetailSubGroups = new List<WSInspectorAppAdditionalDetailSubGroup>();
            if (wsASISubGroups != null)
            {
                if (wsASISubGroups != null && wsASISubGroups.Count > 0)
                {                    
                    wsASISubGroups.ForEach(i => wsAdditionalDetailSubGroups.Add(FromWSASISubGroup(i)));
                    return wsAdditionalDetailSubGroups;
                }
            }
            return wsAdditionalDetailSubGroups;
        }
    }
}
