using System.Collections.Generic;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Shared.Utils;

namespace Accela.Apps.Apis.WSModels.Addresses
{
    [DataContract]
    public class WSCompactAddress : WSDataModel
    {
        /// <summary>
        /// Gets or sets the address display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        [DataMember(Name = "addressLine1", EmitDefaultValue = false)]
        public string AddressLine1 { get; set; }

        [DataMember(Name = "addressLine2", EmitDefaultValue = false)]
        public string AddressLine2 { get; set; }

        [DataMember(Name = "addressLine3", EmitDefaultValue = false)]
        public string AddressLine3 { get; set; }

        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        [DataMember(Name = "postalCode", EmitDefaultValue = false)]
        public string PostalCode { get; set; }

        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        /// <summary>
        /// *** should be country code (ISO 3166 2-letter code).
        /// *** country code list: http://msdn.microsoft.com/en-us/library/system.globalization.regioninfo(v=vs.71).aspx
        /// </summary>
        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }

        [DataMember(Name = "isPrimary", EmitDefaultValue = false)]
        public string IsPrimary { get; set; }

        [DataMember(Name = "xCoordinate", EmitDefaultValue = false)]
        public string XCoordinate { get; set; }

        [DataMember(Name = "yCoordinate", EmitDefaultValue = false)]
        public string YCoordinate { get; set; }

        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">The web service model.</param>
        /// <returns>the entity model.</returns>
        public static AddressModel ToEntityModel(WSCompactAddress wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new AddressModel()
            {
                Display = wsModel.Display,
                AddressLine1=wsModel.AddressLine1,
                AddressLine2 = wsModel.AddressLine2,
                AddressLine3 = wsModel.AddressLine3,
                State = wsModel.State,
                PostalCode = wsModel.PostalCode,
                City = wsModel.City,
                Country = wsModel.Country,
                //IsPrimary = wsModel.IsPrimary,
                XCoordinate = wsModel.XCoordinate,
                YCoordinate = wsModel.YCoordinate,
            };

            if (BoolHelper.IsTrueString(wsModel.IsPrimary))
            {
                result.IsPrimary = true;
            }

            return result;
        }

        /// <summary>
        /// Convert AddressModel list to WSAddress list.
        /// </summary>
        /// <param name="wsModels">WSAddress list.</param>
        /// <returns>AddressModel list.</returns>
        public static List<AddressModel> ToEntityModels(List<WSCompactAddress> wsModels)
        {
            if (wsModels != null && wsModels.Count > 0)
            {
                var addressModels = new List<AddressModel>();
                foreach (var wsModel in wsModels)
                {
                    addressModels.Add(ToEntityModel(wsModel));
                };
                return addressModels;
            }
            return null;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSCompactAddress FromEntityModel(AddressModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSCompactAddress()
            {
                Display = entityModel.Display,
                AddressLine1 = entityModel.AddressLine1,
                AddressLine2 = entityModel.AddressLine2,
                AddressLine3 = entityModel.AddressLine3,
                State = entityModel.State,
                PostalCode = entityModel.PostalCode,
                City = entityModel.City,
                Country = entityModel.Country,
                IsPrimary = entityModel.IsPrimary.ToString(),
                XCoordinate = entityModel.XCoordinate,
                YCoordinate = entityModel.YCoordinate,
            };

            return result;
        }

        /// <summary>
        /// Convert AddressModel list to WSAddress list.
        /// </summary>
        /// <param name="addressModels">AddressModels</param>
        /// <returns>WSAddress list</returns>
        public static List<WSCompactAddress> FromEntityModels(List<AddressModel> addressModels)
        {
            if (addressModels != null && addressModels.Count > 0)
            {
                var wsAddressList = new List<WSCompactAddress>();
                foreach (var addressModel in addressModels)
                {
                    wsAddressList.Add(FromEntityModel(addressModel));
                };
                return wsAddressList;
            }
            return null;
        }
    }
}
