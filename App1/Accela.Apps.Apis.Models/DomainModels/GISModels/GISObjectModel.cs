
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
namespace Accela.Apps.Apis.Models.DomainModels.GISModels
{
    public class GISObjectModel : ActionDataModel
    {
        public GISObjectModel()
		{
		}

		public string Id {get;set;}

		public string Display {get;set;}

		public AddressModel DetailAddress {get;set;}

        public string MapServiceId {get;set;}

        public string GISLayerId {get;set;}

        public string FeatureIDFieldName { get; set; }
    }
}
