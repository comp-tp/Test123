using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "status")]
    public class WSInspectionStatus : WSIdentifierBase
    {
        /// <summary>
        /// Gets or sets the inspection status type.
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        /// <summary>
        /// Toes the entity models.
        /// </summary>
        /// <param name="inspectionStatusModels">The inspection status models.</param>
        /// <returns>the entity models.</returns>
        public static List<InspectionStatusModel> ToEntityModels(List<WSInspectionStatus> inspectionStatusModels)
        {
            if (inspectionStatusModels != null)
            {
                if (inspectionStatusModels != null && inspectionStatusModels.Count > 0)
                {
                    var wsInspectionStatus = new List<InspectionStatusModel>();
                    inspectionStatusModels.ForEach(i => wsInspectionStatus.Add(ToEntityModel(i)));
                    return wsInspectionStatus;
                }
            }

            return null;
        }

        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="inspectionStatusModel">The inspection status model.</param>
        /// <returns>the entity model.</returns>
        public static InspectionStatusModel ToEntityModel(WSInspectionStatus inspectionStatusModel)
        {
            if (inspectionStatusModel != null)
            {
                return new InspectionStatusModel()
                {
                    Identifier = inspectionStatusModel.Id,
                    Display = inspectionStatusModel.Display,
                    Type = inspectionStatusModel.Type
                };
            }

            return null;
        }

        /// <summary>
        /// Convert InspectionStatusModel to WSInspectionStatus.
        /// </summary>
        /// <param name="inspectionStatusModel">InspectionStatusModel.</param>
        /// <returns>WSInspectionStatus.</returns>
        public static WSInspectionStatus FromEntityModel(InspectionStatusModel inspectionStatusModel)
        {
            if (inspectionStatusModel != null)
            {
                return new WSInspectionStatus()
                {
                    Id = inspectionStatusModel.Identifier,
                    Display = inspectionStatusModel.Display,
                    Type = inspectionStatusModel.Type
                };
            }
            return null;
        }

        /// <summary>
        /// Convert InspectionStatusModel list to WSInspectionStatus list.
        /// </summary>
        /// <param name="inspectionStatusModels">InspectionStatusModel list</param>
        /// <returns>WSInspectionStatus list.</returns>
        public static List<WSInspectionStatus> FromEntityModels(List<InspectionStatusModel> inspectionStatusModels)
        {
            if (inspectionStatusModels != null)
            {
                if (inspectionStatusModels != null && inspectionStatusModels.Count > 0)
                {
                    var wsInspectionStatus = new List<WSInspectionStatus>();
                    inspectionStatusModels.ForEach(i => wsInspectionStatus.Add(FromEntityModel(i)));

                    return wsInspectionStatus;
                }
            }
            return null;
        }
    }
}
