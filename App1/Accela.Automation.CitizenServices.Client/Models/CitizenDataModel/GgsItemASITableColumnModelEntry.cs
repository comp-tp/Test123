#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: GgsItemASITableColumnModelEntry.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GgsItemASITableColumnModelEntry.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://model.webservice.accela.com")]
    public partial class GGSItemASITableColumnModelEntry
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long key { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool keySpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GGSItemASITableValueModel value { get; set; }
    }
}
