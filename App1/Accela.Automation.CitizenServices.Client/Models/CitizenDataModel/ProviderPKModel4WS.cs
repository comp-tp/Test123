/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ProviderPKModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 *  ProviderPKModel4WS model..
 * 
 *  Notes:
 * $Id: ProviderPKModel4WS.cs 142354 2009-08-07 02:19:45Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ProviderModel4WS))]
    
    [DataContract]
    
    
    
    public partial class ProviderPKModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long providerNbr
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode
        {
            get;
            set;
        }
    }
}

