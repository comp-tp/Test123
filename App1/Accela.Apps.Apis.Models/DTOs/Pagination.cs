using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DTOs
{
    /// <summary>
    /// The class is pagination model
    /// the class is just model. it will not include any logic
    /// </summary>
    [DataContract]
    public  class Pagination
    {
      [DataMember(Name = "offset")]        
       public int Offset { get; set; }

        [DataMember(Name = "limit")]
        public int Limit { get; set; }

        [DataMember(Name = "totalRows")]
        public int TotalRows { get; set; }        
    }

}
