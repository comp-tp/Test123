/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ExpressionRuntimeArgumentsModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ExpressionRuntimeArgumentsModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class ExpressionRuntimeArgumentsModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> apoNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ExpressionRuntimeArgumentPKModel[] argumentPKs { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string asiGroupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string callerID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string executeFieldVariableKey { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string executeIn { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public StringIntegerMapEntry[] maxRowIndexes { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }
    }

    /// <remarks/>
    [DataContract]
    public partial class StringIntegerMapEntry
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string key
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int? value
        {
            get;
            set;
        }
    }
  
}
