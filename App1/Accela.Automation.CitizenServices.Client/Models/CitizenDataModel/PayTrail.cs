/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PayTrail.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PayTrail.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class PayTrail
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string authCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string payAmount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool processFee { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string referenceId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string returnCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string returnMessage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string transactionId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string type { get; set; }
    }
   
}
