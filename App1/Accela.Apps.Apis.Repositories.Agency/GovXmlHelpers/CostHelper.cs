using Accela.Apps.Apis.Models.DomainModels.CostModels;
using Accela.Automation.GovXmlClient.Model;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using System;
using System.Collections.Generic;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    /// <summary>
    /// Cost helper for translate govxml to model.
    /// </summary>
    public static class CostHelper
    {
        /// <summary>
        /// Convert CostItem to CostModel.
        /// </summary>
        /// <param name="xmlCost">CostItem.</param>
        /// <returns>CostModel.</returns>
        public static CostModel ToClientCost(CostItem xmlCost)
        {
            CostModel costModel = null;
            if (xmlCost != null)
            {
                costModel = new CostModel
                {
                    Id = xmlCost.keys.ToStringKeys(),
                    Display = xmlCost.identifierDisplay,
                    ContextType = xmlCost.contextType,
                    Type = ToCostType(xmlCost.type),
                    CostDate = xmlCost.CostDate,
                    Quantity = xmlCost.Quantity,
                    Status = ToStatus(xmlCost.Status),
                    CostFix = xmlCost.CostFix,
                    CostFactor = xmlCost.CostFactor,
                    UnitCost = xmlCost.UnitCost,
                    CostUnitOfMeasure = ToCostCostUnitOfMeasureId(xmlCost.CostUnitOfMeasureIdentifier),
                    TotalCost = xmlCost.TotalCost,
                    Formula = xmlCost.Formula,
                    SubGroup = xmlCost.SubGroup,
                    CostAccount = ToCostAccountId(xmlCost.CostAccountIdentifier),
                    Comments = xmlCost.Comments,
                    UnitOfMeasureValue = xmlCost.UnitOfMeasure,
                    CostItemType = ToCostItemtypeId(xmlCost.CostItemTypeId),
                    StartTime = xmlCost.StartTime,
                    EndTime = xmlCost.EndTime,
                    WorkOrderTaskCode = xmlCost.WorkOrderTaskCode,
                    WorkOrderTaskCodeIndex = xmlCost.WorkOrderTaskCodeIndex,
                    CostQuantities = ToClientCostQuantities(xmlCost.CostQuantities)
                };
            }

            return costModel;
        }

        private static List<CostQuantityModel> ToClientCostQuantities(CostQuantities xmlCostQuantities)
        {
            if (xmlCostQuantities == null 
                || xmlCostQuantities.CostQuantity == null 
                || xmlCostQuantities.CostQuantity.Length <= 0) return null;

            var results = new List<CostQuantityModel>(xmlCostQuantities.CostQuantity.Length);

            xmlCostQuantities.CostQuantity.ForEach(item =>
            {
                if (item != null && item.costFactor != null) results.Add(ToClientCostQuantity(item));
            });

            return results;
        }

        private static CostQuantityModel ToClientCostQuantity(CostQuantity xmlCostQuantity)
        {
            var quantity = 0.0;
            Double.TryParse(xmlCostQuantity.quantity, out quantity);
            return new CostQuantityModel
            {
                Id = xmlCostQuantity.costFactor.keys.ToStringKeys(),
                Display = xmlCostQuantity.costFactor.identifierDisplay,
                Quantity = quantity
            };
        }

        private static CostItemTypeModel ToCostItemtypeId(Identifier itemTypeId)
        {
            if(itemTypeId !=null )
            {
                return new CostItemTypeModel()
                           {
                               Identifier = itemTypeId.keys.ToStringKeys(),
                               Display = itemTypeId.identifierDisplay
                           };
            }
            return null;
        }

        /// <summary>
        /// Convert Type to CostTypeModel.
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns>CostTypeModel.</returns>
        private static CostTypeModel ToCostType(Accela.Automation.GovXmlClient.Model.Type type)
        {
            if (type != null)
            {
                var costTypeModel = new CostTypeModel();
                costTypeModel.Id = KeysHelper.ToStringKeys(type.keys);
                costTypeModel.Display = type.identifierDisplay;
                return costTypeModel;

            }
            return null;
        }        

        /// <summary>
        /// Convert AAMStatus to AAMStatusModel.
        /// </summary>
        /// <param name="aamStatus">AAMStatus.</param>
        /// <returns>AAMStatusModel.</returns>
        private static CostStatusModel ToStatus(AAMStatus aamStatus)
        {
            if (aamStatus != null)
            {
                return new CostStatusModel()
                {
                    Id = KeysHelper.ToStringKeys(aamStatus.keys),
                    Display = aamStatus.name
                };
            }
            return null;
        
        }

        /// <summary>
        /// Convert CostUnitOfMeasureIdentifier to CostUnitOfMeasureIdModel.
        /// </summary>
        /// <param name="costUnitOfMeasureIdentifier">CostUnitOfMeasureIdentifier.</param>
        /// <returns>CostUnitOfMeasureIdModel.</returns>
        private static CostUnitOfMeasureModel ToCostCostUnitOfMeasureId(CostUnitOfMeasureIdentifier costUnitOfMeasureIdentifier)
        {
            if (costUnitOfMeasureIdentifier != null)
            {
                return new CostUnitOfMeasureModel()
                {
                    Identifier = KeysHelper.ToStringKeys(costUnitOfMeasureIdentifier.keys),
                    Display = costUnitOfMeasureIdentifier.identifierDisplay
                };
            }
            return null;
        }

        /// <summary>
        /// Convert CostAccountIdentifier to CostAccountIdModel.
        /// </summary>
        /// <param name="costAccountIdentifier">CostAccountIdentifier.</param>
        /// <returns>CostAccountIdModel.</returns>
        private static CostAccountModel ToCostAccountId(CostAccountIdentifier costAccountIdentifier)
        {
            if (costAccountIdentifier != null)
            {
                return new CostAccountModel()
                {
                    Identifier = KeysHelper.ToStringKeys(costAccountIdentifier.keys),
                    Display = costAccountIdentifier.identifierDisplay
                };
            }
            return null;
        }
    }
}
