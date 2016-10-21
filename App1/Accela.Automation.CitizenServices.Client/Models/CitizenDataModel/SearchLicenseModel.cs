/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: SearchLicenseModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: SearchLicenseModel.cs 181867 2010-09-30 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using System;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class SearchLicenseModel : LicenseModel
    {
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] certications { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] ethnicities { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] locations { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string maximumContractAmount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string maximumContractAmountOperator { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] nigpCodes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string nigpKeyword { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string nigpType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string peopleType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recordStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] searchZips { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> userSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<DateTime> certificationDateFrom { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<DateTime> certificationDateTo { get; set; }
    }
}
