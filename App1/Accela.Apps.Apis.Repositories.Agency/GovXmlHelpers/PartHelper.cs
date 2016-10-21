using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels;
using Accela.Apps.Apis.Models.DomainModels.PartModels;
using Accela.Automation.GovXmlClient.Model;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    public class PartHelper : GovXmlHelperBase
    {
        public static PartModel ToClientPart(Part xmlPart)
        {
            if (xmlPart == null) return null;

            var clientPart = new PartModel
            {
                Id = xmlPart.keys.ToStringKeys(),
                Display = xmlPart.identifierDisplay,
                UnitCost = xmlPart.UnitCost,
                PartNumber = xmlPart.PartNumber,
                Bin = xmlPart.bin,
                Quantity = xmlPart.Quantity,
                TransactionDate = xmlPart.TransactionDate,
                Comments = xmlPart.Comments,
                Taxable = xmlPart.Taxable,
                AltID = xmlPart.AltID,
                WorkOrderTaskCode = xmlPart.WorkOrderTaskCode,
                WorkOrderTaskCodeIndex = xmlPart.WorkOrderTaskCodeIndex
            };

            if (xmlPart.PartInventoryId != null)
            {
                clientPart.PartInventory = new PartInventoryModel
                {
                    Identifier = xmlPart.PartInventoryId.keys.ToStringKeys(),
                    Display = xmlPart.PartInventoryId.identifierDisplay
                };
            }

            if (xmlPart.UnitOfMeasurementIdentifier != null)
            {
                clientPart.PartUnitOfMeasurement = new PartUnitOfMeasurementModel
                {
                    Identifier = xmlPart.UnitOfMeasurementIdentifier.keys.ToStringKeys(),
                    Display = xmlPart.UnitOfMeasurementIdentifier.identifierDisplay
                };
            }

            if (xmlPart.PartDescriptionIdentifier != null)
            {
                clientPart.PartDescription = new PartDescriptionModel
                {
                    Identifier = xmlPart.PartDescriptionIdentifier.keys.ToStringKeys(),
                    Display = xmlPart.PartDescriptionIdentifier.identifierDisplay
                };
            }
            
            if (xmlPart.PartBrandIdentifier != null)
            {
                clientPart.PartBrand = new PartBrandModel
                {
                    Identifier = xmlPart.PartBrandIdentifier.keys.ToStringKeys(),
                    Display = xmlPart.PartBrandIdentifier.identifierDisplay
                };
            }

            if (xmlPart.PartType != null)
            {
                clientPart.PartType = new PartTypeModel
                {
                    Identifier = xmlPart.PartType.keys.ToStringKeys(),
                    Display = xmlPart.PartType.identifierDisplay
                };
            }
            
            if (xmlPart.Status != null)
            {
                clientPart.PartStatus = new PartStatusModel
                {
                    Identifier = xmlPart.Status.keys.ToStringKeys(),
                    Name = xmlPart.Status.name,
                    Value = xmlPart.Status.val,
                    Date = xmlPart.Status.date,
                    Time = xmlPart.Status.time
                };
            }
            
            if (xmlPart.Supplies != null && xmlPart.Supplies.Supply != null && xmlPart.Supplies.Supply.Length > 0)
            {
                clientPart.PartSupplies = new List<PartSupplyModel>();
                foreach (var item in xmlPart.Supplies.Supply)
                {
                    var clientSupply = new PartSupplyModel
                    {
                        Identifier = item.Keys.ToStringKeys(),
                        Display = item.IdentifierDisplay,
                        LocationName = item.LocationName,
                        LocationSeq = item.LocationSeq
                    };

                    clientPart.PartSupplies.Add(clientSupply);
                }
            }

            if (xmlPart.BudgetAccount != null)
            {
                clientPart.BudgetAccount = new BudgetAccountModel
                {
                    Id = xmlPart.BudgetAccount.keys.ToStringKeys(),
                    Display = xmlPart.BudgetAccount.identifierDisplay
                };
            }

            if (xmlPart.BudgetNumber != null)
            {
                clientPart.BudgetNumber = new BudgetNumberModel
                {
                    Id = xmlPart.BudgetNumber.keys.ToStringKeys(),
                    Display = xmlPart.BudgetNumber.identifierDisplay
                };
            }

            return clientPart;
        }
    }
}
