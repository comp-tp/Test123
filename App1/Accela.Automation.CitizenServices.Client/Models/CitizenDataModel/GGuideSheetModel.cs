#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: GGuideSheetModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GGuideSheetModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class GGuideSheetModel : LanguageModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string activityNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.DateTime auditDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool auditDateSpecified { get; set; }

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
        public string guideDesc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string guideType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long guidesheetSeqNbr { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool guidesheetSeqNbrSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string identifier { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GGuideSheetItemModel[] gGuideSheetItemModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resGuideType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }
    }
}