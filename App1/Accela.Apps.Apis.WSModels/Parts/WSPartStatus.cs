using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.PartModels;

namespace Accela.Apps.Apis.WSModels.Parts
{
    [DataContract(Name = "partStatus")]
    public class WSPartStatus : WSDataModel
    {
        /// <summary>
        /// Gets or sets the status id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the status name.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the status value.
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the status date.
        /// </summary>
        [DataMember(Name = "date", EmitDefaultValue = false)]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the status time.
        /// </summary>
        [DataMember(Name = "time", EmitDefaultValue = false)]
        public string Time { get; set; }

        /// <summary>
        /// Convert PartStatusModel to WSPartStatus.
        /// </summary>
        /// <param name="partStatusModel">partStatusModel.</param>
        /// <returns>WSPartStatus.</returns>
        public static WSPartStatus FromEntityModel(PartStatusModel partStatusModel)
        {
            if (partStatusModel != null)
            {
                return new WSPartStatus()
                           {
                               Id = partStatusModel.Identifier,
                               Name = partStatusModel.Name,
                               Value = partStatusModel.Value,
                               Date = partStatusModel.Date,
                               Time = partStatusModel.Time
                           };
            }

            return null;
        }

        /// <summary>
        /// convert wsModel to bizModel
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static PartStatusModel ToEntityModel(WSPartStatus status)
        {
            if (status != null)
            {
                return new PartStatusModel()
                           {
                               Identifier = status.Id,
                               Name = status.Name,
                               Value = status.Value,
                               Date = status.Date,
                               Time = status.Time
                           };

            }
            return null;
        }
    }
}
