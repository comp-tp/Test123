#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RProviderLocationModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ExaminationModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://model.webservice.accela.com")]
    public partial class RProviderLocationModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string city { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string drivingDirections { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string handicapAccessible { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isHandicapAccessible { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RProviderLocationPKModel locationPKModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> maxSeats { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phoneCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RProviderProctorModel proctorModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> proctorNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ProviderModel providerModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> providerNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string zip { get; set; }
    }
}
