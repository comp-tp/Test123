#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RefEducationModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RefEducationModel.cs 181867 2011-09-27 08:06:18Z ACHIEVO\daly.zeng $.
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
    public partial class RefEducationModel : RefEducationPKModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string comments { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string degree { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ProviderModel[] providerModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XRefEducationAppTypeModel[] refEduAppTypeModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XRefEducationProviderModel[] refEduProviderModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refEducationName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> resId { get; set; }
    }
}
