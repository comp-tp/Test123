﻿#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CostingPK.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CostingPK.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class CostingPK
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long costingCostID { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool costingCostIDSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }
    }
}
