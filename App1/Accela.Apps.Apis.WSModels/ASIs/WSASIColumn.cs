using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;
using Accela.Apps.Apis.Models.DomainModels.ChecklistModels;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    /// <summary>
    /// Additional column model
    /// </summary>
    [DataContract(Name = "ASIColumn")]
    public class WSASIColumn : WSEntityState
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id
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
        public List<WSEnumeration> Enumerations
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

        [DataMember(Name = "childIds", EmitDefaultValue = false)]
        public List<string> DrillDwonChilds { get; set; }

        /// <summary>
        /// Convert AdditionalColumnModel to WSASIColumn.
        /// </summary>
        /// <param name="wsASIColumn">WSASIColumn.</param>
        /// <returns>AdditionalColumnModel.</returns>
        public static AdditionalColumnModel ToEntityModel(WSASIColumn wsASIColumn)
        {
            if (wsASIColumn != null)
            {
                var result = new AdditionalColumnModel()
                {
                    Action = WSEntityState.ConvertEntityStateToAction(wsASIColumn.EntityState),
                    Display = wsASIColumn.Display,
                    Identifier = wsASIColumn.Id,
                    DefaultValue = wsASIColumn.DefaultValue,
                    InputRequired = wsASIColumn.InputRequired,
                    MaxValue = wsASIColumn.MaxValue,
                    MinValue = wsASIColumn.MinValue,
                    Name = wsASIColumn.Name,
                    Readonly = wsASIColumn.Readonly,
                    Security = wsASIColumn.Security,
                    Type = wsASIColumn.Type,
                    UnitOfMeasurement = wsASIColumn.UnitOfMeasurement,
                    IsDrillDown = wsASIColumn.IsDrillDown,
                    DrillDownId = wsASIColumn.DrillDownId
                };

                if (wsASIColumn.Enumerations != null)
                {
                    result.Enumerations = new List<EnumerationModel>();

                    wsASIColumn.Enumerations.ForEach(item => result.Enumerations.Add(new EnumerationModel
                                                                                    {
                                                                                        Identifier = item.Id,
                                                                                        Display = item.Display
                                                                                    }));
                }

                return result;
            }
            return null;
        }

        /// <summary>
        /// Convert WSASIColumn list to AdditionalColumnModel list.
        /// </summary>
        /// <param name="wsASIColumns">WSASIColumn list.</param>
        /// <returns>AdditionalColumnModel list.</returns>
        public static List<AdditionalColumnModel> ToEntityModels(List<WSASIColumn> wsASIColumns)
        {
            if (wsASIColumns != null && wsASIColumns.Count > 0)
            {
                var additionalColumnModels = new List<AdditionalColumnModel>();
                foreach (var wsASIColumn in wsASIColumns)
                {
                    additionalColumnModels.Add(ToEntityModel(wsASIColumn));
                }
                return additionalColumnModels;
            }
            return null;
        }
    }

    [DataContract]
    public class WSEnumeration
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }
    }
}
