using Accela.Apps.Apis.Repositories.GovXmlHelpers;
using Accela.Apps.Shared;
using Accela.Automation.GovXmlClient.Model;
using NUnit.Framework;

namespace Accela.Apps.Apis.Repositories.Agency.Tests.GovXmlHelpers
{
    [TestFixture]
    public class ASIHelperTest
    {
        [Test]
        public void TestToClientAdditionGroups()
        {
            string govxmlString = TestDataUtil.LoadTestData("AdditionalInformationResponse_aa72.xml");
            AdditionalInformation testData = XmlConverter.FromXmlTo<AdditionalInformation>(govxmlString);
            var resultData = ASIHelper.ToClientAdditionGroups(testData);
            Assert.AreEqual(resultData.Count, 2);
            var group = resultData[0];
            Assert.AreEqual(group.Identifier, "ABELTEST");
            Assert.AreEqual(group.SubGroups.Count, 1);

            var subgroup = group.SubGroups[0];
            Assert.AreEqual(subgroup.Identifier, "ABEL1");
            Assert.AreEqual(subgroup.Items.Count, 2);

            var item = subgroup.Items[0];
            Assert.AreEqual(item.Identifier, "one");
            Assert.AreEqual(item.Type, "Float");
        }
    }
}
