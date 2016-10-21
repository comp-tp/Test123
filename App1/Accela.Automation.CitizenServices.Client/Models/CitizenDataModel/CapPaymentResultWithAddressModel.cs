/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CompletePaymentResultModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CapPaymentResultWithAddressModel.cs 219041 2012-05-10 05:40:41Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    [System.Xml.Serialization.SoapTypeAttribute(Namespace = "http://model.webservice.accela.com")]
    public partial class CapPaymentResultWithAddressModel
    {

        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable = true)]
        public string actionSource { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable = true)]
        public CapIDModel4WS capID { get; set; } 

        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable = true)]
        public bool paymentStatus { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable = true)]
        public string moduleName { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable = true)]
        public string receiptNbr { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable = true)]
        public string batchNbr { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable = true)]
        public string paramString { get; set; }

        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable = true)]
        public AddressModel address
        {
            get;
            set;
        }/// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable = true)]
        public string capType { get; set; }       
            
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable = true)]
        public bool hasFee { get; set; }
        
    }
}
