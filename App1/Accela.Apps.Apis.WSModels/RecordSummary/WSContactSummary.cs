using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.WSModels.RecordSummary
{
    [DataContract]
    public class WSContactSummary : WSDataModel
    {
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "fullName", EmitDefaultValue = false)]
        public string FullName { get; set; }

        [DataMember(Name = "phoneNumber", EmitDefaultValue = false)]
        public string PhoneNumber { get; set; }

        [DataMember(Name = "address", EmitDefaultValue = false)]
        public string Address { get; set; }

        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        public static List<WSContactSummary> FromEntityModels(List<ContactSummaryModel> models)
        {
            List<WSContactSummary> result = null;

            if (models != null && models.Count > 0)
            {
                result = models.Select(p => FromEntityModel(p)).ToList();
            }
            
            return result;
        }

        public static WSContactSummary FromEntityModel(ContactSummaryModel model)
        {
            WSContactSummary result = null;

            if (model != null)
            {
                result = new WSContactSummary()
                {
                    FullName = model.FullName,
                    Identifier = model.Identifier,
                    PhoneNumber = model.PhoneNumber,
                    Type = model.Type,
                    Address = model.Address,
                    Email = model.Email
                };
            }

            return result;
        }
    }
}
