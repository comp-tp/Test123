using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Apis.Models.DomainModels.AssetModels;

namespace Accela.Apps.Apis.Repositories.Agency.GovXmlHelpers
{
    public class AssessmentHelper
    {
        public static AssetCA ToCovXmlAssessment(AssetCAModel assetCAModel)
        {
            AssetCA assetCA = null;
            if (assetCAModel != null)
            {
                assetCA = new AssetCA();

                assetCAModel.Asset.Action = "Update";
                assetCA.asset = AssetHelper.ToCovXmlAsset(assetCAModel.Asset);
                if (assetCAModel.Type != null)
                {
                    assetCA.assetCAType = new AssetCAType();
                    assetCA.assetCAType.keys = KeysHelper.CreateXMLKeys(assetCAModel.Type.Identifier);
                    assetCA.assetCAType.identifierDisplay = assetCAModel.Type.Display;
                }
                assetCA.comment = assetCAModel.Comment;
                assetCA.department = AssetHelper.ToGovXmlAssetCADepartment(assetCAModel.Department);
                assetCA.keys = KeysHelper.CreateXMLKeys(assetCAModel.Identifier);
                assetCA.assetCAId = assetCAModel.Identifier;
                assetCA.inspectionDate = assetCAModel.InspectionDate;
                assetCA.inspectionTime = assetCAModel.InspectionTime;
                if (assetCAModel.Observations != null && assetCAModel.Observations.Count > 0)
                {
                    assetCA.observation = new AdditionalInformation();
                    assetCA.observation.additionalInformationGroup = ASITHelper.BuildAsiAsit4Update(assetCAModel.Observations).ToArray();
                }
                assetCA.scheduleDate = assetCAModel.ScheduleDate;
                assetCA.scheduleTime = assetCAModel.ScheduleTime;
                assetCA.staffPerson = AssetHelper.ToGovXmlAssetCAStaffPerson(assetCAModel.StaffPerson);

                if (assetCAModel.Status != null)
                {
                    assetCA.status = new Status();
                    assetCA.status.keys = KeysHelper.CreateXMLKeys(assetCAModel.Status.Identifier);
                    assetCA.status.name = assetCAModel.Status.Name;
                    assetCA.status.IdentifierDisplay = assetCAModel.Status.Display;
                }

                double.TryParse(assetCAModel.TimeSpent, out assetCA.timeSpent);

                if (assetCAModel.AdditionalInformations != null && assetCAModel.AdditionalInformations.Count > 0)
                {
                    assetCA.additionalInformation = new AdditionalInformation();
                    assetCA.additionalInformation.additionalInformationGroup = ASIHelper.ToXMLAdditionalGroups(assetCAModel.AdditionalInformations).ToArray();
                }


            }
            return assetCA;
        }
    }
}
