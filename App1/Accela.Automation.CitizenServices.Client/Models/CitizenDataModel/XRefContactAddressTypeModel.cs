/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XRefContactAddressTypeModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: XRefContactAddressTypeModel.cs 218456 2012-05-02 05:10:45Z ACHIEVO\alan.hu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class XRefContactAddressTypeModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string required { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XRefContactAddressTypePKModel XRefContactAddressTypePKModel { get; set; }
    }
}
