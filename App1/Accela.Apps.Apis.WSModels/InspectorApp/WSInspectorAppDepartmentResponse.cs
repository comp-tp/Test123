using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    [DataContract]
    public class WSInspectorAppDepartmentResponse:WSResponseBase
    {
        /// <summary>
        /// Gets or sets the departments.
        /// </summary>
        /// <value>
        /// The departments.
        /// </value>
        [DataMember(Name = "departments")]
        public List<WSInspectorAppDepartment> Departments
        {
            get;
            set;
        }

        public static WSInspectorAppDepartmentResponse FromEntityModel(DepartmentResponse response)
        {
            WSInspectorAppDepartmentResponse result = null;
            if (response != null && response.Departments!=null)
            {
                result = new WSInspectorAppDepartmentResponse();
                result.Departments = new List<WSInspectorAppDepartment>();
                response.Departments.ForEach(item =>
                {
                    result.Departments.Add(WSInspectorAppDepartment.FromEntityModel(item));
                });                
            }

            return result;
        }
    }
}
