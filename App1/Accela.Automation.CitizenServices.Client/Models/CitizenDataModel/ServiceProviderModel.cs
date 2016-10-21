/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ServiceProviderModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: AdditionInfo.cs 130107 2009-05-11 12:23:56Z ACHIEVO\ServiceProviderModel.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class ServiceProviderModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> accountDisableTimeframe { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string allowUserChangePassword { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string city { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contact_line1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contact_line2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string last_project_nbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string name { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string name2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string numberingSchemeFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parentServProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> passwordExpireTimeframe { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long servProvNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long sourceNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string specialHandle { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string zip { get; set; }
    }
    
}
