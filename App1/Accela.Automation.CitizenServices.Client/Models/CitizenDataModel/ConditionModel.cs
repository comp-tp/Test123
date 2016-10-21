/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ConditionModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ConditionModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(NoticeConditionModel))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class ConditionModel : LanguageModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actionDepartmentName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string appliedDepartmentName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string conditionComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string conditionDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string conditionGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long conditionNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string conditionStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string conditionStatusAndTypeValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string conditionStatusType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string conditionType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispConditionComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispConditionDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispLongDescripton { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispPublicDisplayMessage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispResolutionAction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayConditionNotice { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayConditionStatusAndType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayNoticeOnACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayNoticeOnACAFee { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> effectDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> expireDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string impactCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string includeInConditionName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string includeInShortDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inheritable { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SysUserModel issuedByUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> issuedDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string longDescripton { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string noticeActionType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int priority { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string publicDisplayMessage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refNumber1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refNumber2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resConditionComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resConditionDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resLongDescripton { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resPublicDisplayMessage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resResolutionAction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resolutionAction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string rightGranted { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long sourceNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> standardConditionNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SysUserModel statusByUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> statusDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateModel template { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int UIUID { get; set; }

    }
}
