using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs.Responses.AddressResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Core.Ioc;
using NUnit.Framework;
using SimpleInjector.Extensions.ExecutionContextScoping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accela.Apps.Apis.Services.Tests.TestControllers.V2
{
    [TestFixture]
    public class TestAddressesController : TestBase
    {

        [Test]
        public void ShouldGetAddresses()
        {
            //This Starts Web API Request Scope. Please use this wheneve IoC expects "WebApiRequestLifestyle"
            //Add this to your class 
            //using SimpleInjector.Extensions.ExecutionContextScoping;

            HttpContext.Current = HttpContextFactory.FakeHttpContext("/v3/addresses", "GET");
            using (IoContainer.BeginExecutionContextScope())
            {
                // resolve and use services here
                var addressController = GetController();

                var addresses = addressController.GetAddresses();
                Assert.IsNotNull(addresses.Addresses);
                Assert.AreEqual(15, addresses.Addresses.Count, "Should return 15 addresses");
            }
        }

        [Test]
        public void ShouldGetAddressesByState()
        {
            //This Starts Web API Request Scope. Please use this wheneve IoC expects "WebApiRequestLifestyle"
            //Add this to your class 
            //using SimpleInjector.Extensions.ExecutionContextScoping;

            HttpContext.Current = HttpContextFactory.FakeHttpContext("/v3/addresses", "GET");
            using (IoContainer.BeginExecutionContextScope())
            {
                // resolve and use services here
                var addressController = GetController();

                var addresses = addressController.GetAddresses(state: "CA");
                Assert.AreNotEqual(null, addresses.Addresses);
                Assert.AreEqual(11, addresses.Addresses.Count, "Should return 11 addresses");
            }
        }

        private static AddressesController GetController()
        {

            var addressBusinessEntity = IocContainer.Resolve<IAddressBusinessEntity>();
            //return new AddressesController(new DummyAddresssEntity(new DummyAgencyRepository(), new DummyAddressRepository()));
            return new AddressesController(addressBusinessEntity);
        }
    }


    public class DummyAddresssEntity : IAddressBusinessEntity
    {
        private readonly IAddressRepository addressRepository;
        public DummyAddresssEntity( IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }
        public Models.DTOs.Responses.AddressResponses.AddressesResponse GetAddresses(Models.DTOs.Requests.AddressRequests.AddressesRequest request)
        {
            return this.addressRepository.GetAddresses(request);
        }

        public Models.DTOs.Responses.AddressResponses.AddressResponse GetAddress(Models.DTOs.Requests.AddressRequests.AddressRequest request)
        {
            return this.addressRepository.GetAddress(request);
        }

        public void RetrieveAndSetCoodinateXY(List<Models.DomainModels.ReferenceModels.AddressModel> addresses, bool forceSetCoordinatesByAddress = true)
        {
            throw new NotImplementedException();
        }
    }

    public class DummyAddressRepository : IAddressRepository
    {
        private List<Models.DomainModels.ReferenceModels.AddressModel> _addresses;
        public DummyAddressRepository()
        {

            _addresses = new List<Models.DomainModels.ReferenceModels.AddressModel>
            {
                new AddressModel{ 
                    AddressLine1 = "Main St", 
                    City = "San Rmaon", 
                    County = "USA", 
                    HouseNumber = "1234", 
                    Identifier = "1", 
                    PostalCode = "94555", 
                    State = "CA", 
                    StreetName = "Main St"
                },
                new AddressModel{ 
                    AddressLine1 = "Side St", 
                    City = "San Rmaon", 
                    County = "USA", 
                    HouseNumber = "2345", 
                    Identifier = "2", 
                    PostalCode = "94556", 
                    State = "PA", 
                    StreetName = "Side St"
                }
            };
        }
        public Models.DTOs.Responses.AddressResponses.AddressesResponse GetAddresses(Models.DTOs.Requests.AddressRequests.AddressesRequest request)
        {
            var filteredAddress = _addresses;
            if (!string.IsNullOrEmpty(request.Criteria.State))
            {
                filteredAddress = _addresses.Where(a => a.State == request.Criteria.State).ToList();
            }

            return new AddressesResponse
            {
                Addresses = filteredAddress,
                Error = null,
                Events = null,
                PageInfo = new Models.DTOs.Pagination { Limit = 10, Offset = 1, TotalRows = 10 }
            };
        }

        public Models.DTOs.Responses.AddressResponses.AddressResponse GetAddress(Models.DTOs.Requests.AddressRequests.AddressRequest request)
        {
            return new AddressResponse { Address = _addresses.First(), Error = null, Events = null };
        }
    }
}
