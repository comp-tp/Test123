#region Header

/**
 * <pre>
 *
 *  Accela Citizen Access
 *  File: XSocialMediaEntityPKModel.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2012
 *
 *  Description:
 *
 * </pre>
 */
#endregion
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(XSocialMediaEntityModel))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [DataContract]
    
    
    
    public partial class XSocialMediaEntityPKModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actionSource { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actionType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> publicUserSeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }
    }
}
