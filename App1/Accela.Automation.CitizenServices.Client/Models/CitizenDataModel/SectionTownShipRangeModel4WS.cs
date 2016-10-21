/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: SectionTownShipRangeModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: SectionTownShipRangeModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class SectionTownShipRangeModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel4WS capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string plssType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string range { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string section { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string townShip { get; set; }
    }
}
