/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RefOwnerModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RefOwnerModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class RefOwnerModel : RefOwnerBaseModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public DuplicatedAPOKeyModel[] duplicatedAPOKeys { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> l1OwnerNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> ownerNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> ownerNumberLong { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateAttributeModel[] templates { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resState
        {
            get;
            set;
        }
    }
}
