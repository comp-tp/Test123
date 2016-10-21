#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ProjectModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ProjectModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    public partial class ProjectModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] applications { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime auditDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool auditDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDateString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string projectDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel projectID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long projectNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string projectUdf1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string projectUdf2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string projectUdf3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string projectUdf4 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string relationShip { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string status { get; set; }
    }    
}
