using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CloudParcelModels = Accela.Apps.Apis.Models.DomainModels.ParcelModels;
using Accela.ACA.WSProxy;
using Accela.Apps.Apis.Repositories.Citizen;

namespace Accela.Apps.Apis.Repositories.Citizen.CitizenHelpers
{
    public class CitizenParcelHelper
    {
        public static CapParcelModel ToACACapParcelModel(CloudParcelModels.ParcelModel cloudParcelModel, string serviceProviderCode)
        {
            CapParcelModel result = null;

            if (cloudParcelModel != null)
            {
                var acaParcelModel = new ACA.WSProxy.ParcelModel();
                //acaProxyParcelModel.? = parcelModel.Action;
                //acaProxyParcelModel.? = parcelModel.Addresses;
                acaParcelModel.block = cloudParcelModel.Block;
                //acaProxyParcelModel.? = cloudParcelModel.Description;
                //acaProxyParcelModel.? = parcelModel.Display;
                acaParcelModel.parcelNumber = cloudParcelModel.Id;
                acaParcelModel.legalDesc = cloudParcelModel.LegalDescription;
                acaParcelModel.lot = cloudParcelModel.Lot;
                //acaProxyParcelModel.? = parcelModel.Owners;
                acaParcelModel.range = cloudParcelModel.Range;
                int tempSection = 0;

                if (int.TryParse(cloudParcelModel.Section, out tempSection))
                {
                    acaParcelModel.section = tempSection;
                }

                acaParcelModel.parcelStatus = "A";
                acaParcelModel.subdivision = cloudParcelModel.Subdivision;
                //acaProxyParcelModel.? = parcelModel.Text;
                acaParcelModel.township = cloudParcelModel.Township;
                acaParcelModel.tract = cloudParcelModel.Tract;

                acaParcelModel.auditStatus = "A";
                acaParcelModel.primaryParcelFlag = "Y";
                acaParcelModel.capID = new CapIDModel();
                acaParcelModel.capID.serviceProviderCode = serviceProviderCode;


                result = new CapParcelModel();
                result.capIDModel = acaParcelModel.capID;
                //result.l1ParcelNo = acaParcelModel.parcelNumber;
                result.parcelModel = acaParcelModel;
                result.parcelNo = acaParcelModel.parcelNumber;
                result.parcelNumber = acaParcelModel.parcelNumber;
                //result.UID = acaParcelModel.UID;
            }

            return result;
        }

        public static CloudParcelModels.ParcelModel ToCloudParcelModel(ParcelModel acaParcelModel)
        {
            CloudParcelModels.ParcelModel result = null;

            if (acaParcelModel != null)
            {
                result = new CloudParcelModels.ParcelModel();
                result.Block = acaParcelModel.block;
                result.Id = acaParcelModel.parcelNumber;
                result.LegalDescription = acaParcelModel.legalDesc;
                result.Lot = acaParcelModel.lot;
                result.Range = acaParcelModel.range;
                result.Section = acaParcelModel.section != null ? acaParcelModel.section.Value.ToString() : String.Empty;
                result.Status = String.IsNullOrWhiteSpace(acaParcelModel.parcelStatus) ? null : new CloudParcelModels.ParcelStatusModel()
                {
                    Identifier = acaParcelModel.parcelStatus,
                    Display = acaParcelModel.parcelStatus
                };
                result.Subdivision = acaParcelModel.subdivision;
                //result.Text = acaParcelModel.tex
                result.Township = acaParcelModel.township;
                result.Tract = acaParcelModel.tract;
            }

            return result;
        }
    }
}
