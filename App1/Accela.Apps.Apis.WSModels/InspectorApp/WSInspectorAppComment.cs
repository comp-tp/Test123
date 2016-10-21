using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppComment : WSAction
    {
        [DataMember(Name = "fillDate", EmitDefaultValue = false)]
        public string FillDate { get; set; }

        [DataMember(Name = "fillPeopleName", EmitDefaultValue = false)]
        public string FillPeopleName { get; set; }

        [DataMember(Name = "content", EmitDefaultValue = false)]
        public string Content { get; set; }

        public static Comment ToEntityModel(WSInspectorAppComment model)
        {
            Comment result = null;

            if (model != null)
            {
                result = new Comment()
                {
                    Action = model.Action,
                    Content = model.Content,
                    FillDate = model.FillDate,
                    FillPeopleName = model.FillPeopleName
                };
            }

            return result;
        }

        public static List<Comment> ToEntityModels(List<WSInspectorAppComment> models)
        {
            List<Comment> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<Comment>();
                foreach (var m in models)
                {
                    var entityModel = ToEntityModel(m);
                    result.Add(entityModel);
                }
            }

            return result;
        }

        public static WSInspectorAppComment FromEntityModel(Comment model)
        {
            WSInspectorAppComment result = null;

            if (model != null)
            {
                result = new WSInspectorAppComment()
                {
                    Action = model.Action,
                    Content = model.Content,
                    FillDate = model.FillDate,
                    FillPeopleName = model.FillPeopleName
                };
            }

            return result;
        }

        public static List<WSInspectorAppComment> FromEntityModels(List<Comment> models)
        {
            List<WSInspectorAppComment> result = null;

            if (models != null && models.Count > 0)
            {
                result = new List<WSInspectorAppComment>();
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
