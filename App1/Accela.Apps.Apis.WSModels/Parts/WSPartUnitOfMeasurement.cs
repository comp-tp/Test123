using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.PartModels;

namespace Accela.Apps.Apis.WSModels.Parts
{
    [DataContract(Name = "partUnitOfMeasurement")]
    public class WSPartUnitOfMeasurement : WSIdentifierBase
    {
        /// <summary>
        /// Convert PartUnitOfMeasurementModel to WSPartUnitOfMeasurement.
        /// </summary>
        /// <param name="partUnitOfMeasurementModel">partUnitOfMeasurementModel.</param>
        /// <returns>WSPartUnitOfMeasurement.</returns>
        public static WSPartUnitOfMeasurement FromEntityModel(PartUnitOfMeasurementModel partUnitOfMeasurementModel)
        {
            if (partUnitOfMeasurementModel == null)
            {
                return null;
            }

            return new WSPartUnitOfMeasurement()
            {
                Id = partUnitOfMeasurementModel.Identifier,
                Display = partUnitOfMeasurementModel.Display
            };
        }

        public static PartUnitOfMeasurementModel ToEntityModel(WSPartUnitOfMeasurement wsPartUnitOfMeasurement)
        {
            if (wsPartUnitOfMeasurement == null)
            {
                return null;
            }

            return new PartUnitOfMeasurementModel
            {
                Identifier = wsPartUnitOfMeasurement.Id, 
                Display = wsPartUnitOfMeasurement.Display
            };
        }
    }
}
