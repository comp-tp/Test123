/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: PostTransactionLogModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: PostTransactionLogModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class PostTransactionLogModel4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string errorString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ipAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string location { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string operation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string operationslogSeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string product { get; set; }

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
        public string request { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string response { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string transactionID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string userName { get; set; }
    }
}
