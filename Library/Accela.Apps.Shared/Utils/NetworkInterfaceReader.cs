using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Shared.Utils
{
    public static class NetworkInterfaceReader
    {
        public static IPAddress GetMachineIP()
        {
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            IPAddress ipV4 = null;
            foreach (IPAddress item in addr)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipV4 = item;
                    break;
                }
            }

            return ipV4;
        }

        public static string GetMachineMacAddress()
        {
            string result = string.Empty;
            try
            {
                List<string> macs = new List<string>();
                NetworkInterface[] nis = NetworkInterface.GetAllNetworkInterfaces();

                if (nis != null && nis.Length > 0)
                {
                    result = nis[0].GetPhysicalAddress().ToString();
                }
            }

            catch
            { }

            return result;
        }
    }
}