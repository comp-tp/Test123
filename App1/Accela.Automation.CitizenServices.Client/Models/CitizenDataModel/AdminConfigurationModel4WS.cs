/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ACAModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: AdminConfigurationModel4WS.cs 209458 2011-12-12 06:03:07Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class AdminConfigurationModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string callerId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapTypeModel[] capTypeModel4WS { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XUITextModel[] labelModelArray { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string levelType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string moduleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleViewModel4WS[] simpleViewModels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public BizDomainModel4WS[] standardBizDomain { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public BizDomainModel4WS[] standardChoice4HardcodeArray { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public BizDomainModel4WS[] standardChoiceArray { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XPolicyModel[] standardChoiceHardcodeModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] tabsOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TemplateLayoutConfigModel[] templateLayoutConfigList { get; set; }
    }
}
