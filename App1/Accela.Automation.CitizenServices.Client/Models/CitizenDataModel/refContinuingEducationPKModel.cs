﻿#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RefContinuingEducationPKModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RefContinuingEducationPKModel.cs 181867 2011-09-27 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RefContinuingEducationModel))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class RefContinuingEducationPKModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> providerNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> refContEduNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }
    }
}