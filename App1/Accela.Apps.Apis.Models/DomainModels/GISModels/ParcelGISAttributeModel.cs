
using System;
namespace Accela.Apps.Apis.Models.DomainModels.GISModels
{
    [Serializable]
    public class ParcelGISAttributeModel
    {
        public ParcelGISAttributeModel()
        {
        }

        public string GISServiceId;

        public string LayerName;

        public string IdField;
    }
}
