/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: AppSpecificTableField4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: AppSpecificTableField4WS.cs 158598 2009-11-26 07:01:54Z ACHIEVO\weiky.chen $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class AppSpecificTableField4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int displayLength { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int displayOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool drillDown { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string errorTip { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fieldGroup { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fieldID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fieldLabel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int fieldType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int index { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inputValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int maxLength { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string nameSuffix { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string pattern { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool readOnly { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool required { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool requiredFeeCalc { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long rowIndex { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool searchAble { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public RefAppSpecInfoDropDownModel4WS[] selectOptions { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string status { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public bool supervisorEditOnly { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unit { get; set; }
    }
}
