using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.WSModels.Inspections;

namespace Accela.Apps.Apis.WSModels.RelatedRecords
{
    [DataContract]
    public class WSDepartmentWithStaffs : WSDataModel
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>        
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the inspectors.
        /// </summary>        
        [DataMember(Name = "staff", EmitDefaultValue = false)]
        public List<WSInspector> Inspectors
        {
            get;
            set;
        }

        /// <summary>
        /// Convert DepartmentModel to WSDepartment.
        /// </summary>
        /// <param name="departmentModel">DepartmentModel.</param>
        /// <returns>WSDepartment.</returns>
        public static WSDepartmentWithStaffs FromEntityModel(DepartmentModel departmentModel)
        {
            if (departmentModel != null)
            {
                return new WSDepartmentWithStaffs()
                {
                    Id = departmentModel.Identifier,
                    Display = departmentModel.Display,
                    Inspectors = WSInspector.FromEntityModels(departmentModel.Inspectors)
                };
            };
            return null;
        }

        /// <summary>
        /// Convert WSDepartment to DepartmentModel.
        /// </summary>
        /// <param name="wsDepartment">WSDepartment.</param>
        /// <returns>DepartmentModel.</returns>
        public static DepartmentModel ToEntityModel(WSDepartmentWithStaffs wsDepartment)
        {
            if (wsDepartment != null)
            {
                return new DepartmentModel()
                {
                    Identifier = wsDepartment.Id,
                    Display = wsDepartment.Display,
                    Inspectors = WSInspector.ToEntityModels(wsDepartment.Inspectors)
                };
            }
            return null;
        }
    }
}
