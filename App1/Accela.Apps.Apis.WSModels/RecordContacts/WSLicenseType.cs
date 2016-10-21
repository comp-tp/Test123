using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;

namespace Accela.Apps.Apis.WSModels.RecordContacts
{
    [DataContract]
    public class WSLicenseType : WSIdentifierBase
    {
        /// <summary>
        /// Convert domain LicenseTypeModel to WSLicenseType. 
        /// </summary>
        /// <param name="licenseTypeModel">LicenseTypeModel.</param>
        /// <returns>WSLicenseType.</returns>
        public static WSLicenseType FromEntityModel(LicenseTypeModel licenseTypeModel)
        {
            if (licenseTypeModel != null)
            {
                return new WSLicenseType()
                {
                    Id = licenseTypeModel.Identifier,
                    Display = licenseTypeModel.Display
                };
            }
            return null;
        }

        /// <summary>
        /// Convert WSLicenseType to LicenseTypeModel.
        /// </summary>
        /// <param name="wsLicenseType">WSLicenseType.</param>
        /// <returns>LicenseTypeModel.</returns>
        public static LicenseTypeModel ToEntityModel(WSLicenseType wsLicenseType)
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
