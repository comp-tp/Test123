/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: EDMSEntityIdModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: EDMSEntityIdModel4WS.cs 130439 2009-05-13 10:02:20Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class EDMSEntityIdModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string altId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspectionId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parcelId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string workflowId { get; set; }
    }
}
