using System;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.GISModels;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Automation.GovXmlClient.Model;


namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    public class OwnerHelper
    {
        private string _bizServerVersion;

        public OwnerHelper(string bizServerVersion)
        {
            if (String.IsNullOrEmpty(bizServerVersion))
            {
                throw new ArgumentNullException("bizServerVersion cannot be null.");
            }

            _bizServerVersion = bizServerVersion;
        }

        /// <summary>
        /// Toes the XML query contacts.
        /// </summary>
        /// <param name="clientOwners">The client owners.</param>
        /// <param name="user">The user.</param>
        /// <returns>the XML query contacts.</returns>
        internal static Contacts ToXMLQueryContacts(List<OwnerModel> clientOwners)
        {
            if (clientOwners == null)
            {
                return null;
            }

            var xmlContacts = new List<Contact>();

            foreach (var item in clientOwners)
            {
                Contact xmlContact = ToXMLQueryContact(item);

                if (xmlContact != null)
                {
                    xmlContacts.Add(xmlContact);
                }
            }

            var result = new Contacts();
            result.contact = xmlContacts.ToArray();

            return result;
        }

        /// <summary>
        /// Toes the XML query contact.
        /// </summary>
        /// <param name="clientOwner">The client owner.</param>
        /// <param name="user">The user.</param>
        /// <returns>the XML query contact.</returns>
        internal static Contact ToXMLQueryContact(OwnerModel clientOwner)
        {
            if (clientOwner == null)
            {
                return null;
            }

            var xmlContact = new Contact();
            xmlContact.keys = KeysHelper.CreateXMLKeys(clientOwner.Id);
            xmlContact.action = CommonHelper.ToGovXmlAction(clientOwner.Action);

            Person xmlPerson = new Person();
            xmlPerson.id = clientOwner.PersonId;
            xmlPerson.familyName = clientOwner.FamilyName;
            xmlPerson.givenName = clientOwner.GivenName;

            if (clientOwner.MiddleNames != null)
            {
                xmlPerson.middleNames = new MiddleNames();
                xmlPerson.middleNames.String = clientOwner.MiddleNames.ToArray();
            }

            xmlPerson.fullName = clientOwner.FullName;
            xmlContact.person = xmlPerson;
            xmlContact.isPrimary = clientOwner.IsPrimary;

            return xmlContact;
        }

        /// <summary>
        /// Toes the XML query GIS objects.
        /// </summary>
        /// <param name="clientGISObjects">The client GIS objects.</param>
        /// <returns>
        /// the XML query GIS objects.
        /// </returns>
        internal static GISObjects ToXMLQueryGISObjects(List<GISObjectModel> clientGISObjects)
        {
            if (clientGISObjects == null)
            {
                return null;
            }

            var xmlContacts = new List<GISObject>();

            foreach (var item in clientGISObjects)
            {
                var xmlContact = new GISObject();
                xmlContact.Keys = KeysHelper.CreateXMLKeys(item.Id);

                xmlContact.GISLayerId = new GISLayerId();
                xmlContact.GISLayerId.Keys = KeysHelper.CreateXMLKeys(item.GISLayerId);

                xmlContact.MapServerID = new MapServerID();
                xmlContact.MapServerID.Keys = KeysHelper.CreateXMLKeys(item.MapServiceId);

                xmlContacts.Add(xmlContact);
            }

            var result = new GISObjects();
            result.GISObject = xmlContacts.ToArray();

            return result;
        }

        public OwnersResponse ToClientOwners(GetOwnersResponse getOwnersResponse)
        {
            if (getOwnersResponse == null)
            {
                return null;
            }

            var result = new OwnersResponse();

            if (getOwnersResponse.system != null)
            {
                result.PageInfo = CommonHelper.GetPaginationFromSystem(getOwnersResponse.system);
                result.Events = CommonHelper.GetClientEventMessage(getOwnersResponse.system.eventMessages);
            }

            if (getOwnersResponse.Contacts != null
                && getOwnersResponse.Contacts.contact != null
                && getOwnersResponse.Contacts.contact.Length > 0)
            {
                result.Owners = new List<OwnerModel>();
                ContactHelper _contactHelper = new ContactHelper(_bizServerVersion);
                foreach (var contact in getOwnersResponse.Contacts.contact)
                {
                    var contactModel = _contactHelper.ToClientContact(contact);
                    var ownerModel = ContactHelper.ToClientOwner(contactModel);
                    result.Owners.Add(ownerModel);
                }
            }

            return result;
        }
    }
}
