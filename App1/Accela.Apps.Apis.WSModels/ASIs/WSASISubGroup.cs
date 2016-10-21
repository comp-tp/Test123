using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    /// <summary>
    /// it is for additional
    /// </summary>
    [DataContract(Name = "ASISubGroup")]
    public class WSASISubGroup : WSEntityState
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
        public List<WSASIItem> Items { get; set; }

        [DataMember(Name = "security", EmitDefaultValue = false)]
        public string Security { get; set; }


        [DataMember(Name = "drillDownSeries", EmitDefaultValue = false)]
        public List<WSDrillDownSeries> DrillDownSeries { get; set; }

        [DataMember(Name = "alias", EmitDefaultValue = false)]
        public string Alias { get; set; }

        /// <summary>
        /// Convert WSASISubGroup to AdditionalSubGroupModel.
        /// </summary>
        /// <param name="wsASISubGroup">WSASISubGroup.</param>
        /// <returns>AdditionalSubGroupModel.</returns>
        public static AdditionalSubGroupModel ToEntityModel(WSASISubGroup wsASISubGroup)
        {
            if (wsASISubGroup != null)
            {
                return new AdditionalSubGroupModel()
                {
                    Action = WSEntityState.ConvertEntityStateToAction(wsASISubGroup.EntityState),
                    Display = wsASISubGroup.Display,
                    Identifier = wsASISubGroup.Id,
                    Security = wsASISubGroup.Security,
                    Items = WSASIItem.ToEntityModels(wsASISubGroup.Items),
                    Alias = wsASISubGroup.Alias
                };
            }
            return null;
        }

        /// <summary>
        /// Convert WSASISubGroup list to AdditionalSubGroupModel list.
        /// </summary>
        /// <param name="wsASISubGroups">WSASISubGroup list.</param>
        /// <returns>AdditionalSubGroupModel list.</returns>
        public static List<AdditionalSubGroupModel> ToEntityModels(List<WSASISubGroup> wsASISubGroups)
        {
            if (wsASISubGroups != null && wsASISubGroups.Count > 0)
            {
                var additionalSubGroupModels = new List<AdditionalSubGroupModel>();
                foreach (var wsASISubGroup in wsASISubGroups)
                {
                    additionalSubGroupModels.Add(ToEntityModel(wsASISubGroup));
                };
                return additionalSubGroupModels;

            }
            return null;
        }
    }
}
