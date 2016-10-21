using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class DepartmentHelper : GovXmlHelperBase
    {
        public static IList<SystemDepartmentModel> ToClientDepartments(GetDepartmentsResponse getDepartmentsResponse)
        {
            IList<SystemDepartmentModel> systemDepartmentModels = new List<SystemDepartmentModel>();

            if (getDepartmentsResponse != null)
            {

                if (getDepartmentsResponse.Departments != null &&
                    getDepartmentsResponse.Departments.Department != null)
                {
                    SystemDepartmentModel departmentModel = null;
                    foreach (var department in getDepartmentsResponse.Departments.Department)
                    {
                        departmentModel = new SystemDepartmentModel()
                        {
                            Id = department.keys.ToStringKeys(),
                            Display = department.identifierDisplay
                        };

                        if (department.Staff != null && department.Staff.StaffPerson != null)
                        {
                            departmentModel.Staffs = new List<StaffPersonModel>();
                            foreach (StaffPerson staff in department.Staff.StaffPerson)
                            {
                                departmentModel.Staffs.Add(new StaffPersonModel()
                                {
                                    Id = staff.keys.ToStringKeys(),
                                    Display = staff.identifierDisplay,
                                    FirstName = staff.firstName,
                                    LastName = staff.lastName
                                });
                            }

                        }

                        systemDepartmentModels.Add(departmentModel);
                    }
                }
            }

            return systemDepartmentModels;
        }
    }
}
