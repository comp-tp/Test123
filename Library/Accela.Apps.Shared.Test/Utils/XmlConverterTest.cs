using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Accela.Apps.Shared.Contexts;

namespace Accela.Apps.Shared.Test
{
    [TestFixture]
    public class XmlConverterTest
    {
        private static string XML_TEST_STRING = "<?xml version=\"1.0\" encoding=\"utf-8\"?><UnKownContextUser xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Id>00000000-0000-0000-0000-000000000000</Id><Agency>ISLANDTON</Agency><AgencyID>00000000-0000-0000-0000-000000000000</AgencyID><LoginName>UNKNOWN-AGENCYUSERNAME</LoginName><Environment>TEST</Environment></UnKownContextUser>";

        [Test]
        public void ToXml()
        {
            var obj = new UnKownContextUser()
            {
                Agency = "ISLANDTON",
                Environment = "TEST"
            };
            var xmlString = XmlConverter.ToXml(obj);
            Assert.IsNotNullOrEmpty(xmlString);
            Assert.AreEqual(XML_TEST_STRING, xmlString);
        }

        [Test]
        public void FromXmlTo()
        {
            var obj = XmlConverter.FromXmlTo<UnKownContextUser>(XML_TEST_STRING);
            Assert.IsNotNull(obj);
            Assert.AreEqual("ISLANDTON", obj.Agency);
            Assert.AreEqual("TEST", obj.Environment);
        }
    }
}
