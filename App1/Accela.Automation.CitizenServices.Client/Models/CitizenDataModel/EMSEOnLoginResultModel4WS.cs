/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: EMSEOnLoginResultModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2008-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: EMSEOnLoginResultModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
     /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://model.webservice.accela.com")]
    public partial class EMSEOnLoginResultModel4WS : EMSEResultBaseModel4WS {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string returnToLogin { get; set; }
    }
}