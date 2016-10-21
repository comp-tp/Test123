/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CapTypeDetailModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CapTypeDetailModel.cs 171719 2010-04-29 10:28:45Z ACHIEVO\hans.shi $.
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
    
    [DataContract]
    
    
    
    public partial class CapTypeDetailModel : CapTypeModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string altMask1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string altMask2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> altSeq1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> altSeq2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string altSeqReset1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string altSeqReset2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string appSpecificInfoCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string appStatusGroupCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int categoryDispOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string copyAllAssociatedAPO { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string defaultCapTypeStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string docCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string docCode4ACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> estCostPerUnit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> estProdUnits { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expirationCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string GISServiceID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string GISTypeID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string hrEmail { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string inspectionCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string partialAltIdMask { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string perUdcode1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string prodUnitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string smartchoiceCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string smartchoiceCode4ACA { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int subTypeDispOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string temporaryAltIdMask { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public int typeDispOrder { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udcode3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string valueRequired { get; set; }
    }
}
