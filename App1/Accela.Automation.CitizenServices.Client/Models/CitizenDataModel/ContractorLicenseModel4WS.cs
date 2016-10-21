/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ContractorLicenseModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ContractorLicenseModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{/// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [DataContract]
    
    
    
    public partial class ContractorLicenseModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string issuedByAgency { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public LicenseModel4WS license { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseImported { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licensePrimary { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseSeqNBR { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licenseType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulNam { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string status { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userSeqNBR { get; set; }
    }
}
