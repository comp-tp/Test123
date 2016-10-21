using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    /// <summary>
    /// it is for additional
    /// </summary>
    [DataContract(Name = "ASI")]
    public class WSASI
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
        /// description
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description
        {
            get;
            set;
        }

        [DataMember(Name = "subGroups", EmitDefaultValue = false)]
        public List<WSASISubGroup> SubGroups { get; set; }

        [DataMember(Name = "security", EmitDefaultValue = false)]
        public string Security { get; set; }

        /// <summary>
        /// Convert WSASI to AdditionalGroupModel.
        /// </summary>
        /// <param name="wsASI">WSASI.</param>
        /// <returns>AdditionalGroupModel.</returns>
        public static AdditionalGroupModel ToEntityModel(WSASI wsASI)
        {
            if (wsASI != null)
            {
                return new AdditionalGroupModel()
                {
                    Identifier = wsASI.Id,
                    Display = wsASI.Display,
                    Description = wsASI.Description,
                    Security = wsASI.Security,
                    SubGroups = WSASISubGroup.ToEntityModels(wsASI.SubGroups)
                };
            }
            return null;
        }

        public static List<AdditionalGroupModel> ToEntityModels(List<WSASI> wsASIs)
        {
            List<AdditionalGroupModel> additionalGroupModels = new List<AdditionalGroupModel>();
            if (wsASIs != null && wsASIs.Count > 0)
            {
                wsASIs.ForEach(asi => additionalGroupModels.Add(ToEntityModel(asi)));
            }
            return additionalGroupModels;
        }

    }
}
