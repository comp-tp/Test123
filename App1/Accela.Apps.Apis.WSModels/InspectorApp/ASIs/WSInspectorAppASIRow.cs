using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs.InspectorApp
{
    /// <summary>
    /// Additional row model
    /// </summary>
    [DataContract(Name = "additionalRow")]
    public class WSInspectorAppASIRow : WSEntityState
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

        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        [DataMember(Name = "values", EmitDefaultValue = false)]
        public List<WSInspectorAppASIValueModel> Values
        {
            get;
            set;
        }

        /// <summary>
        /// Convert WSASIRow to AdditionalRowModel.
        /// </summary>
        /// <param name="wsASIRow">WSASIRow.</param>
        /// <returns>AdditionalRowModel.</returns>
        public static AdditionalRowModel ToEnityModel(WSInspectorAppASIRow wsASIRow)
        {
            if (wsASIRow != null)
            {
                return new AdditionalRowModel()
                {
                    Action = WSEntityState.ConvertEntityStateToAction(wsASIRow.EntityState),
                    Display = wsASIRow.Display,
                    Identifier = wsASIRow.Id,
                    Values = WSInspectorAppASIValueModel.ToEntityModels(wsASIRow.Values)
                };
            }
            return null;
        }

        /// <summary>
        /// Convert WSASIRow list to AdditionalRowModel list.
        /// </summary>
        /// <param name="wsASIRows">WSASIRow list.</param>
        /// <returns>AdditionalRowModel list.</returns>
        public static List<AdditionalRowModel> ToEnityModels(List<WSInspectorAppASIRow> wsASIRows)
        {
            if (wsASIRows != null && wsASIRows.Count > 0)
            {
                var additionalRowModels = new List<AdditionalRowModel>();
                foreach (var wsASIRow in wsASIRows)
                {
                    additionalRowModels.Add(ToEnityModel(wsASIRow));
                };
                return additionalRowModels;
            }
            return null;
        }
    }
}
