#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XInspectionTypeCategoryPKModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: XInspectionTypeCategoryPKModel.cs 184506 2010-11-12 09:03:21Z ACHIEVO\xinter.peng $.
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
    
    
    
    public partial class XInspectionTypeCategoryPKModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string categoryName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long sequenceNumber { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool sequenceNumberSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProvideCode { get; set; }
    }
}
