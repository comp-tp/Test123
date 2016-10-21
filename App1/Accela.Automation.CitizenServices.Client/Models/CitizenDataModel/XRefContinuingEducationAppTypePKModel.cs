#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XRefContinuingEducationAppTypePKModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: XRefContinuingEducationAppTypePKModel.cs 181867 2011-09-27 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(XRefContinuingEducationAppTypeModel))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class XRefContinuingEducationAppTypePKModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string category { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string group { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> refContEduNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string type { get; set; }
    }
}
