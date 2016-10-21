#region Header

/**
 * <pre>
 *
 *  Accela Citizen Access
 *  File: XSocialMediaUserPKModel.cs
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(XSocialMediaUserModel))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [DataContract]
    
    
    
    public partial class XSocialMediaUserPKModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> publicUserSeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string socialID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string socialType { get; set; }
    }
}
