/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RefLicenseProfessionalPKModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 *  RefLicenseProfessionalPKModel4WS model..
 * 
 *  Notes:
 * $Id: RefLicenseProfessionalPKModel4WS.cs 137738 2009-07-06 06:52:41Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RefLicenseProfessionalModel4WS))]
    
    [DataContract]
    
    
    
    public partial class RefLicenseProfessionalPKModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long licSeqNbr
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode
        {
            get;
            set;
        }
    }
}
