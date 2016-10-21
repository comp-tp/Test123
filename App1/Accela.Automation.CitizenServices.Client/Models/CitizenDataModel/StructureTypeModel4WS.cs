/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: StructureTypeModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: StructureTypeModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class StructureTypeModel4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long sourceSeqNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string structureDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string structureName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string structureType { get; set; }
    }
}
