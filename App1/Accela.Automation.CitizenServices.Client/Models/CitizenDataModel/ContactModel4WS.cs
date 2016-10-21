/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ContactModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 *  ContactModel4WS model..
 * 
 *  Notes:
 * $Id: ContactModel4WS.cs 137738 2009-07-06 06:52:41Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class ContactModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactFirstName
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactLastName
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactMiddleName
        {
            get;
            set;
        }
    }
}
