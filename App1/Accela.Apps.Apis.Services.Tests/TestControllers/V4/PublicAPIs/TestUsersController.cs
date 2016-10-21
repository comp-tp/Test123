using Accela.Apps.Apis.Models.DomainModels.Portals;
using Accela.Apps.Apis.WSModels;
using Accela.Apps.Apis.WSModels.V4;
using Accela.Apps.Shared.Contants;
using Accela.Apps.Shared.Contexts;
using Accela.Apps.User.WSModels.V2.CloudUser;
using Accela.Infrastructure.Configurations;
using Accela.Apps.Shared.Exceptions;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace Accela.Apps.Apis.Services.Tests.TestControllers.V4.PublicAPIs
{
    [TestFixture]
    public class TestUsersController
    {

        public IConfigurationReader ConfigurationReader;
        public UsersV4Controller userController;

        #region Assets
        private ContextUser validUser = new ContextUser()
        {
            Agency = "Jackie-BPTDEV",
            AgencyID = new Guid("956ea39e-e4b1-4d93-9326-cd05b76c25e1"),
            Environment = "PROD",
            Id = new Guid("04f2dbb7-92d9-4d56-a235-39d9e4193747"),
            LoginName = "jyu@accela.com"
        };

        private ContextUser userWithoutlinkedAccounts = new ContextUser()
        {
            Agency = "Jackie-BPTDEV",
            AgencyID = new Guid("956ea39e-e4b1-4d93-9326-cd05b76c25e1"),
            Environment = "PROD",
            Id = new Guid("E498A761-9095-4CE1-8245-3A34EBD6CEC4"),
            LoginName = "vsamaresan10@accela.com"
        };

        private ContextUser invalidUser = new ContextUser()
        {
            Agency = "Jackie-BPTDEV",
            AgencyID = new Guid("956ea39e-e4b1-4d93-9326-cd05b76c25e1"),
            Environment = "PROD",
            Id = new Guid("EEEEE782-E0AD-4F92-AD1D-3ABBF67EEB2F"),
            LoginName = "vvsamaresan10@accela.com"
        };

        private IAgencyAppContext mockContext = new AgencyAppContext()
        {
            Agency = "Jackie-BPTDEV",
            AppType = AppType.Citizen,
            ContentType = "application/json",
            EnvName = "PROD",
            IsAuthed = true,
            ServProvCode = "BPTDEV",
            SocialToken = "DUMMY_TOKEN",
            SubSystemCaller = "Client",
            TraceID = Guid.NewGuid().ToString()
        };
        #endregion


        [TestFixtureSetUp()]
        public void Setup()
        {
            ConfigurationReader = new Mock<IConfigurationReader>().Object;
            userController = new UsersV4Controller(mockContext, ConfigurationReader);
        }

        #region GetAccounts Tests

        [Test]
        public void TestGetLinkAccount_Valid()
        {
            mockContext.ContextUser = validUser;
            //UsersV4Controller userController = new UsersV4Controller(mockContext, ConfigurationReader);
            var result = userController.GetAccounts();
            var hasAccounts = false;
            if (result != null && result.LinkedAccount != null && result.LinkedAccount.ACAAccounts != null && result.LinkedAccount.ACAAccounts.Count > 0)
            {
                hasAccounts = true;
            }

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.LinkedAccount);
            Assert.AreEqual(true, hasAccounts);
        }

        [Test]
        public void TestGetLinkAccount_UserWithoutLinkedAccounts()
        {
            mockContext.ContextUser = userWithoutlinkedAccounts;
            //UsersV4Controller userController = new UsersV4Controller(mockContext, ConfigurationReader);
            var result = userController.GetAccounts();
            var hasLinkedAccounts = true;
            if (result != null && result.LinkedAccount != null && result.LinkedAccount.ACAAccounts != null && result.LinkedAccount.ACAAccounts.Count == 0 && result.LinkedAccount.AAAccounts.Count == 0 && result.LinkedAccount.SocialAccounts.Count == 0)
            {
                hasLinkedAccounts = false;
            }

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.LinkedAccount);
            Assert.AreEqual(false, hasLinkedAccounts);
        }

        [Test]
        public void TestGetLinkAccount_InValidUser()
        {
            mockContext.ContextUser = invalidUser;
            //UsersV4Controller userController = new UsersV4Controller(mockContext);
            var result = userController.GetAccounts();
            var hasLinkedAccounts = true;
            if (result != null && result.LinkedAccount != null && result.LinkedAccount.ACAAccounts != null && result.LinkedAccount.ACAAccounts.Count == 0 && result.LinkedAccount.AAAccounts.Count == 0 && result.LinkedAccount.SocialAccounts.Count == 0)
            {
                hasLinkedAccounts = false;
            }

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.LinkedAccount);
            Assert.AreEqual(false, hasLinkedAccounts);
        }

        #endregion

        #region GetUserProfile Tests

        [Test]
        public void TestGetUserProfile_ValidUser()
        {
            mockContext.ContextUser = validUser;
            //UsersV4Controller userController = new UsersV4Controller(mockContext);
            var result = userController.GetUserProfile();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.UserProfile);
            Assert.AreEqual(validUser.LoginName, result.UserProfile.Email);
            Assert.AreEqual(validUser.Id.ToString(), result.UserProfile.Id);
        }

        [Test]
        public void TestGetUserProfile_InValidUser()
        {
            mockContext.ContextUser = invalidUser;
            WSUserProfileV4Response result = null;
            try
            {
               // UsersV4Controller userController = new UsersV4Controller(mockContext);
                result = userController.GetUserProfile();
            }
            catch (MobileException)
            {
            }
            catch(Exception)
            {
                result = new WSUserProfileV4Response();
            }

            Assert.IsNull(result);
        }

        #endregion

        #region GetAccountById Tests - Yet to write
        
        //[Test]
        //public void TestGetAccountById_ValidId()
        //{
        //    mockContext.ContextUser = validUser;
        //    UsersV4Controller userController = new UsersV4Controller(mockContext);
        //    var accounts = userController.GetAccounts();
        //    var result = userController.GetAccountById(accounts.LinkedAccount.ACAAccounts[0].Id.ToString());
        //    Assert.IsNotNull(result);
        //}

        //[Test]
        //public void TestGetAccountById_InvalidId()
        //{
        //    mockContext.ContextUser = invalidUser;
        //    WSUserProfileV4Response result = null;
        //    try
        //    {
        //        UsersV4Controller userController = new UsersV4Controller(mockContext);
        //        result = userController.GetUserProfile();
        //    }
        //    catch (MobileException)
        //    {
        //    }
        //    catch (Exception)
        //    {
        //        result = new WSUserProfileV4Response();
        //    }

        //    Assert.IsNull(result);
        //}

        #endregion

        #region UnlinkAccount Tests

        [Test]
        public void TestLinkAccount_ValidAccountId()
        {
            mockContext.ContextUser = validUser;
            //UsersV4Controller userController = new UsersV4Controller(mockContext);

            // Check the account already linked
            var accounts = userController.GetAccounts();
            var linkedAccount = accounts.LinkedAccount.ACAAccounts.Where(a => a.AgencyName.Equals(mockContext.Agency, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            WSLinkAccountResponse result = null;
            //If already linked delete
            if (linkedAccount != null)
            {
                result = userController.UnlinkAccount(linkedAccount.Id.ToString());
            }

            Assert.IsNotNull(result);
            Assert.AreEqual("OK", result.Status.ToString());
        }

        [Test]
        public void TestLinkAccount_InValidAccountId()
        {
            mockContext.ContextUser = validUser;
            //UsersV4Controller userController = new UsersV4Controller(mockContext);

            // Check the account already linked
            var accounts = userController.GetAccounts();
            var linkedAccount = accounts.LinkedAccount.ACAAccounts.Where(a => a.AgencyName.Equals(mockContext.Agency, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            WSLinkAccountResponse result = null;
            var message = string.Empty;
            //If already linked delete
            if (linkedAccount != null)
            {
                try
                {
                    result = userController.UnlinkAccount(new Guid().ToString());
                }
                catch(Exception ex)
                {
                    message = ex.Message;
                }
            }

            Assert.IsNull(result);
            Assert.AreEqual("Invalid account id.", message);
        }

        [Test]
        public void TestLinkAccount_ValidAccountIdOfOthers()
        {
            mockContext.ContextUser = validUser;
            //UsersV4Controller userController = new UsersV4Controller(mockContext);

            // Check the account already linked
            var accounts = userController.GetAccounts();
            var linkedAccount = accounts.LinkedAccount.ACAAccounts.Where(a => a.AgencyName.Equals(mockContext.Agency, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            WSLinkAccountResponse result = null;
            var message = string.Empty;
            //If already linked delete
            if (linkedAccount != null)
            {
                try
                {
                    result = userController.UnlinkAccount("465C31D3-B8A0-4BD4-87B2-7471DAF83DC4");
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
            }

            Assert.IsNull(result);
            Assert.AreEqual("Cannot unlink others account.", message);
        }

        #endregion

        #region LinkAccount Tests

        [Test]
        public void TestLinkAccount_ValidUserDetails_AccountAlreadyLinked()
        {
            mockContext.ContextUser = validUser;
            //UsersV4Controller userController = new UsersV4Controller(mockContext);
            var requestParam = new WSLinkAccountV4Request() { AccountType = AppType.Citizen.ToString(), LoginName = "jyu@accela.com", Password = "11111111" };
            WSLinkAccountResponse result = null;
            string message = string.Empty;
            try
            {
                result = userController.LinkAccount(requestParam);
            }
            catch (BadRequestException ex)
            {
                message = ex.Message;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                //result = new WSLinkAccountResponse();
            }
            Assert.IsNull(result);
            Assert.IsNotNull(message);
            Assert.AreEqual("Account already linked.", message);
        }

        [Test]
        public void TestLinkAccount_InValidUserDetails_InvalidUsernameOrPassword()
        {
            mockContext.ContextUser = validUser;
            //UsersV4Controller userController = new UsersV4Controller(mockContext);
            var requestParam = new WSLinkAccountV4Request() { AccountType = AppType.Citizen.ToString(), LoginName = "jjyu@accela.com", Password = "11111111" };
            WSLinkAccountResponse result = null;
            string message = string.Empty;
            try
            {
                result = userController.LinkAccount(requestParam);
            }
            catch (BadRequestException ex)
            {
                message = ex.Message;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                //result = new WSLinkAccountResponse();
            }
            Assert.IsNull(result);
            Assert.IsNotNull(message);
            Assert.AreEqual("Invalid username or password.", message);
        }

        [Test]
        public void TestLinkAccount_ValidUserDetails()
        {
            mockContext.ContextUser = validUser;
            //UsersV4Controller userController = new UsersV4Controller(mockContext);

            // Check the account already linked
            var accounts = userController.GetAccounts();
            var linkedAccount = accounts.LinkedAccount.ACAAccounts.Where(a => a.AgencyName.Equals(mockContext.Agency, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

            //If already linked delete
            if (linkedAccount != null)
            {
                var unLinkresponse = userController.UnlinkAccount(linkedAccount.Id.ToString());
            }

            //Create link
            var requestParam = new WSLinkAccountV4Request() { AccountType = AppType.Citizen.ToString(), LoginName = "jyu@accela.com", Password = "11111111" };
            WSLinkAccountResponse result = null;
            string message = string.Empty;
            try
            {
                result = userController.LinkAccount(requestParam);
            }
            catch (ForbiddenException)
            {
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Id);
            Assert.AreEqual("OK", result.Status.ToString());
        }

        [Test]
        public void TestLinkAccount_EmptyUserDetails_AccountTypeIsRequired()
        {
            mockContext.ContextUser = validUser;
            //UsersV4Controller userController = new UsersV4Controller(mockContext);
            var requestParam = new WSLinkAccountV4Request();
            WSLinkAccountResponse result = null;
            string message = string.Empty;
            try
            {
                result = userController.LinkAccount(requestParam);
            }
            catch (BadRequestException ex)
            {
                message = ex.Message;
            }
            catch (Exception)
            {
                result = new WSLinkAccountResponse();
            }
            Assert.IsNull(result);
            Assert.IsNotNull(message);
            Assert.AreEqual("AccountType is required.", message);
        }

        [Test]
        public void TestLinkAccount_EmptyUserDetails_InvalidAccountType()
        {
            mockContext.ContextUser = validUser;
            //UsersV4Controller userController = new UsersV4Controller(mockContext);
            var requestParam = new WSLinkAccountV4Request() { AccountType = "citi" };
            WSLinkAccountResponse result = null;
            string message = string.Empty;
            try
            {
                result = userController.LinkAccount(requestParam);
            }
            catch (BadRequestException ex)
            {
                message = ex.Message;
            }
            catch (Exception)
            {
                result = new WSLinkAccountResponse();
            }
            Assert.IsNull(result);
            Assert.IsNotNull(message);
            Assert.AreEqual("Invalid AccountType.", message);
        }

        [Test]
        public void TestLinkAccount_EmptyUserDetails_AgencyIsRequiredInHeader()
        {
            mockContext.ContextUser = validUser;
            mockContext.Agency = "";
            //UsersV4Controller userController = new UsersV4Controller(mockContext);
            var requestParam = new WSLinkAccountV4Request() { AccountType = "Citizen" };
            WSLinkAccountResponse result = null;
            string message = string.Empty;
            try
            {
                result = userController.LinkAccount(requestParam);
                mockContext.Agency = "Jackie-BPTDEV";
            }
            catch (BadRequestException ex)
            {
                message = ex.Message;
            }
            catch (Exception)
            {
                result = new WSLinkAccountResponse();
            }
            Assert.IsNull(result);
            Assert.IsNotNull(message);
            Assert.AreEqual("Agency is required in header.", message);
        }

        [Test]
        public void TestLinkAccount_EmptyUserDetails_LoginNameIsRequired()
        {
            mockContext.ContextUser = validUser;
            //UsersV4Controller userController = new UsersV4Controller(mockContext);
            var requestParam = new WSLinkAccountV4Request() { AccountType = "Citizen" };
            WSLinkAccountResponse result = null;
            string message = string.Empty;
            try
            {
                result = userController.LinkAccount(requestParam);
                mockContext.Agency = "Jackie-BPTDEV";
            }
            catch (BadRequestException ex)
            {
                message = ex.Message;
            }
            catch (Exception)
            {
                result = new WSLinkAccountResponse();
            }
            Assert.IsNull(result);
            Assert.IsNotNull(message);
            Assert.AreEqual("LoginName is required.", message);
        }

        [Test]
        public void TestLinkAccount_EmptyUserDetails_PasswordIsRequired()
        {
            mockContext.ContextUser = validUser;
            //UsersV4Controller userController = new UsersV4Controller(mockContext);
            var requestParam = new WSLinkAccountV4Request() { AccountType = "Citizen", LoginName = "jyu@accela.com" };
            WSLinkAccountResponse result = null;
            string message = string.Empty;
            try
            {
                result = userController.LinkAccount(requestParam);
                mockContext.Agency = "Jackie-BPTDEV";
            }
            catch (BadRequestException ex)
            {
                message = ex.Message;
            }
            catch (Exception)
            {
                result = new WSLinkAccountResponse();
            }
            Assert.IsNull(result);
            Assert.IsNotNull(message);
            Assert.AreEqual("Password is required.", message);
        }

        #endregion
    }
}
