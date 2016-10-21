using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Repositories.Agency.AARESTModels
{
    //[DataContract]
    public class AAReportParameter
    {
        //[DataMember(Name = "name")]
        public string name { get; set; }

        //[DataMember(Name = "type")]
        public string type { get; set; }

        //[DataMember(Name = "nickname")]
        public string nickname { get; set; }

        //[DataMember(Name = "required")]
        public string required { get; set; }
    }
}
