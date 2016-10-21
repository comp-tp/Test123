/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: GFilterLevelModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GFilterLevelModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [DataContract]
    
    
    
    public partial class GFilterLevelModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string filterLevelId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string filterLevelType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string levelName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }
    }
}
