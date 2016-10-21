#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: GGSItemASITableSubGroupModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: GGSItemASITableSubGroupModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
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
    
    
    
    public partial class GGSItemASITableSubGroupModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int b1TableDspOrder { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool b1TableDspOrderSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public GGSItemASITableColumnModel[] columnList { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string disableTableSort { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string groupName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long guideItemSeqNbr { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool guideItemSeqNbrSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long guidesheetSeqNbr { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool guidesheetSeqNbrSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string serviceProviderCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string tableName { get; set; }
    }
}
