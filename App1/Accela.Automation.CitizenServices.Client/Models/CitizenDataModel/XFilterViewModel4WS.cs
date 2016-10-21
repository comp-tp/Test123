/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: XFilterViewModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: XFilterViewModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
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
    
    
    
    public partial class XFilterViewModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] attributes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] attributesValues { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contractValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string displayColumns { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expandValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string filterDesc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string filterLevelId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GFilterLevelModel4WS[] filterLevels { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string filterName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string layout { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refreshInterval { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string selectType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sortOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string viewDesc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public XFilterViewElementModel4WS[] viewElements { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string viewId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string viewName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string viewType { get; set; }
    }
}
