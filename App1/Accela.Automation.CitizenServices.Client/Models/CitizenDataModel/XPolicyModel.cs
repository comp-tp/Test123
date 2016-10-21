/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XPolicyModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: XPolicyModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(XpolicyUserRolePrivilegeModel))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class XPolicyModel : LanguageModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string data1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string data2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string data3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string data4 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string data5 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispData2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispLevelData { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public EdmsUserModel edmsUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string FID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string level { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string levelData { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string menuLevel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string policyName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long policySeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resData2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string rightGranted { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string status { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string templateName { get; set; }
    }}
