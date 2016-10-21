/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CreditCardModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2007-2009
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CreditCardModel4WS.cs 130107 2009-05-11 12:23:56Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.42")]
    [DataContract]
    
    
    
    public partial class CreditCardModel4WS
    {
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string accelaFee { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string accountNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AdditionInfo[] additionInfo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string balance { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string billingPostalCD { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string businessName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string callerID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string cardType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string city { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string clientID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string convFee { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string countryCD { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string email { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expirationDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expirationMonth { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string expirationYear { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string firstName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string holderName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string lastName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string middleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string paymentMethod { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue = false)]
        public bool pos { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string posTransSeq { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string postalCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string productID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requestID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string securityCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string servProvCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetAddress2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetAddress3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string telephone { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string telephoneCountryCode { get; set; }
    }
}
