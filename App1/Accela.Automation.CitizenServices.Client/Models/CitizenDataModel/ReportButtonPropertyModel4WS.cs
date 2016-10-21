/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ReportButtonPropertyModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ReportButtonPropertyModel4WS.cs 130439 2009-05-13 10:02:20Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class ReportButtonPropertyModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string buttonName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string errorInfo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isDisplayed { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string reportId { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string reportName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string resReportName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string description
        {
            get;
            set;
        }/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isMultipleWindow
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isSave2EDMS
        {
            get;
            set;
        }
    }
}
