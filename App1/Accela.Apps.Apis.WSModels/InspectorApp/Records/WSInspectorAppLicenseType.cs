using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract]
    public class WSInspectorAppLicenseType : WSIdentifierBase
    {
        /// <summary>
        /// Convert domain LicenseTypeModel to WSInspectorAppLicenseType. 
        /// </summary>
        /// <param name="licenseTypeModel">LicenseTypeModel.</param>
        /// <returns>WSInspectorAppLicenseType.</returns>
        public static WSInspectorAppLicenseType FromEntityModel(LicenseTypeModel licenseTypeModel)
        {
            if (licenseTypeModel != null)
            {
                return new WSInspectorAppLicenseType()
                {
                    Id = licenseTypeModel.Identifier,
                    Display = licenseTypeModel.Display
                };
            }
            return null;
        }

        /// <summary>
        /// Convert WSInspectorAppLicenseType to LicenseTypeModel.
        /// </summary>
        /// <param name="wsLicenseType">WSInspectorAppLicenseType.</param>
        /// <returns>LicenseTypeModel.</returns>
        public static LicenseTypeModel ToEntityModel(WSInspectorAppLicenseType wsLicenseType)
        {
            if (wsLicenseType != null)
            {
                return new LicenseTypeModel()
                {
                    Identifier = wsLicenseType.Id,
                    Display = wsLicenseType.Display
                };
            }
            return null;
        }
    }
}
