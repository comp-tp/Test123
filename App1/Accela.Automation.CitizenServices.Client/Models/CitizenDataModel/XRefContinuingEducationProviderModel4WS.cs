/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XRefContinuingEducationProviderModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 *  XRefContinuingEducationProviderModel4WS model..
 * 
 *  Notes:
 * $Id: XRefContinuingEducationProviderModel4WS.cs 137738 2009-07-06 06:52:41Z ACHIEVO\jackie.yu $.
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
    public partial class XRefContinuingEducationProviderModel4WS : ProviderPKModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AuditModel4WS auditModel
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ProviderModel4WS providerModel
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefContinuingEducationModel4WS refContEduModel
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long refContEduNbr
        {
            get;
            set;
        }
    }
}
