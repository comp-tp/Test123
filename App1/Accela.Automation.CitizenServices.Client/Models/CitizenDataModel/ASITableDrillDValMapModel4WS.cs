/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ASITableDrillDValMapModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2008-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ASITableDrillDValMapModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class ASITableDrillDValMapModel4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string childValueId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string childValueName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string drillDId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string drillDSeriesId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mappingId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parentValueId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulNam { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resChildValueName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }
    }
}
