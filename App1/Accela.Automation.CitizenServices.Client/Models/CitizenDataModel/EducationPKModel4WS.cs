/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: EducationPKModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 *  EducationPKModel4WS model..
 *  
 *  Notes:
 * $Id: EducationPKModel4WS.cs 142354 2009-08-07 02:19:45Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using System;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(EducationModel4WS))]
    
    [DataContract]
    
    
    
    public partial class EducationPKModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long educationNbr
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
