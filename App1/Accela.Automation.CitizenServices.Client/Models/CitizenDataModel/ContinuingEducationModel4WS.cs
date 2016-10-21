/**
 * <pre>
 * 
 *  Accela Citizen Access
 *  File: ContinuingEducationModel4WS.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2009-2012
 * 
 *  Description:
 * 
 *  Notes:
 * $Id: ContinuingEducationModel4WS.cs 136284 2009-06-25 10:10:38Z ACHIEVO\jackie.yu $.
 *  Revision History
 *  &lt;Date&gt;,    &lt;Who&gt;,    &lt;What&gt;
 * </pre>
 */

using System;
using System.Runtime.Serialization;
namespace Accela.ACA.WSProxy
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [DataContract]
    
    
    
    public partial class ContinuingEducationModel4WS
    {/// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public AuditModel4WS auditModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string b1PerId1 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string b1PerId2 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string b1PerId3 { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string className { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string comments { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string contEduName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ContinuingEducationPKModel4WS continuingEducationPKModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string dateOfClass { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string finalScore { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string gradingStyle { get; set; }

        /// <summary>
        /// Row Index
        /// </summary>
        public int RowIndex
        {
            get;
            set;
        }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public double hoursCompleted { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string passingScore { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public ProviderDetailModel4WS providerDetailModel { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string providerName { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string providerNo { get; set; }

        /// <remarks/>
        [DataMember(EmitDefaultValue=false)]
        public string requiredFlag { get; set; }/// <summary>
        /// provider detail address1
        /// </summary>
        public string address1
        {
            get
            {
                return providerDetailModel == null ? String.Empty : providerDetailModel.address1;
            }
        }

        /// <summary>
        /// provider detail address2
        /// </summary>
        public string address2
        {
            get
            {
                return providerDetailModel == null ? String.Empty : providerDetailModel.address2;
            }
        }

        /// <summary>
        /// provider detail address3
        /// </summary>
        public string address3
        {
            get
            {
                return providerDetailModel == null ? String.Empty : providerDetailModel.address3;
            }
        }

        /// <summary>
        /// provider detail city
        /// </summary>
        public string city
        {
            get
            {
                return providerDetailModel == null ? String.Empty : providerDetailModel.city;
            }
        }

        /// <summary>
        /// provider detail state
        /// </summary>
        public string state
        {
            get
            {
                return providerDetailModel == null ? String.Empty : providerDetailModel.state;
            }
        }

        /// <summary>
        /// provider detail zip
        /// </summary>
        public string zip
        {
            get
            {
                return providerDetailModel == null ? String.Empty : providerDetailModel.zip;
            }
        }

        /// <summary>
        /// provider detail phone1
        /// </summary>
        public string phone1
        {
            get
            {
                return providerDetailModel == null ? String.Empty : providerDetailModel.phone1;
            }
        }

        /// <summary>
        /// provider detail phone1CountryCode
        /// </summary>
        public string phone1CountryCode
        {
            get
            {
                return providerDetailModel == null ? String.Empty : providerDetailModel.phone1CountryCode;
            }
        }

        /// <summary>
        /// provider detail phone2
        /// </summary>
        public string phone2
        {
            get
            {
                return providerDetailModel == null ? String.Empty : providerDetailModel.phone2;
            }
        }

        /// <summary>
        /// provider detail phone2CountryCode
        /// </summary>
        public string phone2CountryCode
        {
            get
            {
                return providerDetailModel == null ? String.Empty : providerDetailModel.phone2CountryCode;
            }
        }

        /// <summary>
        /// provider detail fax
        /// </summary>
        public string fax
        {
            get
            {
                return providerDetailModel == null ? String.Empty : providerDetailModel.fax;
            }
        }

        /// <summary>
        /// provider detail faxCountryCode
        /// </summary>
        public string faxCountryCode
        {
            get
            {
                return providerDetailModel == null ? String.Empty : providerDetailModel.faxCountryCode;
            }
        }

        /// <summary>
        /// provider detail email
        /// </summary>
        public string email
        {
            get
            {
                return providerDetailModel == null ? String.Empty : providerDetailModel.email;
            }
        }
    }
}
