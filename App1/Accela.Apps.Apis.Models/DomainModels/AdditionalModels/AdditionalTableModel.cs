using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Accela.Apps.Apis.Models.DomainModels.AdditionalModels
{
    /// <summary>
    /// Additional table model.
    /// contains ASI/ASIT info.
    /// </summary>
    [DataContract(Name = "additionalTable")]
    public class AdditionalTableModel : DataModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "identifier", EmitDefaultValue = false, Order = 1)]
        public string Identifier { get; set; }

        [DataMember(Name = "subIdentifier", EmitDefaultValue = false, Order = 4)]
        public string SubIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>
        /// The display.
        /// </value>
        [DataMember(Name = "display", EmitDefaultValue = false, Order = 2)]
        public string Display
        {
            get;
            set;
        }

        [DataMember(Name = "subDisplay", EmitDefaultValue = false, Order = 5)]
        public string SubDisplay
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the data columns.
        /// </summary>
        /// <value>
        /// The data columns.
        /// </value>
        [DataMember(Name = "columns", EmitDefaultValue = false, Order = 9)]
        public List<AdditionalColumnModel> Columns
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the data rows.
        /// for ASI, this array's length = 1.
        /// for ASIT, this array's length >= 1
        /// </summary>
        /// <value>
        /// The data rows.
        /// </value>
        [DataMember(Name = "rows", EmitDefaultValue = false, Order = 10)]
        public List<AdditionalRowModel> Rows
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
        [DataMember(Name = "security", EmitDefaultValue = false, Order = 3)]
        public string Security
        {
            get;
            set;
        }

        [DataMember(Name = "subSecurity", EmitDefaultValue = false, Order = 6)]
        public string SubSecurity
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
        [DataMember(Name = "contextType", EmitDefaultValue = false, Order = 8)]
        public string ContextType
        {
            get;
            set;
        }

        /// <summary>
        /// description
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [DataMember(Name = "description", EmitDefaultValue = false, Order = 7)]
        public string Description
        {
            get;
            set;
        }

        [DataMember(Name = "drillDownSeries", EmitDefaultValue = false)]
        public List<AdditionalDrillDownSeriesModel> DrillDownSeries { get; set; }

        [DataMember(Name = "subAlias", EmitDefaultValue = false)]
        public string SubAlias { get; set; }
    }

    public class AdditionalTableComparer : IEqualityComparer<AdditionalTableModel>
    {
        public bool Equals(AdditionalTableModel x, AdditionalTableModel y)
        {
            if (Object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (Object.ReferenceEquals(x, null)
                || Object.ReferenceEquals(y, null))
            {
                return false;
            }

            return x.Identifier == y.Identifier;
        }

        public int GetHashCode(AdditionalTableModel group)
        {
            if (Object.ReferenceEquals(group, null))
            {
                return 0;
            }

            int hashId = group.Identifier == null ? 0 : group.Identifier.GetHashCode();

            int hashSubId = group.SubIdentifier == null ? 0 : group.SubIdentifier.GetHashCode();

            return hashId ^ hashSubId;
        }
    }
}
