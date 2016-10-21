using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DTOs.Responses.ReferenceResponses;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.WSModels.Addresses
{
    [DataContract]
    public class WSGetAddressByCoordinateResponse : WSResponseBase
    {
        [DataMember(Name = "address", EmitDefaultValue = false)]
        public WSAddressByCoordinates Address { get; set; }

        public static WSGetAddressByCoordinateResponse FromEntityModel(AddressModel addressModel)
        {
            WSGetAddressByCoordinateResponse result = new WSGetAddressByCoordinateResponse();

            if (addressModel != null)
            {
                result.Address = new WSAddressByCoordinates();
                result.Address.AddressFormat = addressModel.AddressFormat;
                result.Address.HouseNumber = addressModel.HouseNumber;
                result.Address.HouseNumberFraction = addressModel.HouseNumberFraction;
                result.Address.StreetDirection = addressModel.StreetDirection;
                result.Address.StreetPrefix = addressModel.StreetPrefix;
                result.Address.StreetName = addressModel.StreetAddress;
                result.Address.Street = addressModel.StreetName;
                result.Address.StreetSuffix = addressModel.StreetSuffix;
                result.Address.StreetSuffixDirection = addressModel.StreetSuffixDirection;
                result.Address.City = addressModel.City;
                result.Address.State = addressModel.State;
                result.Address.PostalCode = addressModel.PostalCode;
                result.Address.Country = addressModel.Country;
                result.Address.CountryCode = addressModel.CountryCode;
                result.Address.StateAbbreviation = addressModel.StateAbbreviation;
            }

            return result;
        }
    }
}
