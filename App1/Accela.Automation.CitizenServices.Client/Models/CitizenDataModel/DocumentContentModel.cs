#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: DocumentContentModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: DocumentContentModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    [DataContract]
    public partial class DocumentContentModel
    {
        [DataMember(EmitDefaultValue = false)]
        public string docContentStream { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public long documentNo { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool documentNoSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string recFulName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public string servProvCode { get; set; }
    }
}