/**
 *  Accela Citizen Access
 *  File: ParameterModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2011
 *  * 
 *  Description:
 * 
 * 
 *  Notes:
 * $Id: ReportParameterModel4WS.cs 197931 2011-06-22 05:56:38Z ACHIEVO\alan.hu $.
 *  Revision History
 *  Date,                  Who,                 What
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class ParameterModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string allowMultipleValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string defaultValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispDefaultValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dispParameterName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parameterMask { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parameterName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long parameterOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parameterRequired { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parameterSource { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parameterType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string parameterVisible { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long prtParameterId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long reportId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] resColumns { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resLangId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resParameterName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int rowNum { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }
    }
}
