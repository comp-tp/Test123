using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    /// <summary>
    /// it is for additional
    /// </summary>
    [DataContract(Name = "ASIDescribe")]
    public class WSAdditional
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
        public List<WSAdditionalSubGroup> SubGroups { get; set; }

        [DataMember(Name = "security", EmitDefaultValue = false)]
        public string Security { get; set; }

        public static List<WSAdditional> FromWSASIs(List<WSASI> wsASIs)
        {
            List<WSAdditional> wsAdditionals = new List<WSAdditional>();
            if (wsASIs != null && wsASIs.Count > 0)
            {
                wsASIs.ForEach(model => wsAdditionals.Add(FromWSASI(model)));
            }

            return wsAdditionals;
        }

        /// <summary>
        /// Convert WSASI to WSAdditional
        /// </summary>
        /// <param name="additionalGroupModel"></param>
        /// <returns></returns>  entityResponse.AssetCAModels
        public static WSAdditional FromWSASI(WSASI wsASIs)
        {
            if (wsASIs != null)
            {
                return new WSAdditional()
                {
                    Id = wsASIs.Id,
                    Display = wsASIs.Display,
                    Description = wsASIs.Description,
                    Security = wsASIs.Security,
                    SubGroups = WSAdditionalSubGroup.FromWSASISubGroups(wsASIs.SubGroups)
                };
            }
            return null;
        }

    }
}
