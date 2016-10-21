#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: B1ExpirationModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: B1ExpirationModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class B1ExpirationModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime auditDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool auditDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capIDModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime expDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool expDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long expInterval { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expUnit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long graceInterval { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string graceUnit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string payPeriodGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string penaltyCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string penaltyFunction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long penaltyInterval { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long penaltyNum { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long penaltyPeriod { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string penaltyUnit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string renewalCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string renewalFunction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf4 { get; set; }
    }
}
