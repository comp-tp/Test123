/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ExpressionFieldModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2011-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ExpressionFieldModel.cs 136242 2009-06-25 08:17:45Z ACHIEVO\weiky.chen $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class ExpressionFieldModel : RefExpressionPK
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<bool> blockSubmit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> columnCount { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> columnIndex { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<bool> dbRequired { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fireEvent { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<bool> hidden { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool isCalculateField { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<bool> isReturn { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string label { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string message { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string name { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<bool> readOnly { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<System.DateTime> recDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recFulNam { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refColumnName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<bool> required { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> rowIndex { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string subGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> type { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string usage { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public object value { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string variableKey { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> viewID { get; set; }
    }
}
