using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Apps.Apis.Repositories.Agency.Tests
{
    public class TestDataUtil
    {
        public static string LoadTestData(string fileName)
        {
            FileStream file = File.OpenRead("../../TestData/" + fileName);
            byte[] data = new byte[file.Length];
            try
            {
                file.Read(data, 0, data.Length);
            }
            finally
            {
                file.Close();
            }
            return Encoding.UTF8.GetString(data);
        }
    }
}
