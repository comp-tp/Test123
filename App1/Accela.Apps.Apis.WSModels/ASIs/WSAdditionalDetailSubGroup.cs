using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    /// <summary>
    /// it is for additionalDetail
    /// </summary>
    [DataContract(Name = "AdditionalDetailSubGroup")]
    public class WSAdditionalDetailSubGroup
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
        public List<WSAdditionalDetailItem> Items { get; set; }

        /// <summary>
        /// Convert WSASISubGroup to WSAdditionalDetailSubGroup.
        /// </summary>
        /// <param name="additionalSubGroupModel"></param>
        /// <returns>WSAdditionalDetailSubGroup</returns>
        public static WSAdditionalDetailSubGroup FromWSASISubGroup(WSASISubGroup wsASISubGroup)
        {
            if (wsASISubGroup != null)
            {
                return new WSAdditionalDetailSubGroup()
                {
                    Id = wsASISubGroup.Id,
                    Items = WSAdditionalDetailItem.FromWSASIItems(wsASISubGroup.Items)
                };
            }
            return null;
        }

        /// <summary>
        /// Convert WSASISubGroup list to WSAdditionalDetailSubGroup list.
        /// </summary>
        /// <param name="additionalSubGroupModels"></param>
        /// <returns></returns>
        public static List<WSAdditionalDetailSubGroup> FromWSASISubGroups(List<WSASISubGroup> wsASISubGroups)
        {
            var wsAdditionalDetailSubGroups = new List<WSAdditionalDetailSubGroup>();
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
