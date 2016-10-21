#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: InspectionModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: InspectionModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class InspectionModel : LanguageModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool active { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ActivityModel activity { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CalendarInspectionTypeModel calendarInspectionType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapModel cap { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapContactModel capContactModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapTypeModel capType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string capTypeStr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CommentModel comment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool completed { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool configuredInInspFlow { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TimeLogModel[] displayTimeModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string enabledCheck { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TimeLogModel[] existTimeModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int guideSheetCount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GGuideSheetModel[] gGuideSheetModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int index { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspectionDepartmentName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspectionType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AddressModel primaryAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public LicenseProfessionalModel primaryLicenseProfessional { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CommentModel requestComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resultComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int schedOrder { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool schedOrderSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] specialInfo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public StandardCommentModel[] standardComments { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] timeAccountUpdateModelList { get; set; }
    }
}
