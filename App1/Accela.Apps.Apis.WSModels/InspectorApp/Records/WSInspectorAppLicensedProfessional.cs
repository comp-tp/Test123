using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract]
    public class WSInspectorAppLicensedProfessional : WSEntityState
    {
        [DataMember(Name = "licenseType", EmitDefaultValue = false)]
        public WSInspectorAppLicenseType LicenseType { get; set; }
        [DataMember(Name = "licenseNumber", EmitDefaultValue = false)]
        public string LicenseNumber { get; set; }
        [DataMember(Name = "issuedDate", EmitDefaultValue = false)]
        public string IssuedDate { get; set; }
        [DataMember(Name = "expirationDate", EmitDefaultValue = false)]
        public string ExpirationDate { get; set; }

        /// <summary>
        /// Convert LicensedProfessional to WSInspectorAppLicensedProfessional.
        /// </summary>
        /// <param name="licensedProfessional">LicensedProfessional.</param>
        /// <returns>WSInspectorAppLicensedProfessional.</returns>
        public static WSInspectorAppLicensedProfessional FromEntityModel(LicensedProfessional licensedProfessional)
        {
            if (licensedProfessional != null)
            {
                return new WSInspectorAppLicensedProfessional()
                {
                    LicenseType = WSInspectorAppLicenseType.FromEntityModel(licensedProfessional.LicenseType),
                    LicenseNumber = licensedProfessional.LicenseNumber,
                    IssuedDate = licensedProfessional.IssuedDate,
                    ExpirationDate = licensedProfessional.ExpirationDate,
                    EntityState = WSEntityState.ConvertActionToEntityState(licensedProfessional.Action)
                };
            }
            return null;
        }

        /// <summary>
        /// Convert LicensedProfessional list to WSInspectorAppLicensedProfessional list.
        /// </summary>
        /// <param name="licensedProfessionals">LicensedProfessional list.</param>
        /// <returns>WSInspectorAppLicensedProfessional list.</returns>
        public static List<WSInspectorAppLicensedProfessional> FromEntityModels(List<LicensedProfessional> licensedProfessionals)
        {
            if (licensedProfessionals != null && licensedProfessionals.Count > 0)
            {
                var wsLicensedProfessionals = new List<WSInspectorAppLicensedProfessional>();
                foreach (var licensedProfessional in licensedProfessionals)
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
        /// <param name="wsLicensedProfessional">WSInspectorAppLicensedProfessional.</param>
        /// <returns>LicensedProfessional.</returns>
        public static LicensedProfessional ToEntityModel(WSInspectorAppLicensedProfessional wsLicensedProfessional)
        {
            if (wsLicensedProfessional != null)
            {
                return new LicensedProfessional()
                {
                    LicenseType = WSInspectorAppLicenseType.ToEntityModel(wsLicensedProfessional.LicenseType),
                    LicenseNumber = wsLicensedProfessional.LicenseNumber,
                    IssuedDate = wsLicensedProfessional.IssuedDate,
                    ExpirationDate = wsLicensedProfessional.ExpirationDate,
                    Action = WSEntityState.ConvertEntityStateToAction(wsLicensedProfessional.EntityState)
                };
            }
            return null;
        }

        public static List<LicensedProfessional> ToEntityModels(List<WSInspectorAppLicensedProfessional> wsLicensedProfessionals)
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
