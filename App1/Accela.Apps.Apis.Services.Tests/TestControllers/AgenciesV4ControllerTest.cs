//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Accela.Apps.Apis.Services.Tests.Bootstrap;
//using SimpleInjector;
//using Accela.Apps.Apis.Services.V4;
//using Accela.Core.Ioc;
//using Accela.Apps.Apis.BusinessEntities.Interfaces;
//using System.Web.Http;
//using System.Web;
//using System.IO;
//using System.Web.SessionState;
//using System.Reflection;

//namespace Accela.Apps.Apis.Services.Tests
//{
//    [TestClass]
//    public class TestAgenciesV4Controller : TestBase
//    {

//        [TestMethod]
//        public void ShouldGetAgencyByName()
//        {
//            var agenciesV4Controller = GetAgencyController();

//            var agency = agenciesV4Controller.GetAgency("SOLNDEV-ENG");
//            Assert.IsNotNull(agency, "Agency should not be null");
//            Assert.IsTrue("SOLNDEV-ENG" == agency.Agency.Name);
//        }

       

//        [TestMethod]
//        public void ShouldGetAgencyList() {

//            var agenciesV4Controller = GetAgencyController();
//            var agencies = agenciesV4Controller.GetAgencies();
//            Assert.IsNotNull(agencies, "Agency list should not be null");
//            Assert.IsTrue(agencies.Data.Count > 0);
//        }

//        [TestMethod]
//        public void ShouldGetAgencyListWithPagination()
//        {

//            var agenciesV4Controller = GetAgencyController();
//            var agencies = agenciesV4Controller.GetAgencies(offset: 0, limit: 10);
//            Assert.IsNotNull(agencies, "Agency list should not be null");
//            Assert.IsTrue(agencies.Data.Count > 0 && agencies.Data.Count <= 10, string.Format("Agency count does not match, should return 10 or less, returned {0}",agencies.Data.Count));
//        }


//        private static AgenciesV4Controller GetAgencyController()
//        {
//            var agencyBusinessEntity = IocContainer.Resolve<IAgencyBusinessEntity>();
//            var agenciesV4Controller = new AgenciesV4Controller(agencyBusinessEntity);
//            return agenciesV4Controller;
//        }
//    }
//}
