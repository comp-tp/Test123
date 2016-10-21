using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppStandardCommentResponse:WSResponseBase
    {
        /// <summary>
        /// Gets or sets the standard comments.
        /// </summary>
        /// <value>
        /// The standard comments.
        /// </value>
        [DataMember(Name = "standardComments")]
        public List<WSInspectorAppStandardComment> StandardComments
        {
            get;
            set;
        }

        public static WSInspectorAppStandardCommentResponse FromEntityModel(StandardCommentResponse response)
        {
            if (response == null)
            {
                return null;
            }

            WSInspectorAppStandardCommentResponse result = new WSInspectorAppStandardCommentResponse();
            if (response.StandardComments != null)
            {
                result.StandardComments = new List<WSInspectorAppStandardComment>();
                response.StandardComments.ForEach(item =>
                {
                    result.StandardComments.Add(WSInspectorAppStandardComment.FromEntityModel(item));
                });
            }

            return result;
        }
    }
}
