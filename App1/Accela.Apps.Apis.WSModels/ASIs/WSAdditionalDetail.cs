using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    [DataContract(Name = "AdditionalDetail")]
    public class WSAdditionalDetail
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
        public List<WSAdditionalDetailSubGroup> SubGroups { get; set; }


        public static List<WSAdditionalDetail> FromWSASIs(List<WSASI> wsASIs)
        {
            List<WSAdditionalDetail> wsAdditionalDetails = new List<WSAdditionalDetail>();
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
        public static WSAdditionalDetail FromWSASI(WSASI wsASI)
        {
            if (wsASI != null)
            {
                return new WSAdditionalDetail()
                {
                    Id = wsASI.Id,
                    SubGroups = WSAdditionalDetailSubGroup.FromWSASISubGroups(wsASI.SubGroups)
                };
            }
            return null;
        }
    }
}
