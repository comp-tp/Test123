using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.WSModels.RelatedRecords
{
    [DataContract]
    public class WSDepartment : WSDataModel
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
        /// Convert DepartmentModel to WSDepartment.
        /// </summary>
        /// <param name="departmentModel">DepartmentModel.</param>
        /// <returns>WSDepartment.</returns>
        public static WSDepartment FromEntityModel(DepartmentModel departmentModel)
        {
            if (departmentModel != null)
            {
                return new WSDepartment()
                {
                    Id = departmentModel.Identifier,
                    Display = departmentModel.Display,
                };
            };
            return null;
        }

        /// <summary>
        /// Convert WSDepartment to DepartmentModel.
        /// </summary>
        /// <param name="wsDepartment">WSDepartment.</param>
        /// <returns>DepartmentModel.</returns>
        public static DepartmentModel ToEntityModel(WSDepartment wsDepartment)
        {
            if (wsDepartment != null)
            {
                return new DepartmentModel() 
                {
                    Identifier = wsDepartment.Id,
                    Display = wsDepartment.Display,
                };
            }
            return null;
        }

        public static DepartmentModel ToEntityModel(string departmentId)
        {
            if (!string.IsNullOrEmpty(departmentId))
            {
                return new DepartmentModel()
                {
                    Identifier = departmentId
                };
            }
            return null;
        }

        #region the Department's Properties for the WorkOrderTemplateModel & WSWorkOrderTemplate

        [DataMember(Name = "agency", EmitDefaultValue = false)]
        public string AgencyCode { get; set; }

        [DataMember(Name = "bureau", EmitDefaultValue = false)]
        public string BureauCode { get; set; }

        [DataMember(Name = "division", EmitDefaultValue = false)]
        public string DivisionCode { get; set; }

        [DataMember(Name = "section", EmitDefaultValue = false)]
        public string SectionCode { get; set; }

        [DataMember(Name = "group", EmitDefaultValue = false)]
        public string GroupCode { get; set; }

        [DataMember(Name = "subGroup", EmitDefaultValue = false)]
        public string SubGroupCode { get; set; }

        [DataMember(Name = "subGroupDescription", EmitDefaultValue = false)]
        public string SubGroupCodeDesc { get; set; }



        /// <summary>
        /// Convert DepartmentModel to WSDepartment only from the WSWorkOrderTemplate
        /// </summary>
        /// <param name="model">DepartmentModel.</param>
        /// <returns>WSDepartment.</returns>
        public static WSDepartment FromEntityModelForWorkOrderTemplate(DepartmentModel model)
        {
            if (model != null)
            {
                return new WSDepartment()
                {
                    Id = model.Identifier,
                    Display = model.Display,
                    AgencyCode = model.AgencyCode,
                    BureauCode = model.BureauCode,
                    DivisionCode = model.DivisionCode,
                    SectionCode = model.SectionCode,
                    GroupCode = model.GroupCode,
                    SubGroupCode = model.SubGroupCode,
                    SubGroupCodeDesc = model.SubGroupCodeDesc
                };
            };
            return null;
        }


        #endregion
    }
}
