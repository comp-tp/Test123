using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;

namespace Accela.Apps.Apis.Models.DTOs.Requests.ContactRequests
{
    public class SearchContactsRequest : PageListRequest
    {
        public Person Person { get; set; }

        public Organization Organization { get; set; }
        
    }

    public class Person
    {
        public Addresses Addresses { get; set; }
        public ActorRole Role { get; set; }

        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public List<string> MiddleNames { get; set; }
        public string FullName { get; set; }
    }

    public class ActorRole
    {
        public string Role { get; set; }

        public string UserDefinedRole { get; set; }
    }

    public class Addresses
    {
        public PostalAddress PostalAddress { get; set; }

        public TelecomAddress TelecomAddress { get; set; }
    }

    public class PostalAddress
    {
        public List<string> AddressLines { get; set; }

        public string PostalCode { get; set; }

        public string Town { get; set; }

        public string Region { get; set; }
    }

    public class TelecomAddress
    {
        public List<string> TelephoneNumbers { get; set; }

        public List<string> FacsimileNumbers { get; set; }

        public List<string> ElectronicMailAddresses { get; set; }
    }

    public class Organization
    {
        public string Name { get; set; }

        public string ContactBusinessName { get; set; }
    }    
}
