/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: QueryFormat.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: QueryFormat.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class QueryFormat
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int endRow { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string grouping { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int maxRows { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string order { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool publicUserFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int startRow { get; set; }
    }
}