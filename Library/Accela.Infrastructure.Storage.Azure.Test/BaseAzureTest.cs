using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.WindowsAzure.Storage;
using System.Diagnostics;
using Microsoft.WindowsAzure.Storage.RetryPolicies;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Accela.Infrastructure.Azure.Test
{

    [TestFixture]
    public abstract class BaseAzureTest
    {
        protected  CloudStorageAccount StorageAccount 
        {
            get
            {
                return CloudStorageAccount.DevelopmentStorageAccount;
            }
            set { }
        }

        protected virtual void InitializeSetup()
        {
        }

        protected virtual string StorageConnectionString
        {
            get
            {
                return "UseDevelopmentStorage=true;";
            }
        }

        [SetUp]
        public virtual void SetUp()
        {

            CloudStorageEmulatorShepherd shepherd = new CloudStorageEmulatorShepherd();
            shepherd.Start();
            InitializeSetup();
        }

        [TearDown]
        public virtual void TearDown()
        {


        }

        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
        }

       
        public static T Deserialize<T>(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return (T)new BinaryFormatter().Deserialize(ms);
            }
        }

    }

    public class CloudStorageEmulatorShepherd
    {
        public void Start()
        {
            try
            {
                if (!IsProcessOpen("AzureStorageEmulator"))
                {
                    var processStartInfo = new ProcessStartInfo()
                    {
                        FileName = Path.Combine(@"C:\Program Files (x86)\Microsoft SDKs\Azure\Storage Emulator", "AzureStorageEmulator.exe"),
                        Arguments = @" start",
                    };

                    using (var process = Process.Start(processStartInfo))
                    {
                        process.WaitForExit();
                    }
                }
            }
            catch (Exception ex)
            {
                var m = ex.Message;
            }
        }

        private bool IsProcessOpen(string name)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }
    }

}
