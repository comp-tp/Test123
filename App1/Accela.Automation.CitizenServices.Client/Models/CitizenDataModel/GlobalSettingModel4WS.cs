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
 * $Id: GlobalSettingModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class GlobalSettingModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ContentTemplateModel4WS contentInfo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public BizDomainModel4WS mailFromInfo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public BizDomainModel4WS mailToInfo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ContentTemplateModel4WS subjectInfo { get; set; }
    }}
