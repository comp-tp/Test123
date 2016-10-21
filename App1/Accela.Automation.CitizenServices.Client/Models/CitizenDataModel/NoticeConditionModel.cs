/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: NoticeConditionModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: NoticeConditionModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class NoticeConditionModel : ConditionModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long actionNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long addressNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long assetNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string conditionOfApproval { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string conditionSource { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long contactSeqNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> displayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string objectConditionName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string objectConditionValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long ownerNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parcelNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long referenceConditionNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resConditionStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long structureNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string UID { get; set; }
    }
}
