using System;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.GISModels;
using Accela.Apps.Apis.Models.DomainModels.ParcelModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Responses.ParcelResponses;
using Accela.Apps.Shared.Utils;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Apis.Models.Common;


namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    public class ParcelHelper : GovXmlHelperBase
    {
        private string _bizServerVersion;

        public ParcelHelper(string bizServerVersion)
        {
            if (String.IsNullOrEmpty(bizServerVersion))
            {
                throw new ArgumentNullException("bizServerVersion cannot be null.");
            }

            _bizServerVersion = bizServerVersion;
        }

        public static ParcelId ToGovXmlId(string parcelId)
        {
            if (String.IsNullOrWhiteSpace(parcelId))
            {
                return null;
            }

            ParcelId result = new ParcelId();

            result.val = parcelId;

            return result;
        }

        public static ParcelIds ToGovXmlIds(List<ParcelModel> parcels, bool isCreateKeys)
        {
            if (parcels == null || parcels.Count == 0)
            {
                return null;
            }

            ParcelIds result = new ParcelIds();
            var idList = new List<ParcelId>();

            foreach (var parcel in parcels)
            {
                if (parcels == null)
                {
                    continue;
                }

                var parcelId = new ParcelId();
                parcelId.action = CommonHelper.ToGovXmlAction(parcel.Action);
                parcelId.identifierDisplay = parcel.Display;

                // if create record with parcel,no need keys node, otherwise need keys node(eg.update record with parcel).
                if (isCreateKeys)
                {
                    parcelId.keys = KeysHelper.CreateXMLKeys(parcel.Id);
                }

                parcelId.val = IdEscapeHelper.DecodeString(parcel.Id);
                idList.Add(parcelId);
            }

            result.parcelId = idList.ToArray();

            return result;
        }

        public static void ToGovXmlFromCriteria(GetParcels getParcels, ParcelCriteria criteria, List<string> elements)
        {
            if (elements != null && elements.Count > 0)
            {
                getParcels.returnElements = new returnElements();
                getParcels.returnElements.returnElement = elements.ToArray();
            }

            if (criteria.ParcelIds != null && criteria.ParcelIds.Count > 0)
            {
                getParcels.ParcelIds = new ParcelIds();
                getParcels.ParcelIds.parcelId = new ParcelId[criteria.ParcelIds.Count];
                for (int i = 0; i < criteria.ParcelIds.Count; i++)
                {
                    getParcels.ParcelIds.parcelId[i] = new ParcelId();
                    getParcels.ParcelIds.parcelId[i].keys = KeysHelper.CreateXMLKeys(criteria.ParcelIds[i]);
                }
            }

            if (!string.IsNullOrWhiteSpace(criteria.RecordId))
            {
                getParcels.capId = new CAPId();
                getParcels.capId.val = criteria.RecordId;
                //getParcels.capId.keys = KeysHelper.CreateXMLKeys(criteria.RecordId);
            }

            if (criteria.GisObjects != null && criteria.GisObjects.Count > 0)
            {
                getParcels.GisObjects = new GISObjects();
                getParcels.GisObjects.GISObject = new GISObject[criteria.GisObjects.Count];
                for (int i = 0; i < criteria.GisObjects.Count; i++)
                {
                    var criteriaGisObj = criteria.GisObjects[i];
                    getParcels.GisObjects.GISObject[i] = new GISObject();
                    getParcels.GisObjects.GISObject[i].Keys = KeysHelper.CreateXMLKeys(criteriaGisObj.ID);
                    getParcels.GisObjects.GISObject[i].MapServerID = new MapServerID();
                    getParcels.GisObjects.GISObject[i].MapServerID.Keys = KeysHelper.CreateXMLKeys(criteriaGisObj.MapService);
                    getParcels.GisObjects.GISObject[i].GISLayerId = new GISLayerId();
                    getParcels.GisObjects.GISObject[i].GISLayerId.Keys = KeysHelper.CreateXMLKeys(criteriaGisObj.LayerId);
                }
            }

            if (!string.IsNullOrWhiteSpace(criteria.RecordStatus))
            {
                getParcels.capStatuses = new CAPStatuses();
                getParcels.capStatuses.capStatus = new CAPStatus[1];
                CAPStatus status = new CAPStatus() { keys = KeysHelper.CreateXMLKeys(criteria.RecordStatus) };
                getParcels.capStatuses.capStatus[0] = status;
            }

            if (!string.IsNullOrWhiteSpace(criteria.Tract) || !string.IsNullOrWhiteSpace(criteria.Block) || !string.IsNullOrWhiteSpace(criteria.Lot))
            {
                getParcels.spatialDescriptors = new Automation.GovXmlClient.Model.SpatialDescriptors();
                getParcels.spatialDescriptors.mapReference = new MapReference();
                if (!string.IsNullOrWhiteSpace(criteria.Tract))
                {
                    getParcels.spatialDescriptors.mapReference.tract = criteria.Tract;
                }
                if (!string.IsNullOrWhiteSpace(criteria.Block))
                {
                    getParcels.spatialDescriptors.mapReference.block = criteria.Block;
                }
                if (!string.IsNullOrWhiteSpace(criteria.Lot))
                {
                    getParcels.spatialDescriptors.mapReference.lot = criteria.Lot;
                }
            }

            if (!string.IsNullOrWhiteSpace(criteria.AddressNumber)
                || !string.IsNullOrWhiteSpace(criteria.AddressFraction)
                 || !string.IsNullOrWhiteSpace(criteria.AddressPrefix)
                 || !string.IsNullOrWhiteSpace(criteria.AddressStreet)
                 || !string.IsNullOrWhiteSpace(criteria.AddressType)
                 || !string.IsNullOrWhiteSpace(criteria.AddressSuffix)
                 || !string.IsNullOrWhiteSpace(criteria.AddressUnit)
                 || !string.IsNullOrWhiteSpace(criteria.AddressUnitType))
            {
                getParcels.detailAddress = new DetailAddress();
                if (!string.IsNullOrWhiteSpace(criteria.AddressNumber))
                    getParcels.detailAddress.houseNumber = criteria.AddressNumber;
                if (!string.IsNullOrWhiteSpace(criteria.AddressPrefix))
                    getParcels.detailAddress.streetDirection = criteria.AddressPrefix;
                if (!string.IsNullOrWhiteSpace(criteria.AddressFraction))
                    getParcels.detailAddress.houseNumberFraction = criteria.AddressFraction;
                if (!string.IsNullOrWhiteSpace(criteria.AddressStreet))
                    getParcels.detailAddress.streetName = criteria.AddressStreet;
                if (!string.IsNullOrWhiteSpace(criteria.AddressType))
                    getParcels.detailAddress.streetSuffix = criteria.AddressType;
                if (!string.IsNullOrWhiteSpace(criteria.AddressSuffix))
                    getParcels.detailAddress.streetSuffixDirection = criteria.AddressSuffix;
                if (!string.IsNullOrWhiteSpace(criteria.AddressUnit))
                    getParcels.detailAddress.unit = criteria.AddressUnit;
                if (!string.IsNullOrWhiteSpace(criteria.AddressUnitType))
                    getParcels.detailAddress.unitType = criteria.AddressUnitType;
                if (!string.IsNullOrWhiteSpace(criteria.City))
                    getParcels.detailAddress.city = criteria.City;
                if (!string.IsNullOrWhiteSpace(criteria.State))
                    getParcels.detailAddress.state = criteria.State;
                if (!string.IsNullOrWhiteSpace(criteria.Zip))
                    getParcels.detailAddress.postalCode = criteria.Zip;
            }

            if (!string.IsNullOrWhiteSpace(criteria.OwnerFirstName) || !string.IsNullOrWhiteSpace(criteria.OwnerMiddleName)
                || !string.IsNullOrWhiteSpace(criteria.OwnerLastName))
            {
                getParcels.contact = new Contact();
                getParcels.contact.person = new Person();
                if (!string.IsNullOrWhiteSpace(criteria.OwnerFirstName))
                {
                    getParcels.contact.person.givenName = criteria.OwnerFirstName;
                }
                if (!string.IsNullOrWhiteSpace(criteria.OwnerMiddleName))
                {
                    getParcels.contact.person.middleNames = new MiddleNames();
                    getParcels.contact.person.middleNames.String = new string[1] { criteria.OwnerMiddleName };
                }
                if (!string.IsNullOrWhiteSpace(criteria.OwnerLastName))
                {
                    getParcels.contact.person.familyName = criteria.OwnerLastName;
                }
            }
        }

        /// <summary>
        /// Convert GetParcelResponse to data model
        /// </summary>
        /// <param name="xmlObj"></param>
        /// <returns></returns>
        public ParcelsResponse GetClientParcels(GetParcelsResponse xmlObj, bool ignoreCoordinatesSearch)
        {
            ParcelsResponse results = new ParcelsResponse();

            if (xmlObj.system != null)
            {
                //set pageinformation
                results.PageInfo = CommonHelper.GetPaginationFromSystem(xmlObj.system);
                results.Events = CommonHelper.GetClientEventMessage(xmlObj.system.eventMessages);
            }

            if (xmlObj.parcels != null
                && xmlObj.parcels.parcel != null
                && xmlObj.parcels.parcel.Length > 0)
            {
                results.Parcels = new List<ParcelModel>();
                foreach (var parcel in xmlObj.parcels.parcel)
                {
                    results.Parcels.Add(ToClientParcel(parcel));
                }

                if (!ignoreCoordinatesSearch)
                {
                    //SetCoordinates(results.Parcels);
                }
            }

            return results;
        }

        public ParcelModel ToClientParcel(Parcel xmlParcel)
        {
            ParcelModel clientParcel = null;
            if (xmlParcel != null)
            {
                clientParcel = new ParcelModel();
                clientParcel.Id = KeysHelper.ToStringKeys(xmlParcel.keys);
                clientParcel.Display = xmlParcel.IdentifierDisplay;
                clientParcel.Description = xmlParcel.description;
                clientParcel.Text = xmlParcel.text;
                clientParcel.LegalDescription = xmlParcel.LegalDescription;

                if (xmlParcel.status != null)
                {
                    clientParcel.Status = new ParcelStatusModel();
                    clientParcel.Status.Identifier = KeysHelper.ToStringKeys(xmlParcel.status.keys);
                    clientParcel.Status.Display = xmlParcel.status.IdentifierDisplay;
                    if (string.IsNullOrWhiteSpace(clientParcel.Status.Display))
                    {
                        clientParcel.Status.Display = xmlParcel.status.val;
                    }
                }

                if (xmlParcel.contacts != null && xmlParcel.contacts.contact != null && xmlParcel.contacts.contact.Length > 0)
                {
                    var owners = new List<OwnerModel>();

                    ContactHelper _contactHelper = new ContactHelper(_bizServerVersion);
                    foreach (var xmlContact in xmlParcel.contacts.contact)
                    {
                        if (xmlContact == null)
                        {
                            continue;
                        }

                        var clientContact = _contactHelper.ToClientContact(xmlContact);
                        var clientOwner = ContactHelper.ToClientOwner(clientContact);
                        owners.Add(clientOwner);
                    }

                    clientParcel.Owners = owners.Count > 0 ? owners : null;
                }

                if (xmlParcel.spatialDescriptors != null && xmlParcel.spatialDescriptors.mapReference != null)
                {
                    clientParcel.Tract = xmlParcel.spatialDescriptors.mapReference.tract;
                    clientParcel.Block = xmlParcel.spatialDescriptors.mapReference.block;
                    clientParcel.Lot = xmlParcel.spatialDescriptors.mapReference.lot;
                    clientParcel.Township = xmlParcel.spatialDescriptors.mapReference.township;
                    clientParcel.Range = xmlParcel.spatialDescriptors.mapReference.range;
                    clientParcel.Section = xmlParcel.spatialDescriptors.mapReference.section;
                    clientParcel.Subdivision = xmlParcel.spatialDescriptors.mapReference.subdivision;
                }

                if (xmlParcel.detailAddresses != null
                    && xmlParcel.detailAddresses.detailAddress != null
                    && xmlParcel.detailAddresses.detailAddress.Length > 0)
                {
                    var addresses = new List<AddressModel>();

                    foreach (var xmlAddress in xmlParcel.detailAddresses.detailAddress)
                    {
                        if (xmlAddress == null)
                        {
                            continue;
                        }

                        var address = AddressHelper.ToClientAddress(xmlAddress);

                        addresses.Add(address);
                    }

                    clientParcel.Addresses = addresses.Count > 0 ? addresses : null;
                }

                if (xmlParcel.GISObjects != null
                    && xmlParcel.GISObjects.GISObject != null
                    && xmlParcel.GISObjects.GISObject.Length > 0)
                {
                    clientParcel.GISObjects = new List<GISObjectModel>();

                    foreach (var gisObject in xmlParcel.GISObjects.GISObject)
                    {
                        clientParcel.GISObjects.Add(ToClientGISObject(gisObject));
                    }
                }
            }

            return clientParcel;
        }

        private static GISObjectModel ToClientGISObject(GISObject gisObject)
        {
            if (gisObject != null)
            {
                return new GISObjectModel
                {
                    Id = gisObject.Keys.ToStringKeys(),
                    GISLayerId =
                        gisObject.GISLayerId != null && gisObject.GISLayerId.Keys != null &&
                        gisObject.GISLayerId.Keys.key != null
                            ? gisObject.GISLayerId.Keys.key[0]
                            : null,
                    MapServiceId =
                        gisObject.MapServerID.Keys != null && gisObject.MapServerID.Keys.key != null
                            ? gisObject.MapServerID.Keys.key[0]
                            : null,
                    Display = gisObject.IdentifierDisplay
                };
            }

            return null;
        }
    }
}
