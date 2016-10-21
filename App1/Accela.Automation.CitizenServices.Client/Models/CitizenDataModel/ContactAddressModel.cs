#region Header

/**
* <pre>
*  Accela Citizen Access
*  File: ContactAddressModel.cs
*
*  Accela, Inc.
*  Copyright (C): 2011
*
*  Description: Contact Address model.
*
*  Notes:
* $Id: ContactAddressModel.cs 210786 2011-12-27 09:54:22Z ACHIEVO\daly.zeng $.
*  Revision History
*  Date,            Who,        What
*  Dec 5, 2011      Alan Hu     Initial.
* </pre>
*/

#endregion
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class ContactAddressModel
    {/// <remarks/>
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
        public string addressType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public SimpleAuditModel auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string city { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ContactAddressPKModel contactAddressPK { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string countryCode { get; set; }

        /// <summary>
        /// Old type is date time
        /// </summary>
        [DataMember(EmitDefaultValue=false)]
        public string effectiveDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<long> entityID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string entityType { get; set; }

        /// <summary>
        /// Old type is date time
        /// </summary>
        [DataMember(EmitDefaultValue=false)]
        public string expirationDate { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fax { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string faxCountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fullAddress { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> houseNumberEnd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public System.Nullable<int> houseNumberStart { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string orderBy { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phoneCountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string recipient { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetDirection { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetPrefix { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetSuffix { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetSuffixDirection { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitEnd { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitStart { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string unitType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string zip { get; set; }

        /// <summary>
        /// row index id.
        /// </summary>
        public int RowIndex
        {
            get;
            set;
        }
    }
}
