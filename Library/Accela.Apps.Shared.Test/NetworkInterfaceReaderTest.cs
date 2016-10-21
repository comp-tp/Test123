using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Accela.Apps.Shared.Utils;

namespace Accela.Apps.Shared.Test
{
    [TestFixture]
    public class NetworkInterfaceReaderTest
    {
        [Test]
        public void GetMachineMacAddress_ShouldReturnMACAddr()
        {
            var macAddr = NetworkInterfaceReader.GetMachineMacAddress();
            Assert.IsNotNull(macAddr);
            Assert.AreEqual(12, macAddr.Length);
        }

        [Test]
        public void GetMachineIP_ShouldReturnLocalIP()
        {
            var ip = NetworkInterfaceReader.GetMachineIP();
            Assert.IsNotNull(ip);
            var segent = ip.ToString().Split(new char[]{'.'});
            Assert.AreEqual(4,segent.Length);
        }
    }
}
