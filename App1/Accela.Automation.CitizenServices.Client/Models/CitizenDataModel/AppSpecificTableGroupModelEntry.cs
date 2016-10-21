#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: AppSpecificTableGroupModelEntry.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: AppSpecificTableGroupModelEntry.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://service.webservice.accela.com/")]
    public partial class AppSpecificTableGroupModelEntry
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object key { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object value { get; set; }
    }
}
