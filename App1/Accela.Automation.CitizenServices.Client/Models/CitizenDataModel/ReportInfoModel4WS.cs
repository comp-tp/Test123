/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ReportInfoModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ReportInfoModel4WS.cs 182154 2010-10-12 02:15:53Z ACHIEVO\hans.shi $.
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
    
    
    
    public partial class ReportInfoModel4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string callerId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public EDMSEntityIdModel4WS edMSEntityIdModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string emailAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string emailReportName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string isFrom { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isPreview { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string module { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool notSaveToEDMS { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long reportId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string reportIdFromOthers { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] reportParameterMapKeys { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] reportParametersMapValues { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ssOAuthId { get; set; }
    }
     
}
