using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Resources;
using Accela.Apps.Shared.Exceptions;
using Accela.Automation.GovXmlClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class ContactHelper : GovXmlHelperBase
    {
        private string _bizServerVersion;

        public ContactHelper(string bizServerVersion)
        {
            if (String.IsNullOrEmpty(bizServerVersion))
            {
                throw new ArgumentNullException("bizServerVersion cannot be null.");
            }

            _bizServerVersion = bizServerVersion;
        }

        public Contacts ToXMLContacts(List<ContactModel> clientContacts)
        {
            Contacts retus = null;

            if (clientContacts != null)
            {
                List<Contact> xmlContacts = new List<Contact>();

                foreach (var item in clientContacts)
                {
                    Contact xmlContact = ToXMLContact(item);
                    if (xmlContact != null)
                    {
                        xmlContacts.Add(xmlContact);
                    }
                }

                retus = new Contacts();
                retus.contact = xmlContacts.ToArray();
            }

            return retus;
        }

        public Contact ToXMLContact(ContactModel clientContact)
        {
            Contact xmlContact = null;
            if (clientContact != null && !string.IsNullOrWhiteSpace(clientContact.Action)
                && clientContact.Action.ToLower() != "existing" && clientContact.Action.ToLower() != "normal"
                )
            {
                xmlContact = new Contact();

                // GovXML requires a key when creating a new contact.
                // If the being-created contact already has a key, i.e. reference contact, use it;
                // if it hasn't, add a dump key to it.
                //xmlContact.keys = KeysHelper.CreateXMLKeys(clientContact.Identifier);

                if (!String.IsNullOrEmpty(clientContact.Identifier))
                {
                    xmlContact.keys = KeysHelper.CreateXMLKeys(clientContact.Identifier);
                }
                else
                {
                    xmlContact.keys = new Keys();
                    xmlContact.keys.key = new string[] { "Contact" };
                }

                xmlContact.action = CommonHelper.ToGovXmlAction(clientContact.Action);

                Person xmlPerson = new Person();
                Organization xmlOrganization = new Organization();
                roles_ifc xmlRoles = new roles_ifc();

                xmlPerson.id = clientContact.PersonIdentifier;
                xmlPerson.familyName = clientContact.FamilyName;
                xmlPerson.givenName = clientContact.GivenName;
                if (clientContact.MiddleNames != null)
                {
                    xmlPerson.middleNames = new MiddleNames();
                    xmlPerson.middleNames.String = clientContact.MiddleNames.ToArray();
                }

                xmlPerson.fullName = clientContact.FullName;
                xmlContact.isPrimary = clientContact.IsPrimary;
                xmlOrganization.id = clientContact.PersonIdentifier;
                xmlOrganization.name = clientContact.BusinessName;
                //xmlOrganization.description=clientContact.OrganizationDescription;

                if (!IsBizVersion705(_bizServerVersion) && !IsBizVersion710(_bizServerVersion))
                {
                    xmlOrganization.contactBusinessName = clientContact.BusinessName;
                }

                if (clientContact.ContactRole != null)
                {
                    xmlRoles.actorRole = new ActorRole();
                    xmlRoles.actorRole.role = "userdefined";
                    Keys keys = KeysHelper.CreateXMLKeys(clientContact.ContactRole.Identifier);
                    if (keys != null && keys.key != null && keys.key.Length > 0 && !string.IsNullOrWhiteSpace(keys.key[0]))
                    {
                        xmlRoles.actorRole.userDefinedRole = keys.key[0];
                    }
                    else
                    {
                        xmlRoles.actorRole.userDefinedRole = clientContact.ContactRole.Display;
                    }
                }
                else
                {
                    throw new MobileException(MobileResources.GetString("contact_type_required"));
                }

                xmlPerson.addresses = new Addresses();
                xmlPerson.addresses.telecomAddress = new TelecomAddress();

                if (clientContact.Tels != null && clientContact.Tels.Count > 0)
                {
                    xmlPerson.addresses.telecomAddress.telephoneNumbers = new TelephoneNumbers();
                    xmlPerson.addresses.telecomAddress.telephoneNumbers.str = clientContact.Tels.ToArray();
                }

                if (clientContact.Faxs != null && clientContact.Faxs.Count > 0)
                {
                    xmlPerson.addresses.telecomAddress.facsimileNumbers = new FacsimileNumbers();
                    xmlPerson.addresses.telecomAddress.facsimileNumbers.str = clientContact.Faxs.ToArray();
                }

                if (clientContact.Emails != null && clientContact.Emails.Count > 0)
                {
                    xmlPerson.addresses.telecomAddress.electronicMailAddresses = new ElectronicMailAddresses();
                    xmlPerson.addresses.telecomAddress.electronicMailAddresses.str = clientContact.Emails.ToArray();
                }

                if (clientContact.Address != null)
                {
                    xmlPerson.OwnerAddress = AddressHelper.ToXmlOwnerAddress(clientContact.Address);
                }

                if (clientContact.MailingAddress != null)
                {
                    xmlPerson.addresses.postalAddress = AddressHelper.ToXmlPostalAddress(clientContact.MailingAddress);
                }

                //license
                if (clientContact.Licenses != null)
                {
                    xmlContact.licenses = new Licenses();
                    List<License> xmlItems = new List<License>();

                    foreach (var item in clientContact.Licenses)
                    {
                        var xmlItem = ToXMLLicense(item);
                        if (xmlItem != null)
                        {
                            xmlItems.Add(xmlItem);
                        }
                    }

                    xmlContact.licenses.license = xmlItems.ToArray();
                }


                if (string.IsNullOrWhiteSpace(xmlOrganization.id)
                    && string.IsNullOrWhiteSpace(xmlOrganization.name)
                    && string.IsNullOrWhiteSpace(xmlOrganization.description)
                    && string.IsNullOrWhiteSpace(xmlOrganization.contactBusinessName)
                    && xmlOrganization.addresses == null)
                {
                    xmlContact.person = xmlPerson;
                    xmlContact.person.roles = xmlRoles;
                }
                else
                {
                    xmlContact.personAndOrganization = new PersonAndOrganization();
                    xmlContact.personAndOrganization.thePerson = new ThePerson();
                    xmlContact.personAndOrganization.thePerson.person = xmlPerson;
                    xmlContact.personAndOrganization.thePerson.person.roles = xmlRoles;

                    xmlContact.personAndOrganization.theOrganization = new TheOrganization();
                    xmlContact.personAndOrganization.theOrganization.organization = xmlOrganization;
                }
            }

            return xmlContact;
        }

        public static Contact ToXMLSearchContact(ContactModel clientContact)
        {
            Contact xmlContact = null;

            if (clientContact != null)
            {
                xmlContact = new Contact();

                Person xmlPerson = new Person();

                xmlPerson.familyName = clientContact.FamilyName;
                xmlPerson.givenName = clientContact.GivenName;
                if (clientContact.MiddleNames != null)
                {
                    xmlPerson.middleNames = new MiddleNames();
                    xmlPerson.middleNames.String = clientContact.MiddleNames.ToArray();
                }

                xmlContact.person = xmlPerson;
            }

            return xmlContact;
        }

        public static LicensedProfessional ToClientLicense(License xmlLicense)
        {
            LicensedProfessional clientLicense = null;
            if (xmlLicense != null)
            {
                clientLicense = new LicensedProfessional();
                if (xmlLicense.licenseType != null)
                {
                    clientLicense.LicenseType = new LicenseTypeModel();
                    clientLicense.LicenseType.Identifier = KeysHelper.ToStringKeys(xmlLicense.AMOLicenseType.keys);
                    clientLicense.LicenseType.Display = xmlLicense.AMOLicenseType.identifierDisplay;
                }

                clientLicense.LicenseNumber = xmlLicense.licenseNumber;
                clientLicense.IssuedDate = xmlLicense.issuedDate;
                clientLicense.ExpirationDate = xmlLicense.expirationDate;
            }

            return clientLicense;
        }

        public static License ToXMLLicense(LicensedProfessional clientLicense)
        {
            License xmlLicense = null;
            if (clientLicense != null)
            {
                xmlLicense = new License();
                xmlLicense.action = CommonHelper.ToGovXmlAction(clientLicense.Action);
                if (clientLicense.LicenseType != null && clientLicense.LicenseType.Identifier != null)
                {
                    xmlLicense.AMOLicenseType = new Enumeration();
                    xmlLicense.AMOLicenseType.keys = KeysHelper.CreateXMLKeys(clientLicense.LicenseType.Identifier);
                    xmlLicense.licenseType = clientLicense.LicenseType.Display;
                }

                xmlLicense.licenseNumber = clientLicense.LicenseNumber;
                xmlLicense.issuedDate = clientLicense.IssuedDate;
                xmlLicense.expirationDate = clientLicense.ExpirationDate;
            }

            return xmlLicense;
        }

        public static Contact GetContact(Contacts xmlContacts)
        {
            Contact result = null;

            if (xmlContacts != null && xmlContacts.contact != null && xmlContacts.contact.Length > 0)
            {
                foreach (var contact in xmlContacts.contact)
                {
                    if (contact != null && !IsLicensedProfessional(contact))
                    {
                        bool isPrimary = "true".Equals(contact.isPrimary, StringComparison.OrdinalIgnoreCase);

                        if (isPrimary)
                        {
                            result = contact;
                            break;
                        }

                        if (!isPrimary && result == null)
                        {
                            result = contact;
                        }
                    }
                }
            }

            return result;
        }

        public ContactModel ToClientContact(Contact xmlContact)
        {
            ContactModel clientContact = null;
            if (xmlContact != null)
            {
                clientContact = new ContactModel();
                clientContact.Identifier = KeysHelper.ToStringKeys(xmlContact.keys);

                Person xmlPerson = new Person();
                Organization xmlOrganization = new Organization();
                if (xmlContact.person != null)
                {
                    xmlPerson = xmlContact.person;
                }
                else if (xmlContact.personAndOrganization != null)
                {
                    xmlPerson = xmlContact.personAndOrganization.thePerson.person;
                    xmlOrganization = xmlContact.personAndOrganization.theOrganization.organization;
                }
                else if (xmlContact.organization != null)
                {
                    xmlOrganization = xmlContact.organization;
                    xmlPerson.addresses = xmlOrganization.addresses;
                    xmlPerson.roles = xmlOrganization.roles;
                }
                else
                {
                    return null;
                }

                clientContact.PersonIdentifier = xmlPerson.id;
                clientContact.FamilyName = xmlPerson.familyName;
                clientContact.GivenName = xmlPerson.givenName;
                if (xmlPerson.middleNames != null && xmlPerson.middleNames.String != null)
                {
                    clientContact.MiddleNames = xmlPerson.middleNames.String.ToList();
                }

                clientContact.FullName = xmlPerson.fullName;
                clientContact.IsPrimary = xmlContact.isPrimary;
                clientContact.BusinessName = !String.IsNullOrWhiteSpace(xmlOrganization.contactBusinessName) ? xmlOrganization.contactBusinessName : xmlOrganization.name;

                if (String.IsNullOrEmpty(clientContact.BusinessName))
                {
                    clientContact.BusinessName = xmlPerson.businessName1;
                }

                if (string.IsNullOrWhiteSpace(clientContact.PersonIdentifier))
                {
                    clientContact.PersonIdentifier = xmlOrganization.id;
                }

                // clientContact.OrganizationDescription = xmlOrganization.description;

                //Role
                if (xmlPerson.roles != null &&
                    xmlPerson.roles.actorRole != null &&
                    xmlPerson.roles.actorRole.role != null)
                {
                    clientContact.ContactRole = new ContactRoleModel();
                    // Case by I18n request
                    if (xmlPerson.roles.actorRole.userDefinedRoleId != null)
                    {
                        clientContact.ContactRole.Identifier = KeysHelper.ToStringKeys(xmlPerson.roles.actorRole.userDefinedRoleId.keys);
                        clientContact.ContactRole.Display = xmlPerson.roles.actorRole.userDefinedRoleId.identifierDisplay;
                    }
                    else if (xmlPerson.roles.actorRole.role.ToLower() == "userdefined")
                    {
                        clientContact.ContactRole.Display = xmlPerson.roles.actorRole.userDefinedRole;
                        clientContact.ContactRole.Identifier = xmlPerson.roles.actorRole.userDefinedRole;
                    }
                    else
                    {
                        clientContact.ContactRole.Display = xmlPerson.roles.actorRole.role;
                        clientContact.ContactRole.Identifier = xmlPerson.roles.actorRole.role;
                    }
                }


                /*
                
                 * Implementation Notes:
                         
                 * In current version of GovXML
                 * For owner, email element within Person represents the email address.
                 * For contact, electronicMailAddresses element within TelecomAddress represents the email address.
                 * 
                 * These two fields cannot exist simultaneously.
                //*/
                if (xmlPerson.addresses != null)
                {
                    if (xmlPerson.addresses.postalAddress != null)
                    {                        
                        clientContact.CountryCode = xmlPerson.addresses.postalAddress.countryCode;
                    }

                    if (xmlPerson.addresses.telecomAddress != null)
                    {
                        //Phone
                        if (xmlPerson.addresses.telecomAddress.telephoneNumbers != null &&
                            xmlPerson.addresses.telecomAddress.telephoneNumbers.str != null &&
                            xmlPerson.addresses.telecomAddress.telephoneNumbers.str.Length > 0)
                        {
                            clientContact.Tels = xmlPerson.addresses.telecomAddress.telephoneNumbers.str.ToList();
                        }

                        if (xmlPerson.addresses.telecomAddress.phoneCountryCodes != null &&
                            xmlPerson.addresses.telecomAddress.phoneCountryCodes.str != null &&
                            xmlPerson.addresses.telecomAddress.phoneCountryCodes.str.Length > 0)
                        {
                            clientContact.TelCountryCodes = xmlPerson.addresses.telecomAddress.phoneCountryCodes.str.ToList();
                        }                        

                        //FAX
                        if (xmlPerson.addresses.telecomAddress.facsimileNumbers != null &&
                            xmlPerson.addresses.telecomAddress.facsimileNumbers.str != null &&
                            xmlPerson.addresses.telecomAddress.facsimileNumbers.str.Length > 0)
                        {
                            clientContact.Faxs = xmlPerson.addresses.telecomAddress.facsimileNumbers.str.ToList();
                        }

                        if (xmlPerson.addresses.telecomAddress.facsimileCountryCodes != null &&
                            xmlPerson.addresses.telecomAddress.facsimileCountryCodes.str != null &&
                            xmlPerson.addresses.telecomAddress.facsimileCountryCodes.str.Length > 0)
                        {
                            clientContact.FaxCountryCodes = xmlPerson.addresses.telecomAddress.facsimileCountryCodes.str.ToList();
                        }

                        //Email
                        if (xmlPerson.addresses.telecomAddress.electronicMailAddresses != null &&
                            xmlPerson.addresses.telecomAddress.electronicMailAddresses.str != null)
                        {
                            clientContact.Emails = xmlPerson.addresses.telecomAddress.electronicMailAddresses.str.ToList();
                        }
                    }

                    //MailingAddress
                    if (xmlPerson.addresses.postalAddress != null)
                    {
                        clientContact.MailingAddress = AddressHelper.ToClientAddress(xmlPerson.addresses.postalAddress);
                    }
                }

                if (xmlPerson.OwnerAddress != null)
                {
                    clientContact.Address = AddressHelper.ToClientAddress(xmlPerson.OwnerAddress);
                }

                if (xmlPerson.email != null)
                {
                    clientContact.Emails = new List<string> { xmlPerson.email };
                }

                //Confirm with GovXML(Evan) xmlOrganization should is contact's address 
                if (clientContact.MailingAddress == null
                    && xmlOrganization.addresses != null
                    && xmlOrganization.addresses.detailAddress != null
                    && xmlOrganization.addresses.detailAddress.Length > 0)
                {

                    clientContact.MailingAddress = AddressHelper.ToClientAddress(xmlOrganization.addresses.detailAddress[0]);
                }

                //license
                if (xmlContact.licenses != null && xmlContact.licenses.license != null && xmlContact.licenses.license.Length > 0)
                {
                    clientContact.Licenses = new List<LicensedProfessional>();
                    foreach (var item in xmlContact.licenses.license)
                    {
                        clientContact.Licenses.Add(ToClientLicense(item));
                    }
                }
            }

            return clientContact;
        }

        public static ContactModel GetContact(ContactModel[] contactModelArray)
        {
            ContactModel result = null;

            if (contactModelArray != null && contactModelArray.Length > 0)
            {
                foreach (var contact in contactModelArray)
                {
                    if (contact != null && !IsLicensedProfessional(contact))
                    {
                        bool isPrimary = "true".Equals(contact.IsPrimary, StringComparison.OrdinalIgnoreCase);

                        if (isPrimary)
                        {
                            result = contact;
                            break;
                        }

                        if (!isPrimary && result == null)
                        {
                            result = contact;
                        }
                    }
                }
            }

            return result;
        }

        public static OwnerModel ToClientOwner(ContactModel contactModel)
        {
            OwnerModel result = null;

            if (contactModel != null)
            {
                result = new OwnerModel()
                {
                    Action = contactModel.Action,
                    Emails = contactModel.Emails,
                    Faxs = contactModel.Faxs,
                    FaxCountryCodes = contactModel.FaxCountryCodes,
                    GivenName = contactModel.GivenName,
                    FamilyName = contactModel.FamilyName,
                    MiddleNames = contactModel.MiddleNames,
                    FullName = ContactHelper.ToContactName(contactModel),
                    Id = contactModel.Identifier,
                    IsPrimary = contactModel.IsPrimary,
                    Address = contactModel.Address,
                    MailingAddress = contactModel.MailingAddress,
                    PersonId = contactModel.PersonIdentifier,
                    Tels = contactModel.Tels,
                    TelCountryCodes = contactModel.TelCountryCodes,
                    CountryCode = contactModel.CountryCode
                };
            }

            return result;
        }

        public static string ToContactName(Contact contact)
        {
            string contactName = string.Empty;

            if (contact != null && contact.person != null)
            {
                contactName = CommonHelper.GetPersonName(contact.person);
            }

            return contactName;
        }

        public static string ToContactName(ContactModel contactModel)
        {
            string contactName = string.Empty;

            if (contactModel != null)
            {
                var middleNameArray = contactModel.MiddleNames != null && contactModel.MiddleNames.Count > 0 ? contactModel.MiddleNames.ToArray() : null;
                contactName = CommonHelper.GetFullName(contactModel.FullName, contactModel.GivenName, middleNameArray, contactModel.FamilyName);
            }

            return contactName;
        }

        public static bool IsLicensedProfessional(Contact contact)
        {
            bool result = false;

            if (contact != null && contact.licenses != null && contact.licenses.license != null && contact.licenses.license.Length > 0
                    && contact.personAndOrganization != null && contact.personAndOrganization.thePerson != null
                    && contact.personAndOrganization.thePerson.person != null)
            {
                result = true;
            }

            return result;
        }

        public static bool IsLicensedProfessional(ContactModel contact)
        {
            bool result = false;

            if (contact != null && contact.Licenses != null && contact.Licenses.Count > 0)
            {
                result = true;
            }

            return result;
        }

        public static IList<ContactRoleModel> GetClientContactTypes(GetRolesResponse getRolesResponse)
        {
            IList<ContactRoleModel> contactTypes = new List<ContactRoleModel>();

            if (getRolesResponse == null)
            {
                return contactTypes;
            }

            if (getRolesResponse.roles == null)
            {
                return contactTypes;
            }

            if (getRolesResponse.roles.AMORoleType != null)
            {
                if (getRolesResponse.roles.AMORoleType.AMOEnumeration != null)
                {
                    foreach (var type in getRolesResponse.roles.AMORoleType.AMOEnumeration)
                    {
                        contactTypes.Add(new ContactRoleModel
                        {
                            Identifier = KeysHelper.ToStringKeys(type.keys),
                            Display = type.identifierDisplay
                        });
                    }
                }
            }
            else
            {
                if (getRolesResponse.roles.role != null)
                {
                    foreach (var type in getRolesResponse.roles.role)
                    {
                        contactTypes.Add(new ContactRoleModel
                        {
                            Identifier = type,
                            Display = type
                        });
                    }
                }
            }

            return contactTypes;
        }
    }
}
