/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: GISObjectModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GISObjectModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\grady.lu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [DataContract]
    
    
    
    public partial class GISObjectModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        //public System.Nullable<System.DateTime> auditDate { get; set; }
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gisId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gisLabelField { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gisObjectID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gisThemeGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gisThemeName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string id { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string latitudeCoordinate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string layerId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string longitudeCoordinate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> objectId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string primaryGISFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> serviceSourceNumber { get; set; }
    }
}
