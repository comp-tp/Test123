/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ContinuingEducationPKModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ContinuingEducationPKModel4WS.cs 136284 2009-06-25 10:10:38Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ContinuingEducationModel4WS))]
    
    [DataContract]
    
    
    
    public partial class ContinuingEducationPKModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long contEduNbr
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
