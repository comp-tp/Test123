using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;

namespace Accela.Apps.Apis.WSModels.Inspections
{
    [DataContract(Name = "inspectionStatus")]
    public class WSSystemInspectionStatus : WSDataModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false, Order = 0)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false, Order = 1)]
        public string Display { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false, Order = 2)]
        public string Type { get; set; }
        

        internal static List<WSSystemInspectionStatus> FromEntityModel(List<InspectionStatusModel> models)
        {
            if (models == null)
            {
                return null;
            }
            List<WSSystemInspectionStatus> status = new List<WSSystemInspectionStatus>();
            foreach (var model in models)
            {
                status.Add(new WSSystemInspectionStatus()
                               {
                                   Id = model.Identifier,
                                   Display = model.Display,
                                   Type = model.Type
                               });
            }

            return status;
        }
    }
}
