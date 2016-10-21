#region Header

/**
 * <pre>
 *
 *  Accela Citizen Access
 *  File: CapView.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2009-2011
 *
 *  Description:
 *  
 *
 *  Notes:
 *  $Id: CapView.cs 130988 2009-9-8  9:32:01Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class CapView
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string altId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capClass { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capTypeAlias { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contact { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string createdDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string id { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] licenseNumberAndType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string location { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string moduleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string number { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string projectName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] refContactNumberAndAccessLevel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] refOwnerNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int relatedRecordsCount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string shortNotes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string statusGroupCode { get; set; }
    }
}
