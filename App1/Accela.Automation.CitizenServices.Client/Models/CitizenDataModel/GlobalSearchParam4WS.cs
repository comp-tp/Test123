#region Header

/**
 * <pre>
 *
 *  Accela Citizen Access
 *  File: GlobalSearchParam4WS.cs
 *
 *  Accela, Inc.
 *  Copyright (C): 2009
 *
 *  Description:
 *  
 *
 *  Notes:
 *  $Id: GlobalSearchParam4WS.cs 130988 2009-8-21  10:22:01Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class GlobalSearchParam4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string[] moduleArray { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string queryString { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int recordCount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int recordStartNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string searchType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sortColumn { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string sortDirection { get; set; }
    }
}
