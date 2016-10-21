using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.WSModels.InspectorApp
{
    public class WSInspectorAppDepartment:WSIdentifierBase
    {
        /// <summary>
        /// Gets or sets the inspectors.
        /// </summary>
        /// <value>
        /// The inspectors.
        /// </value>
        [DataMember(Name = "inspectors", EmitDefaultValue = false)]
        public List<WSInspectorAppInspector> Inspectors
        {
            get;
            set;
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

        [DataMember(Name = "subGroupDesc", EmitDefaultValue = false)]
        public string SubGroupCodeDesc { get; set; }


        #endregion

        public static WSInspectorAppDepartment FromEntityModel(DepartmentModel model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new WSInspectorAppDepartment()
            {
                AgencyCode = model.AgencyCode,
                BureauCode =model.BureauCode,
                Display=model.Display,
                DivisionCode=model.DivisionCode,
                GroupCode=model.GroupCode,
                Id=model.Identifier,
                SectionCode=model.SectionCode,
                SubGroupCode=model.SubGroupCode,
                SubGroupCodeDesc= model.SubGroupCodeDesc,
            };

            if (model.Inspectors != null)
            {
                result.Inspectors = new List<WSInspectorAppInspector>();
                model.Inspectors.ForEach(item =>
                {
                    if (item != null)
                    {
                        var wsInspector = WSInspectorAppInspector.FromEntityModel(item);
                        result.Inspectors.Add(wsInspector);
                    }
                });                
            }

            return result;
        }

        public static DepartmentModel ToEntityModel(WSInspectorAppDepartment model)
        {
            if (model == null)
            {
                return null;
            }

            var result = new DepartmentModel()
            {
                AgencyCode = model.AgencyCode,
                BureauCode = model.BureauCode,
                Display = model.Display,
                DivisionCode = model.DivisionCode,
                GroupCode = model.GroupCode,
                Identifier = model.Id,
                SectionCode = model.SectionCode,
                SubGroupCode = model.SubGroupCode,
                SubGroupCodeDesc = model.SubGroupCodeDesc,
                Inspectors = WSInspectorAppInspector.ToEntityModels(model.Inspectors)
            };

            return result;
        }
    }
}
