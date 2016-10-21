using Accela.Apps.Apis.Models.DomainModels.PartModels;
using Accela.Apps.Shared.Utils;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Accela.Apps.Apis.WSModels.Parts
{
    [DataContract(Name = "part")]
    public class WSPart : WSEntityState
    {
        /// <summary>
        /// Gets or sets the transaction id.
        /// </summary>
        [DataMember(Name = "transactionId", EmitDefaultValue = false)]
        public string TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the part display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the part inventory.
        /// </summary>
        [DataMember(Name = "inventory", EmitDefaultValue = false)]
        public WSPartInventory Inventory { get; set; }

        /// <summary>
        /// Gets or sets the part unitCost.
        /// </summary>
        [DataMember(Name = "unitCost", EmitDefaultValue = false)]
        public double UnitCost { get; set; }

        /// <summary>
        /// Gets or sets the part unitCurrency.
        /// </summary>
        [DataMember(Name = "unitCurrency", EmitDefaultValue = false)]
        public WSPartUnitOfMeasurement UnitOfMeasurement { get; set; }

        /// <summary>
        /// Gets or sets the part id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

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
        /// Gets or sets the part description.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public WSPartDescription Description { get; set; }

        /// <summary>
        /// Gets or sets the part brand.
        /// </summary>
        [DataMember(Name = "brand", EmitDefaultValue = false)]
        public WSPartBrand Brand { get; set; }

        /// <summary>
        /// Gets or sets the part taxable.
        /// </summary>
        [DataMember(Name = "taxable", EmitDefaultValue = false)]
        public bool? Taxable { get; set; }

        /// <summary>
        /// Gets or sets the part altId.
        /// </summary>
        [DataMember(Name = "altId", EmitDefaultValue = false)]
        public string AltId { get; set; }

        /// <summary>
        /// Gets or sets the part type.
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public WSPartType Type { get; set; }

        /// <summary>
        /// Gets or sets the part status.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public WSPartStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the part supplies.
        /// </summary>
        [DataMember(Name = "supplies", EmitDefaultValue = false)]
        public List<WSPartSupply> Supplies { get; set; }

        [DataMember(Name = "workOrderTask", EmitDefaultValue = false)]
        public string WorkOrderTaskCode;

        [DataMember(Name = "workOrderTaskIndex", EmitDefaultValue = false)]
        public string WorkOrderTaskCodeIndex;

        [DataMember(Name = "budgetAccount", EmitDefaultValue = false)]
        public WSBudgetAccount BudgetAccount;

        [DataMember(Name = "budgetNumber", EmitDefaultValue = false)]
        public WSBudgetNumber BudgetNumber;

        public static WSPart FromEntityModel(PartModel part)
        {
            if (part == null)
            {
                return null;
            }

            return new WSPart
            {
                TransactionId = part.Id,
                Display = part.Display,
                Inventory = WSPartInventory.FromEntityModel(part.PartInventory),
                UnitCost = part.UnitCost,
                UnitOfMeasurement = WSPartUnitOfMeasurement.FromEntityModel(part.PartUnitOfMeasurement),
                Id = part.PartNumber,
                Bin = part.Bin,
                Quantity = part.Quantity,
                TransactionDate = part.TransactionDate,
                Comments = part.Comments,
                Description = WSPartDescription.FromEntityModel(part.PartDescription),
                Brand = WSPartBrand.FromEntityModel(part.PartBrand),
                Taxable = BoolHelper.GetBooleanByString(part.Taxable),
                AltId = part.AltID,
                Type = WSPartType.FromEntityModel(part.PartType),
                Status = WSPartStatus.FromEntityModel(part.PartStatus),
                Supplies = WSPartSupply.FromEntityModels(part.PartSupplies),
                EntityState = WSEntityState.ConvertActionToEntityState(part.Action),
                WorkOrderTaskCode = part.WorkOrderTaskCode,
                WorkOrderTaskCodeIndex = part.WorkOrderTaskCodeIndex,
                BudgetAccount = WSBudgetAccount.FromEntityModel(part.BudgetAccount),
                BudgetNumber = WSBudgetNumber.FromEntityModel(part.BudgetNumber)
            };
        }

        public static PartModel ToEntityModel(WSPart wsPart)
        {
            if (wsPart == null)
            {
                return null;
            }

            return new PartModel
            {
                Action = WSEntityState.ConvertEntityStateToAction(wsPart.EntityState),
                Id = wsPart.TransactionId,
                Display = wsPart.Display,
                UnitCost = wsPart.UnitCost,
                PartNumber = wsPart.Id,
                Quantity = wsPart.Quantity,
                TransactionDate = wsPart.TransactionDate,
                Comments = wsPart.Comments,
                AltID = wsPart.AltId,
                PartInventory = WSPartInventory.ToEntityModel(wsPart.Inventory),
                PartUnitOfMeasurement = WSPartUnitOfMeasurement.ToEntityModel(wsPart.UnitOfMeasurement),
                PartDescription = WSPartDescription.ToEntityModel(wsPart.Description),
                PartBrand = WSPartBrand.ToEntityModel(wsPart.Brand),
                PartType = WSPartType.ToEntityModel(wsPart.Type),
                Taxable = BoolHelper.ToBoolString(wsPart.Taxable, BoolHelper.BoolStringType.YOrN),
                PartStatus = WSPartStatus.ToEntityModel(wsPart.Status),
                PartSupplies = WSPartSupply.ToEntityModels(wsPart.Supplies),
                WorkOrderTaskCode = wsPart.WorkOrderTaskCode,
                WorkOrderTaskCodeIndex = wsPart.WorkOrderTaskCodeIndex,
                Bin = wsPart.Bin,
                BudgetAccount = WSBudgetAccount.ToEntityModel(wsPart.BudgetAccount),
                BudgetNumber = WSBudgetNumber.ToEntityModel(wsPart.BudgetNumber)
            };
        }
    }

    [DataContract(Name = "budgetAccount")]
    public class WSBudgetAccount : WSIdentifierBase
    {
        public static WSBudgetAccount FromEntityModel(BudgetAccountModel budgetAccount)
        {
            if (budgetAccount == null)
            {
                return null;
            }

            return new WSBudgetAccount
            {
                Id = budgetAccount.Id,
                Display = budgetAccount.Display
            };
        }

        public static BudgetAccountModel ToEntityModel(WSBudgetAccount wsBudgetAccount)
        {
            if (wsBudgetAccount == null)
            {
                return null;
            }

            return new BudgetAccountModel
            {
                Id = wsBudgetAccount.Id,
                Display = wsBudgetAccount.Display
            };
        }
    }

    [DataContract(Name = "budgetNumber")]
    public class WSBudgetNumber : WSIdentifierBase
    {
        public static WSBudgetNumber FromEntityModel(BudgetNumberModel budgetNumber)
        {
            if (budgetNumber == null)
            {
                return null;
            }

            return new WSBudgetNumber
            {
                Id = budgetNumber.Id,
                Display = budgetNumber.Display
            };
        }

        public static BudgetNumberModel ToEntityModel(WSBudgetNumber wsBudgetNumber)
        {
            if (wsBudgetNumber == null)
            {
                return null;
            }

            return new BudgetNumberModel
            {
                Id = wsBudgetNumber.Id,
                Display = wsBudgetNumber.Display
            };
        }
    }
}
