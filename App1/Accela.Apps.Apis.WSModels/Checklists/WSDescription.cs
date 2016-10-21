using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.Common
{
    [DataContract]
    public class WSDescription
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }


        internal static WSDescription FromEntityModel(DescriptionModel model)
        {
            if (model != null)
            {
                return new WSDescription()
                           {
                               Id = model.ID,
                               Display = model.Display,
                           };
            }
            return null;
        }

        internal static DescriptionModel ToEntityModel(WSDescription wsModel)
        {
            if (wsModel != null)
            {
                return new DescriptionModel()
                           {
                               ID = wsModel.Id,
                               Display = wsModel.Display
                           };
            }
            return null;
        }
    }
}
