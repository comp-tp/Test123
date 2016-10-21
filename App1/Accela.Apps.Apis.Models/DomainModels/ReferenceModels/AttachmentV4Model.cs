using System;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.ReferenceModels
{
    [DataContract]
    public class AttachmentV4Model : DataModel
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "fileName", EmitDefaultValue = false)]
        public string FileName { get; set; }
    
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string ContentType { get; set; }

        [DataMember(Name = "serviceProviderCode", EmitDefaultValue = false)]
        public string ServiceProviderCode { get; set; }

        public string CacheKey
        {
            get { return String.Format("{0}-{1}", ServiceProviderCode, Id); }
        }
    }
}