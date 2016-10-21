using System;

// TODO:
// This class does not belong to this project.
// It comes from the User subsystem.
// Remove it late.

namespace Accela.Apps.Apis.Models.DomainModels.Portals
{
    public class CloudUserModel
    {
        public Guid Id
        {
            get;
            set;
        }
      
        public string LoginName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }
        
        public string Email
        {
            get;
            set;
        }

        public int? MonthOfBirthday
        {
            get;
            set;
        }

        public int? DayOfBirthday
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Country
        {
            get;
            set;
        }

        public string StreetAddress1
        {
            get;
            set;
        }

        public string StreetAddress2
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }

        public string PostalCode
        {
            get;
            set;
        }

        public string PhoneCountryCode
        {
            get;
            set;
        }

        public string PhoneAreaCode
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public string PhoneExtension
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }

        public DateTime? LastUpdatedDate
        {
            get;
            set;
        }

        public DateTime? CreatedDate
        {
            get;
            set;
        }

        public string LastUpdatedBy
        {
            get;
            set;
        }

        public string CreatedBy
        {
            get;
            set;
        }

        public string Keep1
        {
            get;
            set;
        }

        public string Keep2
        {
            get;
            set;
        }

        public string Question
        {
            get;
            set;
        }

        public string Answer
        {
            get;
            set;
        }

        public string ProfileImageUrl
        {
            get;
            set;
        }
    }
}
