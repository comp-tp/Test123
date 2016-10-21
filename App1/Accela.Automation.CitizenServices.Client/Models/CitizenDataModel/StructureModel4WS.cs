/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: StructureModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: StructureModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class StructureModel4WS
    {
        /// <remarks/>
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
        public string structureName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long structureNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string structureStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string structureStatusDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string structureStatusDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string structureStatusEndDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string structureType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public StructureTypeModel4WS structureTypeModel { get; set; }
    }
    
}
