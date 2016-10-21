
using System;
using System.Collections.Generic;
namespace Accela.Apps.Apis.Models.DomainModels.GISModels
{
    [Serializable]
    public class MapServiceModel
    {
        public MapServiceModel()
		{
		}

		public string Order;

		public string Name;

        public string GISServiceId;

        public string Url;

        public GisSecuritySettings GisSecuritySettings { get; set; }

        public List<LayeSetting> LayerSettings { get; set; }
    }

    [Serializable]
    public class GisSecuritySettings
    { 
        public string UserName {get;set;}
        
        public string Password {get;set;}

        public string TokenUrl {get;set;}

        public string Token {get;set;}

        public string Referrer { get; set; }       
        
    }

    [Serializable]
    public class LayeSetting
    {
        public string Name { get; set; }

        public string IdField { get; set; }

        public string IdFieldType { get; set; }

    }

}
