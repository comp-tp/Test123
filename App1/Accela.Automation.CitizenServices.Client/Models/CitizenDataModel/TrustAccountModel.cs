/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: TrustAccountModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: TrustAccountModel.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{    
    
    /// <remarks/>
    
    [DataContract]
    
    
    
    public partial class TrustAccountModel : TrustAccountBaseModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> acctBalance { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> acctSeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel associatedCapID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string associations { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<double> overdraftLimit { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string primary { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double thresholdAmount { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool thresholdAmountSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public TrustAccountTransactionModel[] trustAccountTransactionModels { get; set; }
    }
}
