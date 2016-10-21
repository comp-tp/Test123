/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XRefContinuingEducationAppTypeModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 *  XRefContinuingEducationAppTypeModel4WS model..
 * 
 *  Notes:
 * $Id: XRefContinuingEducationAppTypeModel4WS.cs 137738 2009-07-06 06:52:41Z ACHIEVO\jackie.yu $.
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
    public partial class XRefContinuingEducationAppTypeModel4WS : XRefContinuingEducationAppTypePKModel4WS
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
        public string required
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requiredHours
        {
            get;
            set;
        }
    }
}
