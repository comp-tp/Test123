/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ReportButtonInfoModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ReportButtonInfoModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class ReportButtonInfoModel4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string buttonViewID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string callerID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel4WS capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string currentModule { get; set; }

        /// <remarks/>
		[DataMember(EmitDefaultValue=false)]
        public bool multipleCaps { get; set; }
    }
}
