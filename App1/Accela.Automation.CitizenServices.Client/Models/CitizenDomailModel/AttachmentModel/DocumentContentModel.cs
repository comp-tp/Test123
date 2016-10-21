using System.Runtime.Serialization;

namespace Accela.Automation.CitizenServices.Client.Models
{
    [DataContract(Name = "documentContent")]
    public class DocumentContentModel
    {
        /// <summary>
        /// Base64 string.
        /// </summary>
        [DataMember(Name = "docContentStream")]
        public string docContentStream { get; set; }
    }
}