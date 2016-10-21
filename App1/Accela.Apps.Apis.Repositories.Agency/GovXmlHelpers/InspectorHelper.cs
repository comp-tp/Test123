using System.Linq;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Repositories.GovXmlQueries;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    /// <summary>
    /// inspector helper
    /// </summary>
    internal class InspectorHelper : GovXmlHelperBase 
    {
        /*
        /// <summary>
        /// Gets the departments with inspectors.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>the departments with inspectors.</returns>
        public static DepartmentResponse GetDepartmentWithInspectors(QueryBase query)
        {
            var system = CommonHelper.GetSystem();
            system.startRow = query.RowStart;
            system.maxRows = query.PageSize;

            var getDepartments = new GetDepartments();
            getDepartments.system = system;
            var govXml4GetDepartments = new GovXML();
            govXml4GetDepartments.getDepartments = getDepartments;
            GovXML departmentResponse = CommonHelper.Post(govXml4GetDepartments, system, (o) => o.getDepartmentsResponse == null ? null : o.getDepartmentsResponse.system);

            var getInspectors = new GetInspectors();
            getInspectors.system = system;
            var govXml4GetInspectors = new GovXML();
            govXml4GetInspectors.getInspectors = getInspectors;
            GovXML inspectorResponse = CommonHelper.Post(govXml4GetInspectors, system, (o) => o.getInspectorsResponse == null ? null : o.getInspectorsResponse.system);

            var results = GetDepartmentWithInspectorsFromGovXml(departmentResponse.getDepartmentsResponse, inspectorResponse.getInspectorsResponse);

            return results;
        }

        /// <summary>
        /// Gets the departments with inspectors from gov XML.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns>the departments with inspectors from gov XML.</returns>
        private static DepartmentResponse GetDepartmentWithInspectorsFromGovXml(GetDepartmentsResponse departmentResponse, GetInspectorsResponse inspectorResponse)
        {
            DepartmentResponse result = null;
            bool hasDepartments = departmentResponse != null && departmentResponse.Departments != null && departmentResponse.Departments.Department != null && departmentResponse.Departments.Department.Length > 0;
            bool hasInspectors = inspectorResponse != null && inspectorResponse.inspectors != null && inspectorResponse.inspectors.inspector != null && inspectorResponse.inspectors.inspector.Length > 0;

            if (hasDepartments)
            {
                result = new DepartmentResponse();
                result.Departments = (from d in departmentResponse.Departments.Department
                                      where d != null
                                      let hasStaff = d.Staff != null && d.Staff.StaffPerson != null && d.Staff.StaffPerson.Length > 0
                                      select new DepartmentModel()
                                      {
                                          Identifier = d.keys.ToStringKeys(),
                                          Display = d.identifierDisplay,
                                          Inspectors = !hasStaff || !hasInspectors ? null :
                                                        (from s in d.Staff.StaffPerson
                                                         from i in inspectorResponse.inspectors.inspector
                                                         where s.keys.ToStringKeys() == i.keys.ToStringKeys()
                                                         && i.person != null
                                                         && i.Active == true
                                                         select new InspectorModel()
                                                         {
                                                             Identifier = i.keys.ToStringKeys(),
                                                             Name = CommonHelper.GetPersonName(i.person)
                                                         }).ToList()
                                      }).ToList();
            }

            return result;
        }
        //*/

        public static DepartmentResponse ToClientDepartmentWithInspector(GetDepartmentsResponse departmentResponse, GetInspectorsResponse inspectorResponse)
        {
            DepartmentResponse result = null;
            bool hasDepartments = departmentResponse != null && departmentResponse.Departments != null && departmentResponse.Departments.Department != null && departmentResponse.Departments.Department.Length > 0;
            bool hasInspectors = inspectorResponse != null && inspectorResponse.inspectors != null && inspectorResponse.inspectors.inspector != null && inspectorResponse.inspectors.inspector.Length > 0;

            if (hasDepartments)
            {
                result = new DepartmentResponse();
                result.Departments = (from d in departmentResponse.Departments.Department
                                      where d != null
                                      let hasStaff = d.Staff != null && d.Staff.StaffPerson != null && d.Staff.StaffPerson.Length > 0
                                      select new DepartmentModel()
                                      {
                                          Identifier = d.keys.ToStringKeys(),
                                          Display = d.identifierDisplay,
                                          Inspectors = !hasStaff || !hasInspectors ? null :
                                                        (from s in d.Staff.StaffPerson
                                                         from i in inspectorResponse.inspectors.inspector
                                                         where s.keys.ToStringKeys() == i.keys.ToStringKeys()
                                                         && i.person != null
                                                         && i.Active == true
                                                         select new InspectorModel()
                                                         {
                                                             Identifier = i.keys.ToStringKeys(),
                                                             Name = CommonHelper.GetPersonName(i.person)
                                                         }).ToList()
                                      }).ToList();
            }

            return result;
        }
    }
}
