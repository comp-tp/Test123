using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.PartModels;

namespace Accela.Apps.Apis.WSModels.Parts
{
    [DataContract(Name = "partBrand")]
    public class WSPartBrand : WSIdentifierBase
    {
        /// <summary>
        /// Convert PartBrandModel to WSPartBrand.
        /// </summary>
        /// <param name="partBrandIdModel">partBrandIdModel.</param>
        /// <returns>WSPartBrand.</returns>
        public static WSPartBrand FromEntityModel(PartBrandModel partBrandIdModel)
        {
            if (partBrandIdModel == null)
            {
                return null;
            }

            return new WSPartBrand()
            {
                Id = partBrandIdModel.Identifier,
                Display = partBrandIdModel.Display
            };
        }

        public static PartBrandModel ToEntityModel(WSPartBrand wsPartBrand)
        {
            if (wsPartBrand == null)
            {
                return null;
            }

            return new PartBrandModel
            {
                Identifier = wsPartBrand.Id,
                Display = wsPartBrand.Display
            };
        }
    }
}
