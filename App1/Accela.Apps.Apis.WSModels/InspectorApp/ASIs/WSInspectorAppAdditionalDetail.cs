using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs.InspectorApp
{
    [DataContract(Name = "AdditionalDetail")]
    public class WSInspectorAppAdditionalDetail
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
            
        [DataMember(Name = "subGroups", EmitDefaultValue = false)]
        public List<WSInspectorAppAdditionalDetailSubGroup> SubGroups { get; set; }


        public static List<WSInspectorAppAdditionalDetail> FromWSASIs(List<WSInspectorAppASI> wsASIs)
        {
            List<WSInspectorAppAdditionalDetail> wsAdditionalDetails = new List<WSInspectorAppAdditionalDetail>();
            if (wsASIs != null && wsASIs.Count > 0)
            {
                wsASIs.ForEach(model => wsAdditionalDetails.Add(FromWSASI(model)));
            }

            return wsAdditionalDetails;
        }

        /// <summary>
        /// Convert WSASI to WSAdditionalDetail
        /// </summary>
        /// <param name="additionalGroupModel"></param>
        /// <returns></returns>  entityResponse.AssetCAModels
        public static WSInspectorAppAdditionalDetail FromWSASI(WSInspectorAppASI wsASI)
        {
            if (wsASI != null)
            {
                return new WSInspectorAppAdditionalDetail()
                {
                    Id = wsASI.Id,
                    SubGroups = WSInspectorAppAdditionalDetailSubGroup.FromWSASISubGroups(wsASI.SubGroups)
                };
            }
            return null;
        }
    }
}
