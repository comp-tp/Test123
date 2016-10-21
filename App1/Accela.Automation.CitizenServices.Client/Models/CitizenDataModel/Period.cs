﻿#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: Period.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: Period.cs 196759 2011-05-20 08:33:32Z ACHIEVO\daly.zeng $.
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(CalendarTimePeriod))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class Period
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> endDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> startDate { get; set; }
    }
}