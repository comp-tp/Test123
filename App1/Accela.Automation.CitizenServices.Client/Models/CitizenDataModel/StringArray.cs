/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: StringArray.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: StringArray.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy.WSModel
{
    /// <remarks/>
    
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://jaxb.dev.java.net/array")]
    public partial class StringArray
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] item { get; set; }
    }
}
