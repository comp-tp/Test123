using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Shared;
using NUnit.Framework;

namespace Accela.Apps.Apis.Repositories.Agency.Tests
{
    [TestFixture]
    public class InspectionHelperTest
    {
        [Test]
        public void TestToClientInspection()
        {
            string govxmlString = TestDataUtil.LoadTestData("GetInspectionsResponse_aa72.xml");
            GovXML testData = XmlConverter.FromXmlTo<GovXML>(govxmlString);
            GetInspectionsResponse govxmlInspections = testData.getInspectionsResponse;
            InspectionHelper helper = new InspectionHelper("720", false);
            List<InspectionModel> clientInspections = helper.ToClientInspections(govxmlInspections, null);
            InspectionModel inspection = clientInspections[0];
            Assert.IsNotNull(inspection);
        }

        [Test]
        public void TestToClientInspectionWithChecklistAsi()
        {
            string govxmlString = TestDataUtil.LoadTestData("GetInspectionsResponse_wCheclistAsiaa733.xml");
            GovXML testData = XmlConverter.FromXmlTo<GovXML>(govxmlString);
            GetInspectionsResponse govxmlInspections = testData.getInspectionsResponse;
            InspectionHelper helper = new InspectionHelper("733", false);
            List<InspectionModel> clientInspections = helper.ToClientInspections(govxmlInspections, null);
            InspectionModel inspection = clientInspections[0];
            Assert.IsNotNull(inspection);
            Assert.AreEqual(inspection.Checklists.Count, 1);
            Assert.AreEqual(inspection.Checklists[0].ChecklistItems.Count, 5);

            var item = inspection.Checklists[0].ChecklistItems[0];
            Assert.IsNull(item.AdditionalInfo);
            Assert.IsNull(item.AdditionalTableInfo);

            item = inspection.Checklists[0].ChecklistItems[1];
            Assert.IsNotNull(item.AdditionalInfo);
            Assert.IsNotNull(item.AdditionalTableInfo);
        }
    }
}
