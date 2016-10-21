#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RefFeeDsecVO.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ExamScheduleViewModel.cs 181867 2011-09-27 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class RefFeeDsecVO
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeAmount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeDesc { get; set; }
    }
}
