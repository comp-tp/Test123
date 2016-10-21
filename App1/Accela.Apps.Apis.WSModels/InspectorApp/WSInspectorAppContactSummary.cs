using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppContactSummary
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "address", EmitDefaultValue = false)]
        public string Address { get; set; }

        [DataMember(Name = "fullName", EmitDefaultValue = false)]
        public string FullName { get; set; }

        [DataMember(Name = "phoneNumber", EmitDefaultValue = false)]
        public string PhoneNumber { get; set; }

        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        public static WSInspectorAppContactSummary FromEntityModel(ContactSummaryModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new WSInspectorAppContactSummary()
            {
                Id=model.Identifier,
                Type=model.Type,
                Address=model.Address,
                FullName=model.FullName,
                PhoneNumber=model.PhoneNumber,
                Email=model.Email
            };

            return result;
        }
    }
}
