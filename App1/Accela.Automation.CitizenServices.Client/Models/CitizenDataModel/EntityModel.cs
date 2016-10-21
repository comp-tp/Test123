#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: EntityModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: EntityModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class entityModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string customID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string from { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string moduleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }
    }
}
