/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: RefOwnerBaseModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: RefOwnerBaseModel.cs 171698 2010-04-29 09:39:39Z ACHIEVO\daly.zeng $.
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
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RefOwnerModel))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    
    public partial class RefOwnerBaseModel
    {

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string address3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        //public System.DateTime? auditDate
        public string auditDate
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string auditStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string city { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string country { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string email { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fax { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string faxCountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailAddress1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailAddress2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailAddress3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailCity { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailCountry { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailState { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string mailZip { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ownerFirstName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ownerFullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ownerLastName1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ownerMiddleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ownerStatus { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ownerTitle { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string ownerType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phoneCountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string primaryOwner { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string taxID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string UID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string udf4 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string zip { get; set; }
    }
}
