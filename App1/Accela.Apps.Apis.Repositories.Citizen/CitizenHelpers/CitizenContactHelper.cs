using System;
using System.Collections.Generic;
using Accela.ACA.WSProxy;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Repositories.Citizen;
using Accela.Automation.CitizenServices.Client.Models.Response.Record;

namespace Accela.Apps.Apis.Repositories.CitizenHelpers
{
    public class CitizenContactModelHelper
    {
        private string _serviceProvCode;
        public CitizenContactModelHelper(string serviceProvCode)
        {
            _serviceProvCode = serviceProvCode;
        }

        public static RecordContactsResponse ToEntityContactResponse(CitizenRecordContactsResponse citizenResponse)
        {
            RecordContactsResponse response = null;

            if (citizenResponse != null)
            {
                response = new RecordContactsResponse();
                response.Contacts = ToEntityContacts(citizenResponse.result);
            }

            return response;
        }

        public static List<Accela.Apps.Apis.Models.DomainModels.ContactModels.ContactModel> ToEntityContacts(List<CapContactModel> citizenObjs)
        {
            List<Accela.Apps.Apis.Models.DomainModels.ContactModels.ContactModel> entityContacts = null;

            if (citizenObjs != null)
            {
                entityContacts = new List<Accela.Apps.Apis.Models.DomainModels.ContactModels.ContactModel>();
                foreach (var citizenContact in citizenObjs)
                {
                    Accela.Apps.Apis.Models.DomainModels.ContactModels.ContactModel clientContact = ToEntityContact(citizenContact);
                    if (clientContact != null)
                    {
                        entityContacts.Add(clientContact);
                    }
                }
            }

            return entityContacts;
        }

        public static Accela.Apps.Apis.Models.DomainModels.ContactModels.ContactModel ToEntityContact(CapContactModel citizenContact)
        {
            Accela.Apps.Apis.Models.DomainModels.ContactModels.ContactModel clientContact = null;
            if (citizenContact != null && citizenContact.people != null)
            {
                clientContact = new Accela.Apps.Apis.Models.DomainModels.ContactModels.ContactModel();
                clientContact.Identifier = citizenContact.people.contactSeqNumber;
                clientContact.FamilyName = citizenContact.people.lastName;
                clientContact.GivenName = citizenContact.people.firstName;
                if (!string.IsNullOrWhiteSpace(citizenContact.people.middleName))
                {
                    clientContact.MiddleNames = new List<string>();
                    clientContact.MiddleNames.Add(citizenContact.people.middleName);
                }

                clientContact.FullName = citizenContact.people.fullName;
                clientContact.Tels = new List<string>();
                if (!string.IsNullOrWhiteSpace(citizenContact.people.phone1))
                {
                    clientContact.Tels.Add(citizenContact.people.phone1);
                }

                if (!string.IsNullOrWhiteSpace(citizenContact.people.phone2))
                {
                    clientContact.Tels.Add(citizenContact.people.phone2);
                }

                if (!string.IsNullOrWhiteSpace(citizenContact.people.phone3))
                {
                    clientContact.Tels.Add(citizenContact.people.phone3);
                }

                if (clientContact.Tels.Count == 0)
                {
                    clientContact.Tels = null;
                }

                if (!string.IsNullOrWhiteSpace(citizenContact.people.fax))
                {
                    clientContact.Faxs = new List<string>();
                    clientContact.Faxs.Add(citizenContact.people.fax);
                }

                if (!string.IsNullOrWhiteSpace(citizenContact.people.email))
                {
                    clientContact.Emails = new List<string>();
                    clientContact.Emails.Add(citizenContact.people.email);
                }

                if (!string.IsNullOrWhiteSpace(citizenContact.people.contactType))
                {
                    clientContact.ContactRole = new ContactRoleModel();
                    clientContact.ContactRole.Identifier = citizenContact.people.contactType;
                    clientContact.ContactRole.Display = citizenContact.people.contactType;
                }

                clientContact.BusinessName = citizenContact.people.businessName;
                clientContact.IsPrimary = citizenContact.primaryFlag;

                clientContact.MailingAddress = CitizenAddressHelper.ToEnityAddress(citizenContact.people.compactAddress);
            }

            return clientContact;
        }

        public CapContactModel4WS[] ToCitizenContacts(List<Accela.Apps.Apis.Models.DomainModels.ContactModels.ContactModel> entityContacts)
        {
            List<CapContactModel4WS> result = new List<CapContactModel4WS>();

            if (entityContacts != null
                && entityContacts.Count > 0)
            {
                foreach (var contact in entityContacts)
                {
                    result.Add(ToCitizenContact(contact));
                }
            }

            return result.ToArray();
        }

        private CapContactModel4WS ToCitizenContact(Accela.Apps.Apis.Models.DomainModels.ContactModels.ContactModel contact)
        {
            CapContactModel4WS result = new CapContactModel4WS();

            if (contact != null)
            {
                var serviceProviderCode = _serviceProvCode;

                result.capID = new CapIDModel4WS();
                result.capID.serviceProviderCode = serviceProviderCode;

                result.people = new PeopleModel4WS();
                result.people.serviceProviderCode = serviceProviderCode;
                result.people.email = contact.Emails != null && contact.Emails.Count > 0 ? String.Join(",", contact.Emails.ToArray()) : null;

                if (contact.ContactRole != null)
                {
                    result.people.contactType = contact.ContactRole.Identifier;
                }

                result.people.firstName = contact.GivenName;
                result.people.lastName = contact.FamilyName;
                result.people.fullName = contact.FullName;
                result.people.businessName = contact.BusinessName;

                if (contact.MiddleNames != null)
                {
                    string tmpMiddleName = String.Empty;

                    foreach (var item in contact.MiddleNames)
                    {
                        tmpMiddleName += item;
                        tmpMiddleName += " ";
                    }

                    result.people.middleName = tmpMiddleName;
                }

                if (contact.Tels != null)
                {
                    result.people.phone1 = contact.Tels.Count > 0 ? contact.Tels[0] : String.Empty;
                    result.people.phone2 = contact.Tels.Count > 1 ? contact.Tels[1] : String.Empty;
                    result.people.phone3 = contact.Tels.Count > 2 ? contact.Tels[2] : String.Empty;
                }

                result.people.fax = contact.Faxs != null && contact.Faxs.Count > 0 ? String.Join(",", contact.Faxs.ToArray()) : String.Empty;
                result.people.postOfficeBox = contact.MailingAddress != null ? contact.MailingAddress.PostalCode : String.Empty;

                if (contact.MailingAddress != null)
                {
                    result.people.compactAddress = CitizenAddressHelper.ToCitizenCompactAddress(contact.MailingAddress);
                }
            }

            return result;
        }

        internal RefOwnerModel ToCitizenOwner(Accela.Apps.Apis.Models.DomainModels.ContactModels.OwnerModel entityOwner)
        {
            RefOwnerModel result = new RefOwnerModel();

            if (entityOwner != null)
            {
                result.capID = new CapIDModel();
                result.capID.serviceProviderCode = _serviceProvCode;

                result.primaryOwner = "Y";

                result.ownerFirstName = entityOwner.GivenName;
                result.ownerLastName1 = entityOwner.FamilyName;

                if (entityOwner.MiddleNames != null)
                {
                    string tmpMiddleName = String.Empty;

                    foreach (var item in entityOwner.MiddleNames)
                    {
                        tmpMiddleName += item;
                        tmpMiddleName += " ";
                    }

                    result.ownerMiddleName = tmpMiddleName;
                }

                result.ownerFullName = entityOwner.FullName;

                if (entityOwner.Tels != null
                    && entityOwner.Tels.Count > 0)
                {
                    result.phone = entityOwner.Tels[0];
                }

                if (entityOwner.MailingAddress != null)
                {
                    result.mailAddress1 = entityOwner.MailingAddress.AddressLine1;
                    result.mailAddress2 = entityOwner.MailingAddress.AddressLine2;
                    result.mailAddress3 = entityOwner.MailingAddress.AddressLine3;

                    result.mailCity = entityOwner.MailingAddress.City;
                    result.mailState = entityOwner.MailingAddress.State;
                    result.mailZip = entityOwner.MailingAddress.PostalCode;
                }

                if (entityOwner.Address != null)
                {
                    result.address1 = entityOwner.Address.AddressLine1;
                    result.address2 = entityOwner.Address.AddressLine2;
                    result.address3 = entityOwner.Address.AddressLine3;

                    result.city = entityOwner.Address.City;
                    result.state = entityOwner.Address.State;
                    result.zip = entityOwner.Address.PostalCode;
                }
            }

            return result;
        }
    }
}
