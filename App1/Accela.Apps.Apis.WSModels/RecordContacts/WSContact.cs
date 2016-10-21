﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.Addresses;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.WSModels.RecordContacts
{
    [DataContract]
    public class WSContact : WSEntityState
    {
        /// <summary>
        /// Gets or sets the address Id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the address display.
        /// </summary>
        [DataMember(Name = "personId", EmitDefaultValue = false)]
        public string PersonId { get; set; }

        [DataMember(Name = "familyName", EmitDefaultValue = false)]
        public string FamilyName { get; set; }

        [DataMember(Name = "givenName", EmitDefaultValue = false)]
        public string GivenName { get; set; }

        [DataMember(Name = "middleNames", EmitDefaultValue = false)]
        public List<string> MiddleNames { get; set; }

        [DataMember(Name = "fullName", EmitDefaultValue = false)]
        public string FullName { get; set; }

        [DataMember(Name = "tels", EmitDefaultValue = false)]
        public List<string> Tels { get; set; }

        [DataMember(Name = "telCountryCodes", EmitDefaultValue = false)]
        public List<string> TelCountryCodes { get; set; }

        [DataMember(Name = "countryCode", EmitDefaultValue = false)]
        public string CountryCode { get; set; }

        [DataMember(Name = "faxs", EmitDefaultValue = false)]
        public List<string> Faxs { get; set; }

        [DataMember(Name = "faxCountryCodes", EmitDefaultValue = false)]
        public List<string> FaxCountryCodes { get; set; }

        [DataMember(Name = "emails", EmitDefaultValue = false)]
        public List<string> Emails { get; set; }

        [DataMember(Name = "contactRole", EmitDefaultValue = false)]
        public WSContactRole ContactRole { get; set; }

        [DataMember(Name = "businessName", EmitDefaultValue = false)]
        public string BusinessName { get; set; }

        [DataMember(Name = "isPrimary", EmitDefaultValue = false)]
        public string IsPrimary { get; set; }
  
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public WSCompactAddress Address { get; set; }

        [DataMember(Name = "licenses", EmitDefaultValue = false)]
        public List<WSLicensedProfessional> Licenses { get; set; }

        //[DataMember(Name = "organizationID", EmitDefaultValue = false)]
        //public string OrganizationID { get; set; }

        //[DataMember(Name = "organizationName", EmitDefaultValue = false)]
        //public string OrganizationName { get; set; }

        //[DataMember(Name = "organizationDescription", EmitDefaultValue = false)]
        //public string OrganizationDescription { get; set; }

        //[DataMember(Name = "orgnizationAddresses", EmitDefaultValue = false)]
        //public List<WSAddress> OrgnizationAddresses { get; set; }

        public static List<WSContact> FromEntityModels(List<ContactModel> contactModels)
        {
            List<WSContact> retu=null;
            if (contactModels != null)
            {
                retu = new List<WSContact>();
                foreach (var item in contactModels)
                {
                    retu.Add(FromEntityModel(item));
                }
            }

            return retu;
        }

        /// <summary>
        /// Convert ContactModel to WSContact.
        /// </summary>
        /// <param name="contactModel">ContactModel.</param>
        /// <returns>WSContact.</returns>
        public static WSContact FromEntityModel(ContactModel contactModel)
        {
            if (contactModel != null)
            {
                return new WSContact() 
                {
                    Id = contactModel.Identifier,
                    PersonId = contactModel.PersonIdentifier,                    
                    FamilyName = contactModel.FamilyName,
                    GivenName = contactModel.GivenName,
                    MiddleNames = contactModel.MiddleNames,
                    FullName = contactModel.FullName,        
                    Tels = contactModel.Tels,
                    TelCountryCodes = contactModel.TelCountryCodes,
                    Faxs = contactModel.Faxs,
                    FaxCountryCodes = contactModel.FaxCountryCodes,
                    Emails = contactModel.Emails,   
                    CountryCode = contactModel.CountryCode,
                    ContactRole = WSContactRole.FromEntityModel(contactModel.ContactRole),        
                    BusinessName = contactModel.BusinessName,
                    IsPrimary = contactModel.IsPrimary,
                    //OrganizationID = contactModel.OrganizationID,
                    //OrganizationName = contactModel.OrganizationName,
                    //OrganizationDescription = contactModel.OrganizationDescription,
                    //OrgnizationAddresses = WSAddress.FromEntityModels(contactModel.OrgnizationAddresses),
                    Address = WSCompactAddress.FromEntityModel(contactModel.MailingAddress),
                    Licenses = WSLicensedProfessional.FromEntityModels(contactModel.Licenses),
                    EntityState = ConvertActionToEntityState(contactModel.Action)
                };
            }
            return null;
        }

        /// <summary>
        /// Convert WSContact to ContactModel.
        /// </summary>
        /// <param name="wsContact">WSContact.</param>
        /// <returns>ContactModel.</returns>
        public static ContactModel ToEnityModel(WSContact wsContact)
        {
            if (wsContact != null)
            {
                return new ContactModel()
                {
                    Identifier = wsContact.Id,
                    PersonIdentifier = wsContact.PersonId,
                    FamilyName = wsContact.FamilyName,
                    GivenName = wsContact.GivenName,
                    MiddleNames = wsContact.MiddleNames,
                    FullName = wsContact.FullName,
                    Tels = wsContact.Tels,
                    Faxs = wsContact.Faxs,
                    Emails = wsContact.Emails,
                    ContactRole = WSContactRole.ToEntityModel(wsContact.ContactRole),
                    BusinessName = wsContact.BusinessName,
                    IsPrimary = wsContact.IsPrimary,
                    //OrganizationID = wsContact.OrganizationID,
                    //OrganizationName = wsContact.OrganizationName,
                    //OrganizationDescription = wsContact.OrganizationDescription,
                    //OrgnizationAddresses = WSAddress.ToEntityModels(wsContact.OrgnizationAddresses),
                    MailingAddress = WSCompactAddress.ToEntityModel(wsContact.Address),
                    Licenses = WSLicensedProfessional.ToEntityModels(wsContact.Licenses),
                    Action = WSEntityState.ConvertEntityStateToAction(wsContact.EntityState)
                };
            }
            return null;
        }
        
    }
}
