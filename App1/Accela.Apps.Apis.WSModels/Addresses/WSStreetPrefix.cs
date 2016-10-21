using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.WSModels.Addresses
{
    [DataContract(Name = "streetPrefix")]
    public class WSStreetPrefix : WSIdentifierBase
    {
        /// <summary>
        /// Convert StreetPrefixModel to BasicStreetPrefix.
        /// </summary>
        /// <param name="streetPrefixModel">streetPrefixModel.</param>
        /// <returns>BasicStreetPrefix.</returns>
        public static WSStreetPrefix FromEntityModel(StreetPrefixModel streetPrefixModel)
        {
            if (streetPrefixModel != null)
            {
                return new WSStreetPrefix()
                {
                    Id = streetPrefixModel.Identifier,
                    Display = streetPrefixModel.Display
                };
            }

            return null;
        }
    }
}
