/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: DepartmentModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: DepartmentModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class DepartmentModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public PublicUserModel4WS acaOrgOwner { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string agencyCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string bureauCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string city { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string deptKey { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string deptName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string deptPassword { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string divisionCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string email { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fullDeptName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mainFax { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mainTel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string officeCode { get; set; }

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
        public string sectionCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string street { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subGroupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subGroupCodeDesc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string zip { get; set; }
    }
}
