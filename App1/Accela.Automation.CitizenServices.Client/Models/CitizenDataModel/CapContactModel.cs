#region Header
/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: CapContactModel.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: CapContactModel.cs 181867 2010-10-06 08:06:18Z ACHIEVO\daly.zeng $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */
#endregion Header
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3053")]
    [DataContract]
    
    
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://service.webservice.accela.com/")]
    public partial class CapContactModel
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string accessLevel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressLine1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressLine2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string addressLine3 { get; set; }

        ///System.DateTime
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string birthDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool birthDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string busName2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string businessName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public CapIDModel capID { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string city { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string componentName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactOnSRChange { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contactTypeFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string country { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string countryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string email { get; set; }

        //System.DateTime
        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string endBirthDate { get; set; }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool endBirthDateSpecified { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fax { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string faxCountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fein { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string firstName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string fullName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gender { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string lastName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string maskedSsn { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string middleName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public PeopleModel people { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string personType { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone1CountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone2CountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string phone3CountryCode { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string postOfficeBox { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string primaryFlag { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string refContactNumber { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string relation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string salutation { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string state { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string streetName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string title { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string tradeName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string zip { get; set; }
    }    
}
