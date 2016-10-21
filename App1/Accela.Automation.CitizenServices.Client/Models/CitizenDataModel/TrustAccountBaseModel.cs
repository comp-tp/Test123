/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TrustAccountBaseModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TrustAccountBaseModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TrustAccountModel))]
    [DataContract]
    public partial class TrustAccountBaseModel : LanguageModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string acctID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string acctStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string description { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ledgerAccount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string overdraft { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }
    }
}
