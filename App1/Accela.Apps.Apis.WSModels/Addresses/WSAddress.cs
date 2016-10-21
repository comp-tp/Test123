using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Shared.Utils;

namespace Accela.Apps.Apis.WSModels.Addresses
{
    [DataContract]
    public class WSAddress : WSEntityState
    {
        /// <summary>
        /// Gets or sets the address Id.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the address display.
        /// </summary>
        [DataMember(Name = "display", EmitDefaultValue = false)]
        public string Display { get; set; }

        /// <summary>
        /// This is address format
        /// </summary>
        [DataMember(Name = "addressFormat", EmitDefaultValue = false)]
        public string AddressFormat { get; set; }

        [DataMember(Name = "addressLine1", EmitDefaultValue = false)]
        public string AddressLine1 { get; set; }

        [DataMember(Name = "addressLine2", EmitDefaultValue = false)]
        public string AddressLine2 { get; set; }

        [DataMember(Name = "addressLine3", EmitDefaultValue = false)]
        public string AddressLine3 { get; set; }

        [DataMember(Name = "houseNumber", EmitDefaultValue = false)]
        public string HouseNumber { get; set; }

        [DataMember(Name = "houseNumberFraction", EmitDefaultValue = false)]
        public string HouseNumberFraction { get; set; }

        [DataMember(Name = "streetDirection", EmitDefaultValue = false)]
        public string StreetDirection { get; set; }

        [DataMember(Name = "streetName", EmitDefaultValue = false)]
        public string StreetName { get; set; }

        [DataMember(Name = "streetSuffix", EmitDefaultValue = false)]
        public string StreetSuffix { get; set; }

        [DataMember(Name = "streetSuffixDirection", EmitDefaultValue = false)]
        public string StreetSuffixDirection { get; set; }

        [DataMember(Name = "unit", EmitDefaultValue = false)]
        public string Unit { get; set; }

        [DataMember(Name = "unitEnd", EmitDefaultValue = false)]
        public string UnitEnd { get; set; }

        [DataMember(Name = "unitType", EmitDefaultValue = false)]
        public string UnitType { get; set; }

        [DataMember(Name = "state", EmitDefaultValue = false)]
        public string State { get; set; }

        [DataMember(Name = "postalCode", EmitDefaultValue = false)]
        public string PostalCode { get; set; }

        [DataMember(Name = "city", EmitDefaultValue = false)]
        public string City { get; set; }

        [DataMember(Name = "county", EmitDefaultValue = false)]
        public string County { get; set; }

        [DataMember(Name = "country", EmitDefaultValue = false)]
        public string Country { get; set; }

        [DataMember(Name = "isPrimary", EmitDefaultValue = false)]
        public string IsPrimary { get; set; }

        [DataMember(Name = "xCoordinate", EmitDefaultValue = false)]
        public string XCoordinate { get; set; }

        [DataMember(Name = "yCoordinate", EmitDefaultValue = false)]
        public string YCoordinate { get; set; }

        [DataMember(Name = "enabled", EmitDefaultValue = false)]
        public bool Enabled { get; set; }

        [DataMember(Name = "neighborhoodPrefix", EmitDefaultValue = false)]
        public string NeighberhoodPrefix;

        [DataMember(Name = "neighborhood", EmitDefaultValue = false)]
        public string Neighborhood;

        [DataMember(Name = "inspectionDistrictPrefix", EmitDefaultValue = false)]
        public string InspectionDistrictPrefix;

        [DataMember(Name = "inspectionDistrict", EmitDefaultValue = false)]
        public string InspectionDistrict;

        [DataMember(Name = "secondaryRoad", EmitDefaultValue = false)]
        public string SecondaryRoad;

        [DataMember(Name = "secondaryRoadNumber", EmitDefaultValue = false)]
        public string SecondaryRoadNumber;

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string AddressDescription;

        [DataMember(Name = "distance", EmitDefaultValue = false)]
        public string Distance;

        /// <summary>
        /// Toes the entity model.
        /// </summary>
        /// <param name="wsModel">The web service model.</param>
        /// <returns>the entity model.</returns>
        public static AddressModel ToEntityModel(WSAddress wsModel)
        {
            if (wsModel == null)
            {
                return null;
            }

            var result = new AddressModel()
            {
                Identifier = wsModel.Id,
                Display = wsModel.Display,
                AddressFormat = wsModel.AddressFormat,
                AddressLine1 = wsModel.AddressLine1,
                AddressLine2 = wsModel.AddressLine2,
                AddressLine3 = wsModel.AddressLine3,
                HouseNumber = wsModel.HouseNumber,
                HouseNumberFraction = wsModel.HouseNumberFraction,
                StreetDirection = wsModel.StreetDirection,
                StreetName = wsModel.StreetName,
                StreetSuffix = wsModel.StreetSuffix,
                StreetSuffixDirection = wsModel.StreetSuffixDirection,
                Unit = wsModel.Unit,
                UnitEnd = wsModel.UnitEnd,
                UnitType = wsModel.UnitType,
                State = wsModel.State,
                PostalCode = wsModel.PostalCode,
                City = wsModel.City,
                County = wsModel.County,
                Country = wsModel.Country,
                //IsPrimary = wsModel.IsPrimary,
                XCoordinate = wsModel.XCoordinate,
                YCoordinate = wsModel.YCoordinate,
                Action = WSEntityState.ConvertEntityStateToAction(wsModel.EntityState),
                NeighberhoodPrefix = wsModel.NeighberhoodPrefix,
                Neighborhood = wsModel.Neighborhood,
                InspectionDistrictPrefix = wsModel.InspectionDistrictPrefix,
                InspectionDistrict = wsModel.InspectionDistrict,
                SecondaryRoadNumber = wsModel.SecondaryRoadNumber,
                SecondaryRoad = wsModel.SecondaryRoad,
                AddressDescription = wsModel.AddressDescription,
                Distance = wsModel.Distance

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
        public static List<AddressModel> ToEntityModels(List<WSAddress> wsModels)
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
        public static WSAddress FromEntityModel(AddressModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSAddress()
            {
                Id = entityModel.Identifier,
                Display = entityModel.Display,
                AddressFormat = entityModel.AddressFormat,
                AddressLine1 = entityModel.AddressLine1,
                AddressLine2 = entityModel.AddressLine2,
                AddressLine3 = entityModel.AddressLine3,
                HouseNumber = entityModel.HouseNumber,
                HouseNumberFraction = entityModel.HouseNumberFraction,
                StreetDirection = entityModel.StreetDirection,
                StreetName = entityModel.StreetName,
                StreetSuffix = entityModel.StreetSuffix,
                StreetSuffixDirection = entityModel.StreetSuffixDirection,
                Unit = entityModel.Unit,
                UnitEnd = entityModel.UnitEnd,
                UnitType = entityModel.UnitType,
                State = entityModel.State,
                PostalCode = entityModel.PostalCode,
                City = entityModel.City,
                County = entityModel.County,
                Country = entityModel.Country,
                IsPrimary = entityModel.IsPrimary.ToString(),
                XCoordinate = entityModel.XCoordinate,
                YCoordinate = entityModel.YCoordinate,
                Enabled = "A".Equals(entityModel.AuditStatus, StringComparison.OrdinalIgnoreCase),
                EntityState = ConvertActionToEntityState(entityModel.Action),
                NeighberhoodPrefix = entityModel.NeighberhoodPrefix,
                Neighborhood = entityModel.Neighborhood,
                InspectionDistrictPrefix = entityModel.InspectionDistrictPrefix,
                InspectionDistrict = entityModel.InspectionDistrict,
                SecondaryRoadNumber = entityModel.SecondaryRoadNumber,
                SecondaryRoad = entityModel.SecondaryRoad,
                AddressDescription = entityModel.AddressDescription,
                Distance = entityModel.Distance
            };

            return result;
        }

        /// <summary>
        /// Convert AddressModel list to WSAddress list.
        /// </summary>
        /// <param name="addressModels">AddressModels</param>
        /// <returns>WSAddress list</returns>
        public static List<WSAddress> FromEntityModels(List<AddressModel> addressModels)
        {
            if (addressModels != null && addressModels.Count > 0)
            {
                var wsAddressList = new List<WSAddress>();
                foreach (var addressModel in addressModels)
                {
                    wsAddressList.Add(FromEntityModel(addressModel));
                };
                return wsAddressList;
            }
            return null;
        }

        public static string GetOneLineString(List<WSAddress> addressList)
        {
            string result = String.Empty;

            if (addressList != null && addressList.Count() > 0)
            {
                //TODO:
                //var address = addressList.Find(a => Accela.Apps.Shared.Utils.BoolHelper.IsTrueString(a.IsPrimary));
                var address = addressList.Find(a => a.IsPrimary.ToUpper() == "Y");

                if (address == null)
                {
                    address = addressList.First();
                }

                result = ConvertToOneLineString(address);
            }

            return result;
        }

        public static string ConvertToOneLineString(WSAddress model)
        {
            string result = String.Empty;

            if (model != null)
            {
                //TODO:
                //result = Accela.Apps.Shared.FormatHelpers.AddressFormatter.ToOneLineString(
                //              model.Display
                //            , model.HouseNumber
                //            , model.HouseNumberFraction
                //            , null
                //            , model.StreetName
                //            , model.StreetSuffix
                //            , model.StreetSuffixDirection
                //            , model.UnitType
                //            , model.Unit
                //            , null
                //            , model.City
                //            , model.County
                //            , model.State
                //            , model.PostalCode
                //            , model.Country);
            }

            return result;
        }
    }
}
