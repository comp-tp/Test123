using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Repositories.Agency.AARESTModels
{
    //[DataContract]
    public class AAReportDefinition
    {
        //[DataMember(Name = "format")]
        public string format { get; set; }

        //[DataMember(Name = "id")]
        public int id { get; set; }

        //[DataMember(Name = "name")]
        public string name { get; set; }

        public string description { get; set; }

        //[DataMember(Name = "parameters")]
        public List<AAReportParameter> parameters { get; set; }
    }
}
