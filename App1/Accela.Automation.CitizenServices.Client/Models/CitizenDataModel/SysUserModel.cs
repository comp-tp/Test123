#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: SysUserModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: SysUserModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class SysUserModel : PersonModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string agencyCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string allowUserChangePassword { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string bureauCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string cashierID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> dailyInspUnits { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string deptOfUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<bool> discipline { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispDeptOfUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool displayInitial { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string distinguishedName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<bool> district { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string divisionCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string email { get; set; }

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
        public string isInspector { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string officeCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phoneNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resFullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resInitial { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sectionCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> workload { get; set; }
    }
}
