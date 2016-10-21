/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: xRefEducationProviderModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 *  xRefEducationProviderModel4WS model..
 * 
 *  Notes:
 * $Id: xRefEducationProviderModel4WS.cs 142354 2009-08-07 02:19:45Z ACHIEVO\jackie.yu $.
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
    public partial class XRefEducationProviderModel4WS : ProviderPKModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ProviderModel4WS providerModel
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefEducationModel4WS refEducationModel
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long refEducationNbr
        { 
            get;
            set;
        }
    }
}
