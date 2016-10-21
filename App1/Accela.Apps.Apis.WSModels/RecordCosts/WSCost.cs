using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.CostModels;

namespace Accela.Apps.Apis.WSModels.RecordCosts
{
    [DataContract(Name = "cost")]
    public class WSCost : WSEntityState
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
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false)]
        public WSCostType Type { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [DataMember(Name = "date", EmitDefaultValue = false)]
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public double Quantity { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public WSCostStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the fixedRate.
        /// </summary>
        [DataMember(Name = "fixedRate", EmitDefaultValue = false)]
        public double FixedRate { get; set; }

        /// <summary>
        /// Gets or sets the costFactor.
        /// </summary>
        [DataMember(Name = "costFactor", EmitDefaultValue = false)]
        public string CostFactor { get; set; }

        /// <summary>
        /// Gets or sets the costFactor.
        /// </summary>
        [DataMember(Name = "unitRate", EmitDefaultValue = false)]
        public double UnitRate { get; set; }

        /// <summary>
        /// Gets or sets the costUnitOfMeasureIdentifier.
        /// </summary>
        [DataMember(Name = "unitOfMeasure ", EmitDefaultValue = false)]
        public WSCostUnitOfMeasure UnitOfMeasure;

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
        public WSCostAccount CostAccount { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        [DataMember(Name = "comments", EmitDefaultValue = false)]
        public string Comments { get; set; }

        #region Joe Add Some nessaray Properties for Creating Record

        [DataMember(Name = "itemType", EmitDefaultValue = false)]
        public WSCostItemType CostItemType { get; set; }

        [DataMember(Name = "unitOfMeasureValue", EmitDefaultValue = false)]
        public string UnitOfMeasureValue { get; set; }

        #endregion

        [DataMember(Name = "costQuantities", EmitDefaultValue = false)]
        public List<WSCostQuantity> CostQuantities;

        [DataMember(Name = "startTime", EmitDefaultValue = false)]
        public string StartTime;

        [DataMember(Name = "endTime", EmitDefaultValue = false)]
        public string EndTime;

        [DataMember(Name = "workOrderTask", EmitDefaultValue = false)]
        public string WorkOrderTaskCode;

        [DataMember(Name = "workOrderTaskIndex", EmitDefaultValue = false)]
        public string WorkOrderTaskCodeIndex;

        /// <summary>
        /// Convert CostModel to WSCost.
        /// </summary>
        /// <param name="cost">CostModel.</param>
        /// <returns>WSCost.</returns>
        public static WSCost FromEntityModel(CostModel cost)
        {
            if (cost == null) return null;

            var wsCost = new WSCost
            {
                Id = cost.Id,
                Display = cost.Display,
                Type = WSCostType.FromEntiyModel(cost.Type),
                Date = cost.CostDate,
                Quantity = cost.Quantity,
                Status = WSCostStatus.FromEntityModel(cost.Status),
                FixedRate = cost.CostFix,
                CostFactor = cost.CostFactor,
                UnitRate = cost.UnitCost,
                UnitOfMeasure = WSCostUnitOfMeasure.FromEntityModel(cost.CostUnitOfMeasure),
                TotalCost = cost.TotalCost,
                Formula = cost.Formula,
                SubGroup = cost.SubGroup,
                CostAccount = WSCostAccount.FromEntityModel(cost.CostAccount),
                Comments = cost.Comments,
                EntityState = WSEntityState.ConvertActionToEntityState(cost.Action),
                CostItemType = cost.CostItemType == null
                    ? null
                    : new WSCostItemType { Id = cost.CostItemType.Identifier, Display = cost.CostItemType.Display },
                UnitOfMeasureValue = cost.UnitOfMeasureValue,
                StartTime = cost.StartTime,
                EndTime = cost.EndTime,
                WorkOrderTaskCode = cost.WorkOrderTaskCode,
                WorkOrderTaskCodeIndex = cost.WorkOrderTaskCodeIndex
            };

            if (cost.CostQuantities == null || cost.CostQuantities.Count <= 0) return wsCost;

            wsCost.CostQuantities = new List<WSCostQuantity>(cost.CostQuantities.Count);

            cost.CostQuantities.ForEach(item =>
            {
                if (item != null) wsCost.CostQuantities.Add(WSCostQuantity.FromEntityModel(item));
            });

            return wsCost;
        }


        internal static CostModel ToEntityModel(WSCost wsCost)
        {
            if (wsCost == null) return null;

            var result = new CostModel
            {
                Id = wsCost.Id,
                Display = wsCost.Display,
                CostDate = wsCost.Date,
                Quantity = wsCost.Quantity,
                CostFix = wsCost.FixedRate,
                CostFactor = wsCost.CostFactor,
                UnitCost = wsCost.UnitRate,
                TotalCost = wsCost.TotalCost,
                Formula = wsCost.Formula,
                SubGroup = wsCost.SubGroup,
                Comments = wsCost.Comments,
                Action = WSEntityState.ConvertEntityStateToAction(wsCost.EntityState),
                UnitOfMeasureValue = wsCost.UnitOfMeasureValue,
                Type = wsCost.Type == null
                    ? null
                    : new CostTypeModel
                    {
                        Id = wsCost.Type.Id,
                        Display = wsCost.Type.Display
                    },

                Status = wsCost.Status == null
                    ? null
                    : new CostStatusModel
                    {
                        Id = wsCost.Status.Id,
                        Display = wsCost.Status.Display
                    },
                CostUnitOfMeasure = wsCost.UnitOfMeasure == null
                    ? null
                    : new CostUnitOfMeasureModel
                    {
                        Identifier = wsCost.UnitOfMeasure.Id,
                        Display = wsCost.UnitOfMeasure.Display
                    },

                CostAccount = wsCost.CostAccount == null
                    ? null
                    : new CostAccountModel
                    {
                        Identifier = wsCost.CostAccount.Id,
                        Display = wsCost.CostAccount.Display
                    },
                CostItemType = wsCost.CostItemType == null
                    ? null
                    : new CostItemTypeModel()
                    {
                        Identifier = wsCost.CostItemType.Id,
                        Display = wsCost.CostItemType.Display
                    },
                StartTime = wsCost.StartTime,
                EndTime = wsCost.EndTime,
                WorkOrderTaskCode = wsCost.WorkOrderTaskCode,
                WorkOrderTaskCodeIndex = wsCost.WorkOrderTaskCodeIndex
            };


            if (wsCost.CostQuantities != null && wsCost.CostQuantities.Count > 0)
            {
                result.CostQuantities = new List<CostQuantityModel>(wsCost.CostQuantities.Count);

                wsCost.CostQuantities.ForEach(item =>
                {
                    if (item != null) result.CostQuantities.Add(WSCostQuantity.ToEntityModel(item));
                });

            }

            return result;
        }
    }

    [DataContract]
    public class WSCostQuantity
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public double Quantity { get; set; }

        public static WSCostQuantity FromEntityModel(CostQuantityModel entityCostQuantity)
        {
            if (entityCostQuantity == null)
            {
                return null;
            }

            return new WSCostQuantity
            {
                Id = entityCostQuantity.Id,
                Display = entityCostQuantity.Display,
                Quantity = entityCostQuantity.Quantity
            };
        }

        public static CostQuantityModel ToEntityModel(WSCostQuantity wsCostQuantity)
        {
            if (wsCostQuantity == null)
            {
                return null;
            }

            return new CostQuantityModel
            {
                Id = wsCostQuantity.Id,
                Display = wsCostQuantity.Display,
                Quantity = wsCostQuantity.Quantity
            };
        }
    }
}
