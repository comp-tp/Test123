using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CommentModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppStandardCommentType:WSIdentifierBase
    {
        public static WSInspectorAppStandardCommentType FromEntityModel(StandardCommentTypeModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new WSInspectorAppStandardCommentType()
            {
                Display=model.Display,
                Id=model.Identifier
            };

            return result;
        }
    }
}
