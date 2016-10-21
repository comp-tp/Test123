using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    /// <summary>
    /// Additional table model.
    /// contains ASI/ASIT info.
    /// </summary>
    [DataContract(Name = "ASITDetail")]
    public class WSASITDetail
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "id", EmitDefaultValue = false, Order = 1)]
        public string Id { get; set; }

        [DataMember(Name = "subId", EmitDefaultValue = false, Order = 4)]
        public string SubId { get; set; }        

        /// <summary>
        /// Gets or sets the data rows.
        /// for ASI, this array's length = 1.
        /// for ASIT, this array's length >= 1
        /// </summary>
        /// <value>
        /// The data rows.
        /// </value>
        [DataMember(Name = "rows", EmitDefaultValue = false, Order = 10)]
        public List<WSASIRow> Rows
        {
            get;
            set;
        }

        public static WSASITDetail FromWSASIT(WSASIT wsasit)
        {
            WSASITDetail wsASITDetail = null;
            if (wsasit != null)
            {
                wsASITDetail = new WSASITDetail();
                wsASITDetail.Id = wsasit.Id;
                wsASITDetail.SubId = wsasit.SubId;
                wsASITDetail.Rows = wsasit.Rows;

            }
            return wsASITDetail;
        }

        public static List<WSASITDetail> FromWSASITs(List<WSASIT> wsasits)
        {
            var wsasitDetail = new List<WSASITDetail>();
            if (wsasits != null && wsasits.Count > 0)
            {
                foreach (var wsasit in wsasits)
                {
                    wsasitDetail.Add(FromWSASIT(wsasit));
                }
            }
            return wsasitDetail;
        }        

    }
}
