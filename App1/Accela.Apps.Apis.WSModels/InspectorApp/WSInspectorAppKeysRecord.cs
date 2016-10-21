using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    public class WSInspectorAppKeysRecord : WSIdentifierBase
    {
        /// <summary>
        /// An additional descriptor for the RECORD. 
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Type information of this RECORD. 
        /// </summary>
        [DataMember(Name = "recordType", EmitDefaultValue = false)]
        public WSInspectorAppKeysRecordType RecordType { get; set; }

        public static RecordModel ToEntityModel(WSInspectorAppKeysRecord model)
        {
            RecordModel result = null;

            if (model != null)
            {
                result = new RecordModel()
                {
                    Identifier = model.Id,
                    Display = model.Display,
                    Name = model.Name,
                    RecordType = WSInspectorAppKeysRecordType.ToEntityModel(model.RecordType)
                };
            }

            return result;
        }

        public static List<RecordModel> ToEntityModels(List<WSInspectorAppKeysRecord> models)
        {
            List<RecordModel> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<RecordModel>();
                foreach (var m in models)
                {
                    var entityModel = ToEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }

        public static WSInspectorAppKeysRecord FromEntityModel(RecordModel model)
        {
            WSInspectorAppKeysRecord result = null;

            if (model != null)
            {
                result = new WSInspectorAppKeysRecord()
                {
                    Id = model.Identifier,
                    Display = model.Display,
                    Name = model.Name,
                    RecordType = WSInspectorAppKeysRecordType.FromEntityModel(model.RecordType)
                };
            }

            return result;
        }

        public static List<WSInspectorAppKeysRecord> FromEntityModels(List<RecordModel> models)
        {
            List<WSInspectorAppKeysRecord> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<WSInspectorAppKeysRecord>();
                foreach (var m in models)
                {
                    var entityModel = FromEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }
    }
}
