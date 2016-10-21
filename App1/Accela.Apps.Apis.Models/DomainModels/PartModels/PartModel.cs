using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.Models.DomainModels.PartModels
{
    /// <summary>
    /// The part data model
    /// </summary>
    [DataContract]
    public class PartModel : ActionDataModel
    {
        /// <summary>
        /// Gets or sets the part id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the part display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the partInventory.
        /// </summary>
        [DataMember(Name = "partInventory", EmitDefaultValue = false)]
        public PartInventoryModel PartInventory { get; set; }

        /// <summary>
        /// Gets or sets the part unitCost.
        /// </summary>
        [DataMember(Name = "unitCost", EmitDefaultValue = false)]
        public double UnitCost { get; set; }

        /// <summary>
        /// Gets or sets the part unitOfMeasure.
        /// </summary>
        [DataMember(Name = "partUnitOfMeasurement", EmitDefaultValue = false)]
        public PartUnitOfMeasurementModel PartUnitOfMeasurement { get; set; }

        /// <summary>
        /// Gets or sets the part partNumber.
        /// </summary>
        [DataMember(Name = "partNumber", EmitDefaultValue = false)]
        public string PartNumber { get; set; }

        /// <summary>
        /// Gets or sets the part bin.
        /// </summary>
        [DataMember(Name = "bin", EmitDefaultValue = false)]
        public string Bin { get; set; }

        /// <summary>
        /// Gets or sets the part quantity.
        /// </summary>
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the part transactionDate.
        /// </summary>
        [DataMember(Name = "transactionDate", EmitDefaultValue = false)]
        public string TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the part comments.
        /// </summary>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets the part partDescription.
        /// </summary>
        [DataMember(Name = "partDescription", EmitDefaultValue = false)]
        public PartDescriptionModel PartDescription { get; set; }

        /// <summary>
        /// Gets or sets the part partBrand.
        /// </summary>
        [DataMember(Name = "partBrand", EmitDefaultValue = false)]
        public PartBrandModel PartBrand { get; set; }

        /// <summary>
        /// Gets or sets the part taxable.
        /// </summary>
        [DataMember(Name = "taxable", EmitDefaultValue = false)]
        public string Taxable { get; set; }

        /// <summary>
        /// Gets or sets the part altID.
        /// </summary>
        [DataMember(Name = "altID", EmitDefaultValue = false)]
        public string AltID { get; set; }

        /// <summary>
        /// Gets or sets the part type.
        /// </summary>
        [DataMember(Name = "partType", EmitDefaultValue = false)]
        public PartTypeModel PartType { get; set; }

        /// <summary>
        /// Gets or sets the part status.
        /// </summary>
        [DataMember(Name = "partStatus", EmitDefaultValue = false)]
        public PartStatusModel PartStatus { get; set; }

        /// <summary>
        /// Gets or sets the part supplies.
        /// </summary>
        [DataMember(Name = "partSupplies", EmitDefaultValue = false)]
        public List<PartSupplyModel> PartSupplies { get; set; }

        [DataMember(Name = "workOrderTask", EmitDefaultValue = false)]
        public string WorkOrderTaskCode;

        [DataMember(Name = "workOrderTaskIndex", EmitDefaultValue = false)]
        public string WorkOrderTaskCodeIndex;
        
        [DataMember(Name = "budgetAccount", EmitDefaultValue = false)]
        public BudgetAccountModel BudgetAccount;
        
        [DataMember(Name = "budgetNumber", EmitDefaultValue = false)]
        public BudgetNumberModel BudgetNumber;
    }

    [DataContract]
    public class BudgetAccountModel : IdentifierBase2
    {
    }

    [DataContract]
    public class BudgetNumberModel : IdentifierBase2
    {
    }
}
