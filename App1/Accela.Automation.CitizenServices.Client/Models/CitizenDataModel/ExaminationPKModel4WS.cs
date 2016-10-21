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
 * $Id: EducationPKModel4WS.cs 137738 2009-07-06 06:52:41Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using System;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ExaminationModel4WS))]
    
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class ExaminationPKModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long examNbr
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
