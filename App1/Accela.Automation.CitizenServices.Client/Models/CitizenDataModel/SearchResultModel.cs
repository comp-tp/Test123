/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: SearchResultModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: SearchResultModel.cs 189014 2011-01-18 07:49:03Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class SearchResultModel
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object[] resultList
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int startRow
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool searchAllStartRow
        {
            get;
            set;
        }

        public SearchResultModel()
        { }
    }
}
