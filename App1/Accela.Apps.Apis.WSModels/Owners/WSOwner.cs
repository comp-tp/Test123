using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.WSModels.Addresses;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.WSModels.Owners
{
    [DataContract(Name = "owner")]
    public class WSOwner : WSEntityState
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

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

        [DataMember(Name = "isPrimary", EmitDefaultValue = false)]
        public string IsPrimary { get; set; }

        [DataMember(Name = "address", EmitDefaultValue = false)]
        public WSAddress Address { get; set; }

        [DataMember(Name = "mailingAddress", EmitDefaultValue = false)]
        public WSAddress MailingAddress { get; set; }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="wsModels">The web service models.</param>
        /// <returns>the entity models.</returns>
        public static OwnerModel[] ToEntityModels(WSOwner[] wsModels)
        {
            if (wsModels == null)
            {
                return null;
            }

            var result = wsModels.Select(m => ToEntityModel(m)).ToArray();
            return result;
        }

        /// <summary>
        /// Froms the entity models.
        /// </summary>
        /// <param name="entityModels">The entity models.</param>
        /// <returns>the entity models.</returns>
        public static WSOwner[] FromEntityModels(OwnerModel[] entityModels)
        {
            if (entityModels == null)
            {
                return null;
            }

            var result = entityModels.Select(m => FromEntityModel(m)).ToArray();
            return result;
        }

        /// <summary>
        /// Converts to the entity contact model.
        /// </summary>
        /// <param name="ownerModel">The owner model.</param>
        /// <returns>The entity contact model.</returns>
        public static ContactModel ToEntityContactModel(WSOwner ownerModel)
        {
            ContactModel result = null;

            if (ownerModel != null)
            {
                result = new ContactModel()
                {
                    ContactRole = new ContactRoleModel()
                    {
                        Display = "Owner",
                        Identifier = "Owner"
                    },
                    //Action = ownerModel.Action,
                    Emails = ownerModel.Emails,
                    Faxs = ownerModel.Faxs,                    
                    GivenName = ownerModel.GivenName,
                    FamilyName = ownerModel.FamilyName,
                    MiddleNames = ownerModel.MiddleNames,
                    FullName = ownerModel.FullName,
                    Identifier = ownerModel.Id,
                    IsPrimary = ownerModel.IsPrimary,
                    Address = WSAddress.ToEntityModel(ownerModel.Address),
                    MailingAddress = WSAddress.ToEntityModel(ownerModel.MailingAddress),
                    PersonIdentifier = ownerModel.PersonId,
                    Tels = ownerModel.Tels,                    
                    Action = WSEntityState.ConvertEntityStateToAction(ownerModel.EntityState)
                };
            }

            return result;
        }

        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">The web service model.</param>
        /// <returns>The entity model.</returns>
        public static OwnerModel ToEntityModel(WSOwner wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new OwnerModel()
            {
                Id = wsModel.Id,
                PersonId = wsModel.PersonId,
                FamilyName = wsModel.FamilyName,
                GivenName = wsModel.GivenName,
                MiddleNames = wsModel.MiddleNames,
                FullName = wsModel.FullName,
                Tels = wsModel.Tels,
                Faxs = wsModel.Faxs,
                Emails = wsModel.Emails,
                IsPrimary = wsModel.IsPrimary,
                Address = WSAddress.ToEntityModel(wsModel.Address),
                MailingAddress = WSAddress.ToEntityModel(wsModel.MailingAddress),
                Action = WSEntityState.ConvertEntityStateToAction(wsModel.EntityState)
            };

            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSOwner FromEntityModel(OwnerModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSOwner()
            {
                Id = entityModel.Id,
                PersonId = entityModel.PersonId,
                FamilyName = entityModel.FamilyName,
                GivenName = entityModel.GivenName,
                MiddleNames = entityModel.MiddleNames,
                FullName = entityModel.FullName,
                Tels = entityModel.Tels,
                TelCountryCodes = entityModel.TelCountryCodes,
                CountryCode = entityModel.CountryCode,
                Faxs = entityModel.Faxs,
                FaxCountryCodes = entityModel.FaxCountryCodes,
                Emails = entityModel.Emails,
                IsPrimary = entityModel.IsPrimary,
                Address = WSAddress.FromEntityModel(entityModel.Address),
                MailingAddress = WSAddress.FromEntityModel(entityModel.MailingAddress),
                EntityState = WSEntityState.ConvertActionToEntityState(entityModel.Action)
            };

            return result;
        }
    }
}
