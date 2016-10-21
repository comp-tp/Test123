using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.AdditionalModels;

namespace Accela.Apps.Apis.WSModels.ASIs
{
    /// <summary>
    /// Additional table model.
    /// contains ASI/ASIT info.
    /// </summary>
    [DataContract(Name = "ASIT")]
    public class WSASIT
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember(Name = "id", EmitDefaultValue = false, Order = 1)]
        public string Id { get; set; }

        [DataMember(Name = "subId", EmitDefaultValue = false, Order = 4)]
        public string SubId { get; set; }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        /// <value>
        /// The display.
        /// </value>
        [DataMember(Name = "display", EmitDefaultValue = false, Order = 2)]
        public string Display { get; set; }

        [DataMember(Name = "subDisplay", EmitDefaultValue = false, Order = 5)]
        public string SubDisplay { get; set; }

        /// <summary>
        /// Gets or sets the data columns.
        /// </summary>
        /// <value>
        /// The data columns.
        /// </value>
        [DataMember(Name = "columns", EmitDefaultValue = false, Order = 9)]
        public List<WSASIColumn> Columns
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
        public List<WSASIRow> Rows
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
        public List<WSDrillDownSeries> DrillDownSeries
        {
            get; 
            set;
        }

        [DataMember(Name = "subAlias", EmitDefaultValue = false)]
        public string SubAlias { get; set; }

        /// <summary>
        /// Convert WSASIT to AdditionalTableModel.
        /// </summary>
        /// <param name="wsASIT">WSASIT.</param>
        /// <returns>AdditionalTableModel.</returns>
        public static AdditionalTableModel ToEntityModel(WSASIT wsASIT)
        {
            if (wsASIT != null)
            {
                return new AdditionalTableModel()
                {
                    Identifier = wsASIT.Id,
                    Display = wsASIT.Display,
                    SubDisplay=wsASIT.SubDisplay,
                    Description = wsASIT.Description,
                    ContextType = wsASIT.ContextType,
                    Security = wsASIT.Security,
                    SubIdentifier = wsASIT.SubId,
                    SubSecurity = wsASIT.SubSecurity,
                    Columns = WSASIColumn.ToEntityModels(wsASIT.Columns),
                    Rows = WSASIRow.ToEnityModels(wsASIT.Rows)
                    
                };
            }

            return null;
        }

        public static List<AdditionalTableModel> ToEntityModels(List<WSASIT> wsASITs)
        {
            List<AdditionalTableModel> additionalTableModels = new List<AdditionalTableModel>();
            if (wsASITs != null && wsASITs.Count > 0)
            {
                wsASITs.ForEach(asit => additionalTableModels.Add(ToEntityModel(asit)));
            }
            return additionalTableModels;
        }
    }
}
