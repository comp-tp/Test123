using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Apis.WSModels.Records;
using NUnit.Framework;
using Newtonsoft.Json;
using Accela.Apps.Shared;

namespace Accela.Apps.Apis.Repositories.Agency.Tests
{
    [TestFixture]
    public class RecordHelperTest
    {
        [Test]
        public void TestToGovXML()
        {
            string jsonString = TestDataUtil.LoadTestData("updateRecord_v3.json");
            // NOTE: can't use JsonConverter which uses .NET JSON convert and honor data abstract and does not ignore null; incomplete JSON cause object deseirliazed as null
            var updateRequest = JsonConvert.DeserializeObject<WSUpdateRecordRequest>(jsonString);
            var updateRecordRequest = WSUpdateRecordRequest.ToEntityModel(updateRequest);
            RecordHelper recordHelper = new RecordHelper("733");
            GovXML govXmlIn = new GovXML();
            govXmlIn.UpdateCAP = recordHelper.ToXmlUpdateRecord(updateRecordRequest.Record);
            Assert.AreNotEqual(null, govXmlIn.UpdateCAP.CAPDetail);
            Assert.AreEqual("16CAP-00000-000HO", govXmlIn.UpdateCAP.capId.keys.ToStringKeys());
            Assert.AreEqual("TEST", govXmlIn.UpdateCAP.description);
            Assert.AreEqual("2016-04-28", govXmlIn.UpdateCAP.fileDate);
            Assert.AreEqual("TEST/NA/NA/NA", govXmlIn.UpdateCAP.CAPDetail.AsgnDept);
            Assert.AreEqual("SCARTER2", govXmlIn.UpdateCAP.CAPDetail.AsgnStaff);

        }

    }
}
