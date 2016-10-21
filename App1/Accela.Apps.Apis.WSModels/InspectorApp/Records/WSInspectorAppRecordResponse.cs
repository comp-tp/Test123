using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp.Records
{
    [DataContract(Name = "getRecordResponse")]
    public class WSInspectorAppRecordResponse
    {
        [DataMember(Name = "record", EmitDefaultValue = false)]
        public WSInspectorAppRecord Record { get; set; }

        public static WSInspectorAppRecordResponse FromEntityModel(RecordResponse model)
        {
            WSInspectorAppRecordResponse result = null;

            if (model != null)
            {
                result = new WSInspectorAppRecordResponse()
                {
                    Record = WSInspectorAppRecord.FromEntityModel(model.Record)
                };
            }

            return result;
        }
    }
}
