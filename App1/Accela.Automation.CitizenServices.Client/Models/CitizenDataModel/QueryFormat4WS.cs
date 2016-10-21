/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: QueryFormat4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: QueryFormat4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class QueryFormat4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int endRow { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool endRowSet { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string grouping { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool groupingSet { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int maxRows { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string order { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool orderSet { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool publicUserFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int startRow { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool startRowSet { get; set; }
    }

}
