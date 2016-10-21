using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models.Response
{
    [DataContract(Name = "citizenUser")]
    public class CitizenUserResponse
    {
        [DataMember(Name = "passwordChangeDate", EmitDefaultValue = false)]
        public string passwordChangeDate
        {
            get;
            set;
        }

        [DataMember(Name = "address", EmitDefaultValue = false)]
        public string address
        {
            get;
            set;
        }

        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string state
        {
            get;
            set;
        }

        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string country
        {
            get;
            set;
        }

        [DataMember(Name = "password", EmitDefaultValue = false)]
        public string password
        {
            get;
            set;
        }

        [DataMember(Name = "auditDate", EmitDefaultValue = false)]
        public string auditDate
        {
            get;
            set;
        }

        [DataMember(Name = "auditStatus", EmitDefaultValue = false)]
        public string auditStatus
        {
            get;
            set;
        }

        [DataMember(Name = "auditID", EmitDefaultValue = false)]
        public string auditID
        {
            get;
            set;
        }

        [DataMember(Name = "firstName", EmitDefaultValue = false)]
        public string firstName
        {
            get;
            set;
        }

        [DataMember(Name = "lastName", EmitDefaultValue = false)]
        public string lastName
        {
            get;
            set;
        }

        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string email
        {
            get;
            set;
        }

        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string city
        {
            get;
            set;
        }

        [DataMember(Name = "userID", EmitDefaultValue = false)]
        public string userID
        {
            get;
            set;
        }

        [DataMember(Name = "zip", EmitDefaultValue = false)]
        public string zip
        {
            get;
            set;
        }

        [DataMember(Name = "middleName", EmitDefaultValue = false)]
        public string middleName
        {
            get;
            set;
        }

        [DataMember(Name = "businessName", EmitDefaultValue = false)]
        public string businessName
        {
            get;
            set;
        }

        [DataMember(Name = "workPhone", EmitDefaultValue = false)]
        public string workPhone
        {
            get;
            set;
        }

        [DataMember(Name = "homePhone", EmitDefaultValue = false)]
        public string homePhone
        {
            get;
            set;
        }

        [DataMember(Name = "cellPhone", EmitDefaultValue = false)]
        public string cellPhone
        {
            get;
            set;
        }

        [DataMember(Name = "userSeqNum", EmitDefaultValue = false)]
        public string userSeqNum
        {
            get;
            set;
        }

        [DataMember(Name = "prefContactChannel", EmitDefaultValue = false)]
        public string prefContactChannel
        {
            get;
            set;
        }

        [DataMember(Name = "passwordRequestQuestion", EmitDefaultValue = false)]
        public string passwordRequestQuestion
        {
            get;
            set;
        }

        [DataMember(Name = "passwordRequestAnswer", EmitDefaultValue = false)]
        public string passwordRequestAnswer
        {
            get;
            set;
        }

        [DataMember(Name = "roleType", EmitDefaultValue = false)]
        public string roleType
        {
            get;
            set;
        }

        [DataMember(Name = "receiveSMS", EmitDefaultValue = false)]
        public string receiveSMS
        {
            get;
            set;
        }

        [DataMember(Name = "servProvCode", EmitDefaultValue = false)]
        public string servProvCode
        {
            get;
            set;
        }
    }
}