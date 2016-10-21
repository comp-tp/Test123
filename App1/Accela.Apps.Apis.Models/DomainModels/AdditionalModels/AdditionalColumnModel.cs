using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.Models.DomainModels.AdditionalModels
{
    /// <summary>
    /// Additional column model
    /// </summary>
    [DataContract(Name = "additionalColumn")]
    public class AdditionalColumnModel : ActionDataModel
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
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The Name.
        /// </value>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the enumerations.
        /// </summary>
        /// <value>
        /// The enumerations.
        /// </value>
        [DataMember(Name = "enumerations", EmitDefaultValue = false)]
        public List<EnumerationModel> Enumerations
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the default value.
        /// </summary>
        /// <value>
        /// The default value.
        /// </value>
        [DataMember(Name = "defaultValue", EmitDefaultValue = false)]
        public string DefaultValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the min value.
        /// </summary>
        /// <value>
        /// The min value.
        /// </value>
        [DataMember(Name = "minValue", EmitDefaultValue = false)]
        public double MinValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the max value.
        /// </summary>
        /// <value>
        /// The max value.
        /// </value>
        [DataMember(Name = "maxValue", EmitDefaultValue = false)]
        public double MaxValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [input required].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [input required]; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "inputRequired", EmitDefaultValue = false)]
        public bool InputRequired
        {
            get;
            set;
        }

        /// <summary>
        /// context type
        /// </summary>
        /// <value>
        /// The type of the context.
        /// </value>
        //[DataMember(Name = "contextType")]
        //public string ContextType
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Gets or sets the security.
        /// Full: full access
        /// Readonly: readonly
        /// None: no access
        /// </summary>
        /// <value>
        /// The security.
        /// </value>
        [DataMember(Name = "security", EmitDefaultValue = false)]
        public string Security
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AdditionalColumnModel"/> is readonly.
        /// </summary>
        /// <value>
        /// <c>true</c> if readonly; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "readonly", EmitDefaultValue = false)]
        public bool Readonly
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the unit of measurement.
        /// </summary>
        /// <value>
        /// The unit of measurement.
        /// </value>
        [DataMember(Name = "unitOfMeasurement", EmitDefaultValue = false)]
        public string UnitOfMeasurement
        {
            get;
            set;
        }

        [DataMember(Name = "isDrillDown")]
        public bool IsDrillDown { get; set; }

        [DataMember(Name = "isDrillDownRoot")]
        public bool IsDrillDownRoot { get; set; }

        [DataMember(Name = "drillDownId", EmitDefaultValue = false)]
        public string DrillDownId { get; set; }
    }
}
