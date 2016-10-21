/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CompactAddressModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CompactAddressModel.cs 170671 2010-04-16 05:52:20Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class CompactAddressModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public long addressId { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool addressIdSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressLine1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressLine2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressLine3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string city { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string country { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string countryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string zip { get; set; }
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string countryZip { get; set; }  
    }
}
