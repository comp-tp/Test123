/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RecordTypeLicTypePermissionModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RecordTypeLicTypePermissionModel4WS.cs 130107 2009-08-27 12:23:56Z ACHIEVO\jackie.yu $.
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [DataContract]
    
    
    
    public partial class RecordTypeLicTypePermissionModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool bizLicExpEnabled4ACA
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool insExpEnabled4ACA
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool licExpEnabled4ACA 
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string licType
        {
            get;
            set;
        }
    }
}
