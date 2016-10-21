/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: BCalcValuatnModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: BCalcValuatnModel4WS.cs 
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class BCalcValuatnModel4WS
    {/// <summary>
        /// Unit Type
        /// </summary>
        /// <summary>
        /// Job Value
        /// </summary>

        /// <summary>
        /// Unit Type (i.e. SQFT)   
        /// </summary>/// <summary>
        /// Unit Amount
        /// </summary>/// <summary>
        /// Occupancy Type
        /// </summary>
        /// <summary>
        /// Fields For Internationa Lization
        /// </summary>/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long calcValueSeqNbr { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel4WS capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string conTyp { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string disConType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string excludeRegionalModifier { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string feeIndicator { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double totalValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double unitCost { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitTyp { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string disUnitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double unitValue { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string useTyp { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string disUseType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string version { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string disVersion { get; set; }
        
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int RowIndex { get; set; }
    }
}