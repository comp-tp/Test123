#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ContactModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ContactModel.cs 181867 2011-09-27 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class ContactModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactFirstName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactLastName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactMiddleName { get; set; }
    }
}
