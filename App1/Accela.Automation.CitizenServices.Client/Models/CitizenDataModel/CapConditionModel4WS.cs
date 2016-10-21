/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CapConditionModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CapConditionModel4WS.cs 190963 2011-02-23 06:59:43Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [DataContract]
    
    
    
    public partial class CapConditionModel4WS
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string actionDepartmentName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string appliedDepartmentName { get; set; }

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
        public CapIDModel4WS capID { get; set; }

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
        [DataMember(EmitDefaultValue = false)]
        public long conditionNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string conditionSource { get; set; }

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
        public string displayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string effectDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expireDate { get; set; }

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
        public SysUserModel4WS issuedByUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string issuedDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string longDescripton { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string noticeAction { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string noticeActionType { get; set; }

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
        [DataMember(EmitDefaultValue = false)]
        public long referenceConditionNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resConditionComment { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resConditionDescription { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resLangId { get; set; }

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
        [DataMember(EmitDefaultValue = false)]
        public long sourceNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string standardConditionNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SysUserModel4WS statusByUser { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string statusDate { get; set; }
    }
}
