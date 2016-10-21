/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: AcaAdminTreeNodeModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: AcaAdminTreeNodeModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class AcaAdminTreeNodeModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actionURL { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string country { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string elementID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string elementName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string forceLogin { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isSelected { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isUsedDaily { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string labelKey { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string nodeDescribe { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string pageType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parentID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFul_Nam { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string rootNodeName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string root_ID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }
    }
    
}
