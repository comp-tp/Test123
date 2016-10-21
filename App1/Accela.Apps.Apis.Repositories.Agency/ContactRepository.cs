using System.Collections.Generic;
using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.ContactRequests;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Apis.Repositories.Agency
{
    public class ContactRepository : RepositoryBase, IContactRepository
    {
        private ContactHelper _contactHelper;
        //public ContactRepository(string appId, string agencyName, string serviceProvCode, string agencyUserId, string agencyUsername, string token, string environmentName, string language)
        //    : base(appId, agencyName, serviceProvCode, agencyUserId, agencyUsername, token, environmentName, language)
        //{
        //    var bizServerVersion = this.Environment.BizServerVersion;
        //    _contactHelper = new ContactHelper(bizServerVersion);
        //}

        public ContactRepository(IAgencyAppContext contextEntity)
            : base(contextEntity)
        {
            var bizServerVersion = this.Environment == null ? "" : this.Environment.BizServerVersion;
            if (bizServerVersion != "")
            {
                _contactHelper = new ContactHelper(bizServerVersion);
            }
        }

        public List<ContactModel> GetContacts(string type, string fullName, int offset, int limit, out Pagination pageInfo)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getContacts = new GetContacts();

            govXmlIn.getContacts.system = CommonHelper.GetSystem(new RequestBase() { Offset = offset, Limit = limit },this.CurrentContext);

            govXmlIn.getContacts.returnElements = new returnElements() { returnElement = new string[] { "Contact" } };

            govXmlIn.getContacts.Contact = new Contact();
            govXmlIn.getContacts.Contact.person = new Accela.Automation.GovXmlClient.Model.Person();
            if (!string.IsNullOrWhiteSpace(fullName))
            {
                govXmlIn.getContacts.Contact.person.fullName = fullName;
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                govXmlIn.getContacts.Contact.person.roles = new roles_ifc();
                govXmlIn.getContacts.Contact.person.roles.actorRole = new Accela.Automation.GovXmlClient.Model.ActorRole();
                govXmlIn.getContacts.Contact.person.roles.actorRole.userDefinedRole = type;
                govXmlIn.getContacts.Contact.person.roles.actorRole.role = "userdefined";
            }

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.getContacts.system,
                (o) => o.getContactsResponse == null ? null : o.getContactsResponse.system);

            List<ContactModel> contactModels = new List<ContactModel>();
            if (response.getContactsResponse != null &&
                response.getContactsResponse.contacts != null &&
                response.getContactsResponse.contacts.contact != null &&
                response.getContactsResponse.contacts.contact.Count() > 0)
            {
                foreach (var contact in response.getContactsResponse.contacts.contact)
                {
                    contactModels.Add(_contactHelper.ToClientContact(contact));
                }
            }

            pageInfo = new Pagination();
            if (response.getContactsResponse != null && response.getContactsResponse.system != null)
            {
                pageInfo = CommonHelper.GetPaginationFromSystem(response.getContactsResponse.system);
            }

            return contactModels;
        }

        public List<ContactModel> SearchContacts(SearchContactsRequest searchContactRequest, out Pagination pageInfo)
        {
            GovXML govXmlIn = new GovXML();
            govXmlIn.getContacts = new GetContacts();

            govXmlIn.getContacts.system = CommonHelper.GetSystem(new RequestBase() { Offset = searchContactRequest.Offset, Limit = searchContactRequest.Limit }, this.CurrentContext);

            govXmlIn.getContacts.returnElements = new returnElements() { returnElement = new string[] { "Contact" } };

            SetSearchContactGovXmlRequest(searchContactRequest, govXmlIn.getContacts);

            GovXML response = CommonHelper.Post(govXmlIn,
                govXmlIn.getContacts.system,
                (o) => o.getContactsResponse == null ? null : o.getContactsResponse.system);

            List<ContactModel> contactModels = new List<ContactModel>();
            if (response.getContactsResponse != null &&
                response.getContactsResponse.contacts != null &&
                response.getContactsResponse.contacts.contact != null &&
                response.getContactsResponse.contacts.contact.Count() > 0)
            {
                foreach (var contact in response.getContactsResponse.contacts.contact)
                {
                    contactModels.Add(_contactHelper.ToClientContact(contact));
                }
            }

            pageInfo = new Pagination();
            if (response.getContactsResponse != null && response.getContactsResponse.system != null)
            {
                pageInfo = CommonHelper.GetPaginationFromSystem(response.getContactsResponse.system);
            }

            return contactModels;
        }

        private void SetSearchContactGovXmlRequest(SearchContactsRequest searchContactsRequest, GetContacts getContacts)
        {
            if (searchContactsRequest != null)
            {
                getContacts.Contact = new Contact();
                getContacts.Contact.personAndOrganization = new PersonAndOrganization();

                // Person.
                if (searchContactsRequest.Person != null)
                {
                    getContacts.Contact.personAndOrganization.thePerson = new ThePerson();
                    getContacts.Contact.personAndOrganization.thePerson.person = new Automation.GovXmlClient.Model.Person();

                    if (!string.IsNullOrWhiteSpace(searchContactsRequest.Person.GivenName))
                    {
                        getContacts.Contact.personAndOrganization.thePerson.person.givenName = searchContactsRequest.Person.GivenName;
                    }

                    if (searchContactsRequest.Person.MiddleNames != null && searchContactsRequest.Person.MiddleNames.Count() > 0)
                    {
                        getContacts.Contact.personAndOrganization.thePerson.person.middleNames = new MiddleNames();
                        getContacts.Contact.personAndOrganization.thePerson.person.middleNames.String = searchContactsRequest.Person.MiddleNames.ToArray<string>();
                    }

                    if (!string.IsNullOrWhiteSpace(searchContactsRequest.Person.FamilyName))
                    {
                        getContacts.Contact.personAndOrganization.thePerson.person.familyName = searchContactsRequest.Person.FamilyName;
                    }

                    if (!string.IsNullOrWhiteSpace(searchContactsRequest.Person.FullName))
                    {
                        getContacts.Contact.personAndOrganization.thePerson.person.fullName = searchContactsRequest.Person.FullName;
                    }

                    // Roles.
                    if (searchContactsRequest.Person.Role != null)
                    {
                        getContacts.Contact.personAndOrganization.thePerson.person.roles = new roles_ifc();
                        getContacts.Contact.personAndOrganization.thePerson.person.roles.actorRole = new Accela.Automation.GovXmlClient.Model.ActorRole();
                        getContacts.Contact.personAndOrganization.thePerson.person.roles.actorRole.userDefinedRole = searchContactsRequest.Person.Role.UserDefinedRole;
                        getContacts.Contact.personAndOrganization.thePerson.person.roles.actorRole.role = "userdefined";
                    }

                    // Address.
                    if (searchContactsRequest.Person.Addresses != null)
                    {
                        getContacts.Contact.personAndOrganization.thePerson.person.addresses = new Automation.GovXmlClient.Model.Addresses();

                        // Post address.
                        if (searchContactsRequest.Person.Addresses.PostalAddress != null)
                        {
                            getContacts.Contact.personAndOrganization.thePerson.person.addresses.postalAddress = new Automation.GovXmlClient.Model.PostalAddress();
                            if (searchContactsRequest.Person.Addresses.PostalAddress.AddressLines != null && searchContactsRequest.Person.Addresses.PostalAddress.AddressLines.Count() > 0)
                            {
                                getContacts.Contact.personAndOrganization.thePerson.person.addresses.postalAddress.addressLines = new AddressLinesIFC();
                                getContacts.Contact.personAndOrganization.thePerson.person.addresses.postalAddress.addressLines.str = searchContactsRequest.Person.Addresses.PostalAddress.AddressLines.ToArray();
                            }
                            getContacts.Contact.personAndOrganization.thePerson.person.addresses.postalAddress.postalCode = searchContactsRequest.Person.Addresses.PostalAddress.PostalCode;
                            getContacts.Contact.personAndOrganization.thePerson.person.addresses.postalAddress.region = searchContactsRequest.Person.Addresses.PostalAddress.Region;
                            getContacts.Contact.personAndOrganization.thePerson.person.addresses.postalAddress.town = searchContactsRequest.Person.Addresses.PostalAddress.Town;
                        }

                        // Telecom address.
                        if (searchContactsRequest.Person.Addresses.TelecomAddress != null)
                        {
                            getContacts.Contact.personAndOrganization.thePerson.person.addresses.telecomAddress = new Automation.GovXmlClient.Model.TelecomAddress();
                            if (searchContactsRequest.Person.Addresses.TelecomAddress.ElectronicMailAddresses != null && searchContactsRequest.Person.Addresses.TelecomAddress.ElectronicMailAddresses.Count() > 0)
                            {
                                getContacts.Contact.personAndOrganization.thePerson.person.addresses.telecomAddress.electronicMailAddresses = new ElectronicMailAddresses();
                                getContacts.Contact.personAndOrganization.thePerson.person.addresses.telecomAddress.electronicMailAddresses.str = searchContactsRequest.Person.Addresses.TelecomAddress.ElectronicMailAddresses.ToArray();
                            }

                            if (searchContactsRequest.Person.Addresses.TelecomAddress.FacsimileNumbers != null && searchContactsRequest.Person.Addresses.TelecomAddress.FacsimileNumbers.Count() > 0)
                            {
                                getContacts.Contact.personAndOrganization.thePerson.person.addresses.telecomAddress.facsimileNumbers = new FacsimileNumbers();
                                getContacts.Contact.personAndOrganization.thePerson.person.addresses.telecomAddress.facsimileNumbers.str = searchContactsRequest.Person.Addresses.TelecomAddress.FacsimileNumbers.ToArray();
                            }

                            if (searchContactsRequest.Person.Addresses.TelecomAddress.TelephoneNumbers != null && searchContactsRequest.Person.Addresses.TelecomAddress.TelephoneNumbers.Count() > 0)
                            {
                                getContacts.Contact.personAndOrganization.thePerson.person.addresses.telecomAddress.telephoneNumbers = new TelephoneNumbers();
                                getContacts.Contact.personAndOrganization.thePerson.person.addresses.telecomAddress.telephoneNumbers.str = searchContactsRequest.Person.Addresses.TelecomAddress.TelephoneNumbers.ToArray();
                            }
                        }
                    }
                }

                // Organization.
                if (searchContactsRequest.Organization != null)
                {
                    getContacts.Contact.personAndOrganization.theOrganization = new TheOrganization();
                    getContacts.Contact.personAndOrganization.theOrganization.organization = new Accela.Automation.GovXmlClient.Model.Organization();
                    getContacts.Contact.personAndOrganization.theOrganization.organization.name = searchContactsRequest.Organization.Name;
                    getContacts.Contact.personAndOrganization.theOrganization.organization.contactBusinessName = searchContactsRequest.Organization.ContactBusinessName;
                }
            }
        }
    }
}
