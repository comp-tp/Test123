#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: DateAndTimesModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: DateAndTimesModel.cs 196819 2011-05-23 08:23:22Z ACHIEVO\daly.zeng $.
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DateTimeRangePageModel))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class DateAndTimesModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> date { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CalendarTimePeriod[] times { get; set; }
    }
}
