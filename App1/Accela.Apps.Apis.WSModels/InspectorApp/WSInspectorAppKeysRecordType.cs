using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppKeysRecordType : WSIdentifierBase
    {
        public static RecordTypeModel ToEntityModel(WSInspectorAppKeysRecordType model)
        {
            RecordTypeModel result = null;

            if (model != null)
            {
                result = new RecordTypeModel()
                {
                    Identifier = model.Id,
                    Display = model.Display
                };
            }

            return result;
        }

        public static List<RecordTypeModel> ToEntityModels(List<WSInspectorAppKeysRecordType> models)
        {
            List<RecordTypeModel> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<RecordTypeModel>();
                foreach (var m in models)
                {
                    var entityModel = ToEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }

        public static WSInspectorAppKeysRecordType FromEntityModel(RecordTypeModel model)
        {
            WSInspectorAppKeysRecordType result = null;

            if (model != null)
            {
                result = new WSInspectorAppKeysRecordType()
                {
                    Id = model.Identifier,
                    Display = model.Display
                };
            }

            return result;
        }

        public static List<WSInspectorAppKeysRecordType> FromEntityModels(List<RecordTypeModel> models)
        {
            List<WSInspectorAppKeysRecordType> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<WSInspectorAppKeysRecordType>();
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
