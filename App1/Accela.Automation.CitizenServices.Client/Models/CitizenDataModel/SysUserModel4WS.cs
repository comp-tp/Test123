/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: SysUserModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: SysUserModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class SysUserModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string agencyCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string bureauCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string cashierID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dailyInspUnits { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string deptOfUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string distinguishedName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string divisionCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string email { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string firstName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gaUserID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string initial { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string integratedFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isDisplayInitial { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string lastName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string middleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string namesuffix { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string officeCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resFirstName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resFullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resInitial { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resLastName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resMiddleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sectionCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string title { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userStatus { get; set; }
    }
}
