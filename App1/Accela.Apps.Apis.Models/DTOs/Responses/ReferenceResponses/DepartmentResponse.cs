using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses
{
    /// <summary>
    /// department response
    /// </summary>
    [DataContract(Name = "getDepartmentResponse")]
    public class DepartmentResponse : PagedResponse
    {
        /// <summary>
        /// Gets or sets the departments.
        /// </summary>
        /// <value>
        /// The departments.
        /// </value>
        [DataMember(Name = "departments")]
        public List<DepartmentModel> Departments
        {
            get;
            set;
        }
    }
}
