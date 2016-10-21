using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.ReferenceModels
{
    /// <summary>
    /// department model
    /// </summary>
    [DataContract]
    public class DepartmentModel : DataModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "identifier", EmitDefaultValue = false)]
        public string Identifier
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>
        /// The display.
        /// </value>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the inspectors.
        /// </summary>
        /// <value>
        /// The inspectors.
        /// </value>
        [DataMember(Name = "inspectors", EmitDefaultValue = false)]
        public List<InspectorModel> Inspectors
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
    }
}
