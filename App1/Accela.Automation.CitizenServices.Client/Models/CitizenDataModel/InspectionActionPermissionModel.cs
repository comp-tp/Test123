/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: InspectionActionPermissionModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: InspectionActionPermissionModel.cs 169604 2010-03-30 09:59:38Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class InspectionActionPermissionModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actionCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AppStatusGroupModel appStatusGroupModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool enabled { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public InspectionTypeModel inspectionTypeModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long sequenceNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProvideCode { get; set; }
    }
}
