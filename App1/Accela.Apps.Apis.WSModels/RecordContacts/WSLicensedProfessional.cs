using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.WSModels.RecordContacts
{
    [DataContract]
    public class WSLicensedProfessional : WSEntityState
    {
        [DataMember(Name = "licenseType", EmitDefaultValue = false)]
        public WSLicenseType LicenseType { get; set; }
        [DataMember(Name = "licenseNumber", EmitDefaultValue = false)]
        public string LicenseNumber { get; set; }
        [DataMember(Name = "issuedDate", EmitDefaultValue = false)]
        public string IssuedDate { get; set; }
        [DataMember(Name = "expirationDate", EmitDefaultValue = false)]
        public string ExpirationDate { get; set; }

        /// <summary>
        /// Convert LicensedProfessional to WSLicensedProfessional.
        /// </summary>
        /// <param name="licensedProfessional">LicensedProfessional.</param>
        /// <returns>WSLicensedProfessional.</returns>
        public static WSLicensedProfessional FromEntityModel(LicensedProfessional licensedProfessional)
        {
            if (licensedProfessional != null)
            {
                return new WSLicensedProfessional() 
                {
                    LicenseType = WSLicenseType.FromEntityModel(licensedProfessional.LicenseType),
                    LicenseNumber = licensedProfessional.LicenseNumber,
                    IssuedDate = licensedProfessional.IssuedDate,
                    ExpirationDate = licensedProfessional.ExpirationDate,
                    EntityState = WSEntityState.ConvertActionToEntityState(licensedProfessional.Action)
                };
            }
            return null;
        }

        /// <summary>
        /// Convert LicensedProfessional list to WSLicensedProfessional list.
        /// </summary>
        /// <param name="licensedProfessionals">LicensedProfessional list.</param>
        /// <returns>WSLicensedProfessional list.</returns>
        public static List<WSLicensedProfessional> FromEntityModels(List<LicensedProfessional> licensedProfessionals)
        {
            if (licensedProfessionals != null && licensedProfessionals.Count > 0)
            {
                var wsLicensedProfessionals = new List<WSLicensedProfessional>();
                foreach(var licensedProfessional in licensedProfessionals)
                {
                    wsLicensedProfessionals.Add(FromEntityModel(licensedProfessional));
                }
                return wsLicensedProfessionals;
            }
            return null;
        }

        /// <summary>
        /// Convert LicensedProfessional to LicensedProfessional.
        /// </summary>
        /// <param name="wsLicensedProfessional">WSLicensedProfessional.</param>
        /// <returns>LicensedProfessional.</returns>
        public static LicensedProfessional ToEntityModel(WSLicensedProfessional wsLicensedProfessional)
        {
            if (wsLicensedProfessional != null)
            {
                return new LicensedProfessional() 
                {
                    LicenseType = WSLicenseType.ToEntityModel(wsLicensedProfessional.LicenseType),
                    LicenseNumber = wsLicensedProfessional.LicenseNumber,
                    IssuedDate = wsLicensedProfessional.IssuedDate,
                    ExpirationDate = wsLicensedProfessional.ExpirationDate,
                    Action = WSEntityState.ConvertEntityStateToAction(wsLicensedProfessional.EntityState)
                };
            }
            return null;
        }

        public static List<LicensedProfessional> ToEntityModels(List<WSLicensedProfessional> wsLicensedProfessionals)
        {
            if (wsLicensedProfessionals != null && wsLicensedProfessionals.Count > 0)
            {
                var licensedProfessionals = new List<LicensedProfessional>();
                foreach (var wsLicensedProfessional in wsLicensedProfessionals)
                {
                    licensedProfessionals.Add(ToEntityModel(wsLicensedProfessional));
                }
                return licensedProfessionals;
            }
            return null;
        }
    }
}
