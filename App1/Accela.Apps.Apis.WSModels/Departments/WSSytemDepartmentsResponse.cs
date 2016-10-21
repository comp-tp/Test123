using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Responses.Departments;

namespace Accela.Apps.Apis.WSModels.Departments
{
    [DataContract(Name = "getSystemDepartmentsResponse")]
    public class WSSystemDepartmentsResponse : WSPagedResponse
    {
        [DataMember(Name = "departments", EmitDefaultValue = false)]
        public List<WSSystemDepartment> Departments { get; set; }

        /// <summary>
        /// Convert biz response to service response. 
        /// </summary>
        public static WSSystemDepartmentsResponse FromEntityModel(SystemDepartmentsResponse systemDepartmentsResponse)
        {
            return new WSSystemDepartmentsResponse()
                       {
                           Departments = GetDepartmentsFromBiz(systemDepartmentsResponse.Departments),
                           PageInfo = WSPagination.FromEntityModel(systemDepartmentsResponse.PageInfo)
                       };
        }

        private static List<WSSystemDepartment> GetDepartmentsFromBiz(List<SystemDepartmentModel> models)
        {
            if (models == null)
            {
                return null;
            }

            List<WSSystemDepartment> departments = new List<WSSystemDepartment>();

            foreach (SystemDepartmentModel model in models)
            {
                departments.Add(new WSSystemDepartment() {Id = model.Id, Display = model.Display});
            }

            return departments;
        }

    }
}
