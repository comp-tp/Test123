using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Responses.Departments;

namespace Accela.Apps.Apis.WSModels.Departments
{
    [DataContract(Name = "getSystemDepartmentStaffsResponse")]
    public class WSSystemDepartmentStaffsResponse : WSPagedResponse
    {
        [DataMember(Name = "staffs", EmitDefaultValue = false)]
        public List<WSSystemStaff> Staffs { get; set; }

        /// <summary>
        /// Convert biz response to service response. 
        /// </summary>
        public static WSSystemDepartmentStaffsResponse FromEntityModel(SystemDepartmentStaffsResponse systemDepartmentStaffsResponse)
        {
            return new WSSystemDepartmentStaffsResponse()
            {
                Staffs = GetStaffsFromBiz(systemDepartmentStaffsResponse.Staffs),
                PageInfo = WSPagination.FromEntityModel(systemDepartmentStaffsResponse.PageInfo)
            };
        }

  

        private static List<WSSystemStaff> GetStaffsFromBiz(List<StaffPersonModel> models)
        {
            if (models == null)
            {
                return null;
            }
            var staffs = new List<WSSystemStaff>();
            foreach (var model in models)
            {
                staffs.Add(new WSSystemStaff()
                               {
                                   Id = model.Id,
                                   Display = model.Display,
                                   FirstName = model.FirstName,
                                   LastName = model.LastName
                               });
            }
            return staffs;
        }
    }
}
