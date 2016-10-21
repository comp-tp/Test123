#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PasswordConditionModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C):2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PasswordConditionModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class PasswordConditionModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string password
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int passwordScore
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int pwdNumber
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime updateDate
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userID
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userName
        {
            get;
            set;
        }
    }
}
