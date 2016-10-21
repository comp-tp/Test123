using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.CostModels
{
    [DataContract]
    public class CostModel : ActionDataModel
    {
        /// <summary>
        /// Gets or sets the parcel Id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the parcel display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the contextType.
        /// </summary>
        [DataMember(Name = "contextType", EmitDefaultValue = false)]
        public string ContextType { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public CostTypeModel Type { get; set; }

        /// <summary>
        /// Gets or sets the costDate.
        /// </summary>
        [DataMember(Name = "costDate", EmitDefaultValue = false)]
        public string CostDate { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public CostStatusModel Status;

        /// <summary>
        /// Gets or sets the costFix.
        /// </summary>
        [DataMember(Name = "costFix", EmitDefaultValue = false)]
        public double CostFix { get; set; }

        /// <summary>
        /// Gets or sets the costFactor.
        /// </summary>
        [DataMember(Name = "costFactor", EmitDefaultValue = false)]
        public string CostFactor { get; set; }

        /// <summary>
        /// Gets or sets the costFactor.
        /// </summary>
        [DataMember(Name = "unitCost", EmitDefaultValue = false)]
        public double UnitCost { get; set; }

        /// <summary>
        /// Gets or sets the costUnitOfMeasureId.
        /// </summary>
        [DataMember(Name = "costUnitOfMeasure", EmitDefaultValue = false)]
        public CostUnitOfMeasureModel CostUnitOfMeasure { get; set; }

        /// <summary>
        /// Gets or sets the totalCost.
        /// </summary>
        [DataMember(Name = "totalCost", EmitDefaultValue = false)]
        public double TotalCost { get; set; }

        /// <summary>
        /// Gets or sets the formula.
        /// </summary>
        [DataMember(Name = "formula", EmitDefaultValue = false)]
        public string Formula { get; set; }

        /// <summary>
        /// Gets or sets the subGroup.
        /// </summary>
        [DataMember(Name = "subGroup", EmitDefaultValue = false)]
        public string SubGroup { get; set; }

        /// <summary>
        /// Gets or sets the costAccountId.
        /// </summary>
        [DataMember(Name = "costAccount", EmitDefaultValue = false)]
        public CostAccountModel CostAccount { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; set; }

        #region Joe Add Some nessaray Properties for Creating Record

        [DataMember(Name = "itemType", EmitDefaultValue = false)]
        public CostItemTypeModel CostItemType { get; set; }

        [DataMember(Name = "unitOfMeasureValue", EmitDefaultValue = false)]
        public string UnitOfMeasureValue { get; set; }

        #endregion

        [DataMember(Name = "CostQuantities", EmitDefaultValue = false)]
        public List<CostQuantityModel> CostQuantities;

        [DataMember(Name = "startTime", EmitDefaultValue = false)]
        public string StartTime;

        [DataMember(Name = "endTime", EmitDefaultValue = false)]
        public string EndTime;

        [DataMember(Name = "workOrderTask", EmitDefaultValue = false)]
        public string WorkOrderTaskCode;

        [DataMember(Name = "workOrderTaskCodeIndex", EmitDefaultValue = false)]
        public string WorkOrderTaskCodeIndex;
    }

    [DataContract]
    public class CostQuantityModel : IdentifierBase2
    {
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public double Quantity { get; set; }
    }
}
