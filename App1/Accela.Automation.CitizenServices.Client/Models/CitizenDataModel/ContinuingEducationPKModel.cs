#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ContinuingEducationPKModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ContinuingEducationPKModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class ContinuingEducationPKModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long contEduNbr { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool contEduNbrSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }
    }
}
