﻿#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XRefContinuingEducationProviderModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: XRefContinuingEducationProviderModel.cs 181867 2011-09-27 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class XRefContinuingEducationProviderModel : RefContinuingEducationProviderPKModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ProviderModel providerModel { get; set; }
    }
}
