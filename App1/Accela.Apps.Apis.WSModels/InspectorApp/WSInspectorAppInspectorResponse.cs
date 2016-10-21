using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppInspectorResponse:WSPagedResponse
    {
        /// <summary>
        /// Gets or sets the inspectors.
        /// </summary>
        /// <value>
        /// The inspectors.
        /// </value>
        [DataMember(Name = "inspectors")]
        public List<WSInspectorAppInspector> Inspectors
        {
            get;
            set;
        }

        public static WSInspectorAppInspectorResponse FromEntityModel(InspectorResponse response)
        {
            WSInspectorAppInspectorResponse result = null;
            if (response != null && response.Inspectors!=null)
            {
                result = new WSInspectorAppInspectorResponse();
                result.Inspectors = new List<WSInspectorAppInspector>();
                response.Inspectors.ForEach(item =>
                {
                    result.Inspectors.Add(WSInspectorAppInspector.FromEntityModel(item));
                });
            }

            return result;
        }
    }
}
