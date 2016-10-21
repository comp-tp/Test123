using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DomainModels.InspectionModels;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Apis.Resources;
using Accela.Core.Ioc;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Shared.FormatHelpers;
using Accela.Apps.Shared.Utils;
using Accela.Automation.GovXmlClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    public class InspectionHelper : GovXmlHelperBase
    {
        private readonly string _bizServerVersion;
        private readonly bool _autoCorrectCoordinates;

        public InspectionHelper(string bizServerVersion, bool autoCorrectCoordinates = false)
        {
            if (String.IsNullOrEmpty(bizServerVersion))
            {
                throw new ArgumentNullException("bizServerVersion cannot be null.");
            }

            _bizServerVersion = bizServerVersion;
            _autoCorrectCoordinates = autoCorrectCoordinates;
        }

        private ContactHelper _contactHelper;
        private ContactHelper ContactHelper
        {
            get { return _contactHelper ?? (_contactHelper = new ContactHelper(_bizServerVersion)); }
        }

        public void SetGovXmlFromCriteria(GetInspections getInspections, InspectionCriteria criteria, List<string> elements)
        {
            if (criteria == null)
            {
                throw new MobileException(MobileResources.GetString("criteria_required"));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(criteria.InspectionId))
                {
                    Keys keys = KeysHelper.CreateXMLKeys(criteria.InspectionId);
                    getInspections.sequenceNumbers = new ConfirmationNumbers();
                    getInspections.sequenceNumbers.ConfirmationNumber = new string[] {keys.key.Last()};
                    getInspections.openInspectionsOnly = false;
                }
                else
                {
                    if (!String.IsNullOrEmpty(criteria.ScheduleDateFrom)
                        && !String.IsNullOrEmpty(criteria.ScheduleDateTo))
                    {
                        getInspections.scheduledDateRanges = new DateRanges
                        {
                            dateRange = new DateRange[1]
                            {
                                new DateRange
                                {
                                    from = criteria.ScheduleDateFrom,
                                    to = criteria.ScheduleDateTo
                                }
                            }
                        };
                    }

                    if (criteria.InspectorIds != null && criteria.InspectorIds.Count > 0)
                    {
                        int count = criteria.InspectorIds.Count;
                        getInspections.inspectorIds = new InspectorIds();
                        getInspections.inspectorIds.inspectorId = new InspectorId[count];

                        for (var i = 0; i < count; i++)
                        {
                            getInspections.inspectorIds.inspectorId[i] = new InspectorId();
                            getInspections.inspectorIds.inspectorId[i].keys = new Keys()
                            {
                                key = new string[] { criteria.InspectorIds[i] }
                            };
                            
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.RecordId))
                    {
                        getInspections.capId = new CAPId();

                        if (!IsBizVersion710(_bizServerVersion) && !IsBizVersion705(_bizServerVersion))
                        {
                            getInspections.capId.val = criteria.RecordId;
                        }
                        else
                        {
                            getInspections.capId.keys = KeysHelper.CreateXMLKeys(criteria.RecordId);
                        }
                    }

                    if (criteria.RecordTypeIds != null
                        && criteria.RecordTypeIds.Count > 0)
                    {
                        int count = criteria.RecordTypeIds.Count;
                        getInspections.capTypeIds = new CAPTypeIds();
                        getInspections.capTypeIds.capTypeId = new CAPTypeId[count];

                        for (int i = 0; i < criteria.RecordTypeIds.Count; i++)
                        {
                            getInspections.capTypeIds.capTypeId[i] = new CAPTypeId();
                            getInspections.capTypeIds.capTypeId[i].keys =
                                KeysHelper.CreateXMLKeys(criteria.RecordTypeIds[i]);
                        }
                    }

                    if (criteria.Districts != null && criteria.Districts.Count > 0)
                    {
                        int count = criteria.Districts.Count;
                        getInspections.inspectionDistrictIds = new InspectionDistrictIds();
                        getInspections.inspectionDistrictIds.inspectionDistrictId = new InspectionDistrictId[count];

                        for (var i = 0; i < count; i++)
                        {
                            getInspections.inspectionDistrictIds.inspectionDistrictId[i] = new InspectionDistrictId();
                            getInspections.inspectionDistrictIds.inspectionDistrictId[i].keys =
                                KeysHelper.CreateXMLKeys(criteria.Districts[i]);
                        }
                    }

                    if (criteria.Types != null && criteria.Types.Count > 0)
                    {
                        int count = criteria.Types.Count;

                        getInspections.inspectionTypes = new InspectionTypes();
                        getInspections.inspectionTypes.inspectionType = new InspectionType[count];

                        for (int i = 0; i < count; i++)
                        {
                            getInspections.inspectionTypes.inspectionType[i] = new InspectionType();

                            getInspections.inspectionTypes.inspectionType[i].keys =
                                KeysHelper.CreateXMLKeys(criteria.Types[i]);
                        }
                    }

                    var openInspOnly = criteria.OpenInspectionsOnly == null ? "" : criteria.OpenInspectionsOnly.ToLower().Trim();

                    switch (openInspOnly)
                    {
                        case "false":
                        case "0":
                        case "no":
                            getInspections.openInspectionsOnly = false;
                            break;
                        default:
                            getInspections.openInspectionsOnly = true;
                            break;
                    }

                    if (criteria.Contacts != null)
                    {
                        getInspections.contact = ContactHelper.ToXMLSearchContact(criteria.Contacts);
                    }

                    if (!String.IsNullOrWhiteSpace(criteria.ParcelId))
                    {
                        getInspections.parcelId = ParcelHelper.ToGovXmlId(criteria.ParcelId);
                    }

                    if (criteria.Address != null)
                    {
                        getInspections.detailAddress = AddressHelper.ToXmlAddress(criteria.Address);
                    }

                    if (!string.IsNullOrWhiteSpace(criteria.Module))
                    {
                        getInspections.CAP = new CAPCondition();
                        getInspections.CAP.Module = criteria.Module;
                    }

                    if (!String.IsNullOrEmpty(criteria.Status))
                    {
                        getInspections.Status = new Disposition {keys = KeysHelper.CreateXMLKeys(criteria.Status)};
                        getInspections.openInspectionsOnly = false;
                    }
                }

                getInspections.ReturnElements = new returnElements();
                getInspections.ReturnElements.returnElement = (elements == null || elements.Count ==0) ? new string[] {"Departments", "Contacts", "Addresses", "Comments"} : elements.ToArray();
            }
        }

        public Inspection ToXmlInspection(InspectionModel inspectionModel)
        {
            if (inspectionModel == null) return null;

            var result = new Inspection {keys = KeysHelper.CreateXMLKeys(inspectionModel.Identifier)};

            if (!IsBizVersion705(_bizServerVersion))
            {
                result.sequenceNumber = inspectionModel.SequenceNumber;
                result.inspectionContactNumber = inspectionModel.ContactPhoneNumber;
                result.inspectionContactFirstName = inspectionModel.ContactFirstName;
                result.inspectionContactMiddleName = inspectionModel.ContactMiddleName;
                result.inspectionContactLastName = inspectionModel.ContactLastName;
            }

            var isValidWgs84Coordinates = IsValidWgs84Coordinates(inspectionModel.Longitude, inspectionModel.Latitude);
            result.SpatialDescriptors = new SpatialDescriptors
            {
                GPSReference =
                    new GPSReference
                    {
                        latitude = isValidWgs84Coordinates ? inspectionModel.Latitude : null,
                        longitude = isValidWgs84Coordinates ? inspectionModel.Longitude : null
                    }
            };

            result.identifierDisplay = inspectionModel.Display;
            result.contextType = inspectionModel.ContextType;

            result.inspectionStatus = new InspectionStatus();
            if (inspectionModel.Status != null)
            {
                result.inspectionStatus.keys = KeysHelper.CreateXMLKeys(inspectionModel.Status.Identifier);
                result.inspectionStatus.val = inspectionModel.Status.Display;
            }

            if (!string.IsNullOrWhiteSpace(inspectionModel.ResultDate))
            {
                DateTime temResultDate = DateTimeFormat.ToDateFromMetaDateTimeString(inspectionModel.ResultDate);
                result.inspectionStatus.date = DateTimeFormat.ToMetaDateString(temResultDate);
                result.inspectionStatus.time = DateTimeFormat.ToMetaTimeString(temResultDate);
            }

            result.inspectionDate = inspectionModel.ScheduleDate;
            result.inspectionTime = inspectionModel.ScheduleTime;
            result.requestComment = inspectionModel.ScheduleNotes;
            result.inspectionUnitNumber = inspectionModel.InspectionUnit;
            result.requestPhoneNum = inspectionModel.RequestorPhoneNumber;

            if (inspectionModel.AutoAssign)
            {
                result.autoAssign = inspectionModel.AutoAssign;
            }

            if (inspectionModel.Inspector != null)
            {
                result.inspectorId = new InspectorId
                {
                    keys = KeysHelper.CreateXMLKeys(inspectionModel.Inspector.Identifier)
                };
            }

            if (inspectionModel.Type != null)
            {
                result.type = new Automation.GovXmlClient.Model.Type
                {
                    keys = KeysHelper.CreateXMLKeys(inspectionModel.Type.Identifier),
                    identifierDisplay = inspectionModel.Type.Display
                };
            }

            if (inspectionModel.Comments != null)
            {
                result.resultComment = InspectionCommentsHelper.BuildComments4Update(inspectionModel.Comments);
            }

            if (inspectionModel.Checklists != null)
            {
                result.guidesheets = ChecklistHelper.BuildChecklists4Update(inspectionModel.Checklists, _bizServerVersion);
            }

            if (inspectionModel.Record != null)
            {
                result.capId = new CAPId
                {
                    keys = KeysHelper.CreateXMLKeys(inspectionModel.Record.Identifier),
                    identifierDisplay = inspectionModel.Record.Display,
                    val = inspectionModel.Record.Display
                };
            }

            if (!String.IsNullOrWhiteSpace(inspectionModel.Priority))
            {
                result.priority = inspectionModel.Priority;
            }

            if (!String.IsNullOrEmpty(inspectionModel.StartTime)
                || !String.IsNullOrEmpty(inspectionModel.EndTime)
                || !String.IsNullOrEmpty(inspectionModel.TotalTime))
            {
                result.distanceAndTimes = new DistanceAndTimes {distanceAndTime = new DistanceAndTime[1]};
                result.distanceAndTimes.distanceAndTime[0] = new DistanceAndTime
                {
                    time = new time
                    {
                        start = inspectionModel.StartTime,
                        end = inspectionModel.EndTime,
                        total = inspectionModel.TotalTime
                    }
                };
            }

            if (Math.Abs(inspectionModel.StartMileage) > 0
                || Math.Abs(inspectionModel.EndMileage) > 0
                || Math.Abs(inspectionModel.TotalMileage) > 0)
            {
                if (result.distanceAndTimes != null)
                {
                    result.distanceAndTimes.distanceAndTime[0].distance = new distance
                    {
                        start = inspectionModel.StartMileage,
                        end = inspectionModel.EndMileage,
                        total = inspectionModel.TotalMileage
                    };
                }
                else
                {
                    result.distanceAndTimes = new DistanceAndTimes { distanceAndTime = new DistanceAndTime[1] };
                    result.distanceAndTimes.distanceAndTime[0] = new DistanceAndTime
                    {
                        distance = new distance
                        {
                            start = inspectionModel.StartMileage,
                            end = inspectionModel.EndMileage,
                            total = inspectionModel.TotalMileage
                        }
                    };
                }

                result.distanceAndTimes.distanceAndTime[0].vehicleId = inspectionModel.VehicleId;
            }

            if (!IsBizVersion705(_bizServerVersion))
            {
                result.isBillable = inspectionModel.IsBillable.ToYorNString();
                result.isOvertime = inspectionModel.IsOvertime.ToYorNString();
            }

            result.estimatedStartTime = inspectionModel.EstimatedStartTime;
            result.estimatedEndTime = inspectionModel.EstimatedEndTime;

            result.totalScore = inspectionModel.InspectionScore;

            return result;
        }

        public InspectionResponse ToClientInspection(Automation.GovXmlClient.Model.UpdateInspectionResponse updateInspectionResponse)
        {
            InspectionResponse result = new InspectionResponse();

            if (updateInspectionResponse != null
                && updateInspectionResponse.inspection != null)
            {
                result.Events = CommonHelper.GetClientEventMessage(updateInspectionResponse.system.eventMessages);

                var caps = new CAPs()
                {
                    cap = updateInspectionResponse.inspection.cap == null ? null : new CAP[] { updateInspectionResponse.inspection.cap }
                };

                var tempResult = ToClientInspection(updateInspectionResponse.inspection, caps, null);

                var tempResultArray = new InspectionModel[] { tempResult };

                if (_autoCorrectCoordinates)
                {
                    SetCoordinates(tempResultArray);
                }

                result = tempResult == null ? null : new InspectionResponse() { Inspection = tempResult };
            }

            return result;
        }

        public Models.DTOs.Responses.InspectionResponses.UpdateInspectionResponse ToClientUpdateInspection(Automation.GovXmlClient.Model.UpdateInspectionResponse updateInspectionResponse)
        {
            Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses.UpdateInspectionResponse result = new Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses.UpdateInspectionResponse();

            if (updateInspectionResponse != null && updateInspectionResponse.inspection != null)
            {
                result.Events = CommonHelper.GetClientEventMessage(updateInspectionResponse.system.eventMessages);

                var caps = new CAPs()
                {
                    cap = updateInspectionResponse.inspection.cap == null ? null : new CAP[] { updateInspectionResponse.inspection.cap }
                };

                var tempResult = ToClientInspection(updateInspectionResponse.inspection, caps, null);
                var tempResultArray = new InspectionModel[] { tempResult };

                if (_autoCorrectCoordinates)
                {
                    SetCoordinates(tempResultArray);
                }

                result.Inspection = tempResult;
            }

            return result;
        }

        public Models.DTOs.Responses.InspectionResponses.RescheduleInspectionResponse ToClientRescheduleInspection(Automation.GovXmlClient.Model.RescheduleInspectionResponse rescheduleInspectionResponse)
        {
            Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses.RescheduleInspectionResponse response = null;

            if (rescheduleInspectionResponse != null)
            {
                Accela.Automation.GovXmlClient.Model.RescheduleInspectionResponse govxmlResponse = rescheduleInspectionResponse;

                response = new Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses.RescheduleInspectionResponse();

                if (govxmlResponse.inspection != null)
                {
                    var caps = new CAPs()
                    {
                        cap = govxmlResponse.inspection.cap == null
                            ? null
                            : new CAP[] { govxmlResponse.inspection.cap }
                    };
                    InspectionModel tempResult = ToClientInspection(govxmlResponse.inspection, caps, null);
                    var tempResultArray = new InspectionModel[] { tempResult };

                    if (_autoCorrectCoordinates)
                    {
                        SetCoordinates(tempResultArray);
                    }

                    response.Inspection = tempResult;

                }
                else if (govxmlResponse.inspectionId != null && govxmlResponse.inspectionId.keys != null)
                {
                    response.Inspection = new InspectionModel()
                    {
                        Identifier = govxmlResponse.inspectionId.keys.ToStringKeys()
                    };
                }

                response.Events = CommonHelper.GetClientEventMessage(govxmlResponse.system.eventMessages);

            }

            return response;
        }

        public ReassignInspectionResponse ToClientReassignInspection(Automation.GovXmlClient.Model.RescheduleInspectionResponse rescheduleInspectionResponse)
        {
            ReassignInspectionResponse response = null;
            if (rescheduleInspectionResponse != null)
            {
                Accela.Automation.GovXmlClient.Model.RescheduleInspectionResponse govXmlResponse = rescheduleInspectionResponse;

                response = new ReassignInspectionResponse();

                if (govXmlResponse.inspection != null)
                {
                    var caps = new CAPs()
                    {
                        cap =
                            govXmlResponse.inspection.cap == null
                                ? null
                                : new CAP[] { govXmlResponse.inspection.cap }
                    };
                    InspectionModel tempResult = ToClientInspection(govXmlResponse.inspection, caps, null);
                    var tempResultArray = new InspectionModel[] { tempResult };

                    if (_autoCorrectCoordinates)
                    {
                        SetCoordinates(tempResultArray);
                    }

                    response.Inspection = tempResult;

                }
                else if (govXmlResponse.inspectionId != null && govXmlResponse.inspectionId.keys != null)
                {
                    response.Inspection = new InspectionModel()
                    {
                        Identifier = govXmlResponse.inspectionId.keys.ToStringKeys()
                    };
                }

                response.ConfirmationNumber = govXmlResponse.confirmationNumber;
                response.Events = CommonHelper.GetClientEventMessage(govXmlResponse.system.eventMessages);

            }
            return response;
        }

        public Models.DTOs.Responses.InspectionResponses.CancelInspectionResponse ToClientCancelInspection(Automation.GovXmlClient.Model.CancelInspectionResponse cancelInspectionResponse)
        {
            Models.DTOs.Responses.InspectionResponses.CancelInspectionResponse response = null;

            if (cancelInspectionResponse != null)
            {
                response = new Models.DTOs.Responses.InspectionResponses.CancelInspectionResponse();
                response.Events = CommonHelper.GetClientEventMessage(cancelInspectionResponse.system.eventMessages);
            }

            return response;
        }

        public static CreateInspectionResponse ToClientCreateInspection(ScheduleInspectionResponse scheduleInspectionResponse)
        {
            CreateInspectionResponse result = new CreateInspectionResponse();

            if (scheduleInspectionResponse != null)
            {
                result.Events = CommonHelper.GetClientEventMessage(scheduleInspectionResponse.system.eventMessages);

                string inspectionId = null;
                if (scheduleInspectionResponse.inspection != null)
                {
                    inspectionId = KeysHelper.ToStringKeys(scheduleInspectionResponse.inspection.keys);
                }
                else if (scheduleInspectionResponse.inspectionId != null)
                {
                    inspectionId = KeysHelper.ToStringKeys(scheduleInspectionResponse.inspectionId.keys);
                }

                if (!String.IsNullOrEmpty(inspectionId))
                {
                    result.Inspection = new InspectionModel
                    {
                        Identifier = inspectionId
                    };
                }
            }

            return result;
        }

        public List<InspectionModel> ToClientInspections(GetInspectionsResponse xmlObj, List<string> elements)
        {
            List<InspectionModel> retus = null;

            if (xmlObj != null
                && xmlObj.inspectionSheets != null
                && xmlObj.inspectionSheets.inspectionSheet != null
                && xmlObj.inspectionSheets.inspectionSheet.Length > 0)
            {
                retus = new List<InspectionModel>();
                InspectionSheet[] sheets = xmlObj.inspectionSheets.inspectionSheet;

                foreach (var sheet in sheets)
                {
                    if (sheet != null && sheet.inspections != null)
                    {
                        foreach (var xmlInsp in sheet.inspections.inspection)
                        {
                            InspectionModel insp = ToClientInspection(xmlInsp, xmlObj.caps, elements);
                            retus.Add(insp);
                        }
                    }
                }

                if (_autoCorrectCoordinates)
                {
                    SetCoordinates(retus.ToArray());
                }
            }

            return retus;
        }


        private InspectionModel ToClientInspection(Inspection xmlObj, CAPs records, List<string> elements)
        {
            InspectionModel insp = new InspectionModel();
            if (xmlObj.keys != null)
            {
                insp.Identifier = KeysHelper.ToStringKeys(xmlObj.keys);
            }

            insp.SequenceNumber = xmlObj.sequenceNumber;

            // if cann't get sequenceNumber from xmlObj.sequenceNumber then get it from Keys[lastIndex]
            if (String.IsNullOrWhiteSpace(insp.SequenceNumber) && xmlObj.keys != null && xmlObj.keys.key != null && xmlObj.keys.key.Length > 0)
            {
                insp.SequenceNumber = xmlObj.keys.key[xmlObj.keys.key.Length - 1];
            }

            insp.Display = xmlObj.identifierDisplay;
            insp.ContextType = xmlObj.contextType;
            if (xmlObj.inspectionStatus != null)
            {
                if (xmlObj.inspectionStatus.date != null)
                {
                    insp.ResultDate = xmlObj.inspectionStatus.date;
                }

                if (xmlObj.inspectionStatus.time != null)
                {
                    insp.ResultDate += " " + xmlObj.inspectionStatus.time;
                }
            }

            insp.ScheduleDate = xmlObj.inspectionDate;
            insp.ScheduleTime = xmlObj.inspectionTime;
            insp.ScheduleNotes = xmlObj.requestComment;
            if (xmlObj.detailAddress != null)
            {
                insp.Address = AddressHelper.GetClientAddressStringBy(xmlObj.detailAddress);
                insp.DetailAddress = AddressHelper.GetDetailAddress(xmlObj.detailAddress);
                //The solution only tem to resolve geocode address.
                //when geocode address, we don't need unit and unit type.
                //if we are pass the two field, it will cause get wrong coordinate
                insp.AddressForGeocode = AddressHelper.GetClientGeoAddressStringBy(xmlObj.detailAddress);
                insp.Longitude = xmlObj.detailAddress.xCoordinate;
                insp.Latitude = xmlObj.detailAddress.yCoordinate;
                insp.AutoCaptureGPSLongitude = xmlObj.detailAddress.xCoordinate;
                insp.AutoCaptureGPSLatitude = xmlObj.detailAddress.yCoordinate;
            }
            else if (xmlObj.compactAddress != null)
            {
                insp.Address = AddressHelper.GetClientAddressStringBy(xmlObj.compactAddress);
            }

            insp.InspectionUnit = xmlObj.inspectionUnitNumber;
            insp.RequestorPhoneNumber = xmlObj.requestPhoneNum;
            //It will get contact from Record Contacts node.
            CAP matchedRecord = null;

            if (records != null && records.cap != null)
            {
                foreach (var item in records.cap)
                {
                    if (KeysHelper.ToStringKeys(item.keys) == KeysHelper.ToStringKeys(xmlObj.capId.keys))
                    {
                        matchedRecord = item;
                        break;
                    }
                }
            }

            // get license Professional from CAP
            if (matchedRecord != null && matchedRecord.contacts != null && matchedRecord.contacts.contact != null)
            {
                var contactModelList = (from c in matchedRecord.contacts.contact
                                        let contactModel = ContactHelper.ToClientContact(c)
                                        select contactModel).ToList();
                insp.LicensedProfessional = ToLicensedProfessional(contactModelList);
            }

            Contacts contacts = null;

            if (xmlObj.contacts != null && xmlObj.contacts.contact != null)
            {
                contacts = xmlObj.contacts;
            }
            else if (matchedRecord != null)
            {
                contacts = matchedRecord.contacts;
            }

            if (!string.IsNullOrEmpty(xmlObj.inspectionContactFirstName) || !string.IsNullOrEmpty(xmlObj.inspectionContactMiddleName) || !string.IsNullOrEmpty(xmlObj.inspectionContactLastName))
            {
                insp.ContactFirstName = xmlObj.inspectionContactFirstName;
                insp.ContactMiddleName = xmlObj.inspectionContactMiddleName;
                insp.ContactLastName = xmlObj.inspectionContactLastName;
                insp.ContactPhoneNumber = xmlObj.inspectionContactNumber;
            }
            else if (contacts != null)
            {
                var contact = ContactHelper.GetContact(contacts);
                var contactModel = ContactHelper.ToClientContact(contact);

                if (contactModel != null)
                {
                    insp.ContactName = ContactHelper.ToContactName(contactModel);
                    insp.ContactPhoneNumber = contactModel.Tels != null && contactModel.Tels.Count > 0 ? contactModel.Tels[0] : String.Empty;
                }
            }


            if (xmlObj.SpatialDescriptors != null
                && xmlObj.SpatialDescriptors.GPSReference != null
                && !String.IsNullOrEmpty(xmlObj.SpatialDescriptors.GPSReference.latitude)
                && !String.IsNullOrEmpty(xmlObj.SpatialDescriptors.GPSReference.longitude))
            {
                insp.Latitude = xmlObj.SpatialDescriptors.GPSReference.latitude;
                insp.Longitude = xmlObj.SpatialDescriptors.GPSReference.longitude;
                insp.AutoCaptureGPSLatitude = xmlObj.SpatialDescriptors.GPSReference.latitude;
                insp.AutoCaptureGPSLongitude = xmlObj.SpatialDescriptors.GPSReference.longitude;
            }

            if (xmlObj.Departments != null)
            {
                insp.Department = xmlObj.Departments.identifierDisplay;
            }

            if (xmlObj.type != null)
            {
                insp.Type = new InspectionTypeModel();
                if (xmlObj.type.keys != null)
                {
                    insp.Type.Identifier = xmlObj.type.keys.ToStringKeys();
                }

                insp.Type.Display = xmlObj.type.identifierDisplay;
            }

            insp.Status = ToClientInspectionStatus(xmlObj.inspectionStatus);

            if (xmlObj.inspector != null)
            {
                insp.Inspector = new InspectorModel();
                if (xmlObj.inspector.keys != null)
                {
                    insp.Inspector.Identifier = xmlObj.inspector.keys.ToStringKeys();
                }

                insp.Inspector.Name = CommonHelper.GetPersonName(xmlObj.inspector.person);
                if (string.IsNullOrWhiteSpace(insp.Inspector.Name) && xmlObj.inspector.keys.key != null)
                {
                    insp.Inspector.Name = String.Join(" ", xmlObj.inspector.keys.key);
                }
            }

            if (matchedRecord != null)
            {
                insp.Record = new RecordModel();
                if (matchedRecord.keys != null)
                {
                    insp.Record.Identifier = KeysHelper.ToStringKeys(matchedRecord.keys);
                }

                insp.Record.Display = matchedRecord.identifierDisplay;

                insp.Record.Name = matchedRecord.name;

                if (matchedRecord.type != null)
                {
                    insp.Record.RecordType = new RecordTypeModel();
                    insp.Record.RecordType.Identifier = KeysHelper.ToStringKeys(matchedRecord.type.keys);
                    insp.Record.RecordType.Display = matchedRecord.type.identifierDisplay;
                }
            }
            else if (xmlObj.capId != null)
            {
                insp.Record = new RecordModel();
                if (xmlObj.capId.keys != null)
                {
                    insp.Record.Identifier = KeysHelper.ToStringKeys(xmlObj.capId.keys);
                }

                insp.Record.Display = xmlObj.capId.identifierDisplay;
            }

            if (!String.IsNullOrWhiteSpace(xmlObj.priority))
            {
                insp.Priority = xmlObj.priority;
            }

            // if elements==null, then we will convert checklist, also if the elements contains checklists also it will convesion it. else will not conversion
            // it can save conversion time, if client don't need the element
            // add by robert to save conversion time for some case, like inspection history
            if (elements == null || elements.Contains("checklists"))
            {
                insp.Checklists = ChecklistHelper.GetClientChecklists(xmlObj.guidesheets);
            }

            if (elements == null || elements.Contains("comments"))
            {
                insp.Comments = InspectionCommentsHelper.ExtractCustomizedComments(xmlObj.resultComment, xmlObj.inspectionDate, insp.Inspector != null ? insp.Inspector.Name : "");
            }

            if (xmlObj.distanceAndTimes != null
                && xmlObj.distanceAndTimes.distanceAndTime != null
                && xmlObj.distanceAndTimes.distanceAndTime.Length > 0)
            {

                if (xmlObj.distanceAndTimes.distanceAndTime[0].time != null)
                {
                    insp.StartTime = xmlObj.distanceAndTimes.distanceAndTime[0].time.start;
                    insp.EndTime = xmlObj.distanceAndTimes.distanceAndTime[0].time.end;
                    insp.TotalTime = xmlObj.distanceAndTimes.distanceAndTime[0].time.total;
                }

                if (xmlObj.distanceAndTimes.distanceAndTime[0].distance != null)
                {
                    insp.StartMileage = xmlObj.distanceAndTimes.distanceAndTime[0].distance.start;
                    insp.EndMileage = xmlObj.distanceAndTimes.distanceAndTime[0].distance.end;
                    insp.TotalMileage = xmlObj.distanceAndTimes.distanceAndTime[0].distance.total;
                }

                insp.VehicleId = xmlObj.distanceAndTimes.distanceAndTime[0].vehicleId;
            }

            if (!String.IsNullOrEmpty(xmlObj.isBillable))
            {
                insp.IsBillable = BoolHelper.IsTrueString(xmlObj.isBillable);
            }

            if (!String.IsNullOrEmpty(xmlObj.isOvertime))
            {
                insp.IsOvertime = BoolHelper.IsTrueString(xmlObj.isOvertime);
            }

            insp.EstimatedStartTime = xmlObj.estimatedStartTime;
            insp.EstimatedEndTime = xmlObj.estimatedEndTime;

            insp.InspectionScore = xmlObj.totalScore;

            return insp;
        }

        private static InspectionStatusModel ToClientInspectionStatus(Automation.GovXmlClient.Model.InspectionStatus xmlObj)
        {
            InspectionStatusModel result = null;
            if (xmlObj != null)
            {
                result = new InspectionStatusModel();
                if (xmlObj.keys != null)
                {
                    result.Identifier = xmlObj.keys.ToStringKeys();
                }

                result.Display = xmlObj.val;
                //the logic need notice. currently, in the status, server didn't return the type.
                //but the type is put in the keys. the keys consist by Type and Status Key two part
                if (xmlObj.keys != null && xmlObj.keys.key != null && xmlObj.keys.key.Length > 0)
                {
                    result.Type = xmlObj.keys.key[0];
                }
            }

            return result;
        }

        private static string ToLicensedProfessional(List<ContactModel> contactList)
        {
            string result = String.Empty;

            if (contactList == null)
            {
                return result;
            }

            foreach (var contact in contactList)
            {
                if (contact != null && ContactHelper.IsLicensedProfessional(contact))
                {
                    bool isPrimary = "true".Equals(contact.IsPrimary, StringComparison.OrdinalIgnoreCase);
                    string lpName = null;

                    if (!String.IsNullOrWhiteSpace(contact.BusinessName))
                    {
                        lpName = contact.BusinessName;
                    }
                    else
                    {
                        var middleNameArray = contact.MiddleNames != null && contact.MiddleNames.Count > 0 ? contact.MiddleNames.ToArray() : null;
                        lpName = CommonHelper.GetFullName(contact.FullName, contact.GivenName, middleNameArray, contact.FamilyName);
                    }

                    if (isPrimary && !String.IsNullOrWhiteSpace(lpName))
                    {
                        result = lpName;
                        break;
                    }

                    if (!isPrimary && String.IsNullOrWhiteSpace(result))
                    {
                        result = lpName;
                    }
                }
            }

            return result;
        }


        public static void SetCoordinates(InspectionModel[] targetInspections)
        {
            try
            {
                if (targetInspections != null)
                {
                    var _coordinateRepository = IocContainer.Resolve<ICoordinateRepository>();

                    //Find local x,y both exist value.
                    var inspectionsXYNotEmpty = targetInspections.Where(o => o.DetailAddress != null && !string.IsNullOrWhiteSpace(o.DetailAddress.XCoordinate) && !string.IsNullOrWhiteSpace(o.DetailAddress.XCoordinate)).ToList();

                    //Find local x, y both valid.
                    var inspectionsValidXY = inspectionsXYNotEmpty.FindAll(o => (Math.Abs(double.Parse(o.DetailAddress.YCoordinate)) <= 90 && Math.Abs(double.Parse(o.DetailAddress.XCoordinate)) <= 180) && (double.Parse(o.DetailAddress.XCoordinate) != 0 && double.Parse(o.DetailAddress.YCoordinate)!=0));

                    //Find x,y empty or invalid.
                    List<InspectionModel> includedAddressItem = targetInspections.ToList().Except(inspectionsValidXY).ToList();

                    //Set empty or invalid x,y to null.
                    includedAddressItem.ForEach(insp =>
                    {
                        insp.Longitude = null;
                        insp.Latitude = null;
                        if (insp.DetailAddress != null)
                        {
                            insp.DetailAddress.XCoordinate = null;
                            insp.DetailAddress.YCoordinate = null;
                        }
                    });

                    includedAddressItem = includedAddressItem.Where((o) => !string.IsNullOrWhiteSpace(o.AddressForGeocode)).ToList();

                    if (includedAddressItem.Count > 0)
                    {
                        var addressList = includedAddressItem.Select(i => i.AddressForGeocode).ToArray();
                        var geocodeAddresses = _coordinateRepository.GetCoordinates(addressList);

                        if (geocodeAddresses != null && geocodeAddresses.Length > 0)
                        {
                            for (int i = 0; i < includedAddressItem.Count; i++)
                            {
                                var currentInspection = includedAddressItem[i];
                                var geocodeAddress = geocodeAddresses[i];

                                if (geocodeAddress != null && !Double.IsNaN(geocodeAddress.LocationX) && !Double.IsNaN(geocodeAddress.LocationY))
                                {
                                    currentInspection.Longitude = geocodeAddress.LocationX.ToString();
                                    currentInspection.Latitude = geocodeAddress.LocationY.ToString();
                                    if (currentInspection.DetailAddress == null)
                                    {
                                        currentInspection.DetailAddress = new DetailAddressModel();
                                    }
                                    currentInspection.DetailAddress.XCoordinate = geocodeAddress.LocationX.ToString();
                                    currentInspection.DetailAddress.YCoordinate = geocodeAddress.LocationY.ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            // TODO:
            // Use the new DLL
            // Remove the below code later because there is no such thing in the new DLL.
            //Log.Performance(Reflection.CurrentMethodName, Reflection.Stopwatch(watch), "Map SetCoordinates for Inspection");
        }

        public static void AssignContactAndAddress(List<InspectionModel> inspections, List<RecordModel> records)
        {
            var watch1 = Reflection.Startwatch();

            if (inspections != null && inspections.Count > 0 && records != null && records.Count > 0)
            {
                foreach (var inspection in inspections)
                {
                    if (inspection == null || inspection.Record == null || String.IsNullOrWhiteSpace(inspection.Record.Identifier))
                    {
                        continue;
                    }

                    RecordModel matchedRecord = null;

                    foreach (var record in records)
                    {
                        if (record == null || String.IsNullOrWhiteSpace(record.Identifier))
                        {
                            continue;
                        }

                        if (record.Identifier == inspection.Record.Identifier)
                        {
                            matchedRecord = record;
                            break;
                        }
                    }

                    // assign contact name, contact phone number and licensed professional.
                    if (matchedRecord != null && matchedRecord.Contacts != null && matchedRecord.Contacts.Count > 0)
                    {
                        inspection.LicensedProfessional = ToLicensedProfessional(matchedRecord.Contacts);
                    }

                    // assign address
                    if (matchedRecord != null && matchedRecord.Addresses != null && matchedRecord.Addresses.Count > 0 && matchedRecord.Addresses[0] != null)
                    {
                        var currentAddress = matchedRecord.Addresses[0];
                        inspection.Address = AddressHelper.GetClientAddressStringBy(currentAddress);
                        inspection.DetailAddress = AddressHelper.GetDetailAddress(currentAddress);
                        //The solution only tem to resolve geocode address.
                        //when geocode address, we don't need unit and unit type.
                        //if we are pass the two field, it will cause get wrong coordinate
                        inspection.AddressForGeocode = AddressHelper.GetClientGeoAddressStringBy(currentAddress);

                        if (!String.IsNullOrWhiteSpace(currentAddress.YCoordinate) && !String.IsNullOrWhiteSpace(currentAddress.XCoordinate))
                        {
                            inspection.Latitude = currentAddress.YCoordinate;
                            inspection.Longitude = currentAddress.XCoordinate;

                            inspection.DetailAddress.XCoordinate = currentAddress.XCoordinate;
                            inspection.DetailAddress.YCoordinate = currentAddress.YCoordinate;
                        }
                    }
                }
            }

            // TODO:
            // Use the new DLL
            // Remove the below code later because there is no such thing in the new DLL.
            //Log.Performance(Reflection.CurrentMethodName, Reflection.Stopwatch(watch1), "GetJobsWithNoChecklists - Assign record contact and address");
        }

        public static void AssginRecordName(List<InspectionModel> inspectionModels, List<RecordModel> recordModels)
        {
            if (inspectionModels != null && inspectionModels.Count > 0 &&
                recordModels != null && recordModels.Count > 0)
            {
                foreach (var inspectionModel in inspectionModels)
                {
                    if (inspectionModel.Record != null)
                    {
                        var record = recordModels.Find(r => r.Identifier == inspectionModel.Record.Identifier);
                        if (record != null)
                        {
                            inspectionModel.Record.Name = record.Name;
                        }
                    }
                }
            }
        }

        public AvailableInspectionDatesResponse ToClientAvailableInspectionDates(GetAvailableInspectionDatesResponse xmlObj)
        {
            AvailableInspectionDatesResponse result = null;

            if (xmlObj != null
                && xmlObj.availableDate != null)
            {
                result = new AvailableInspectionDatesResponse();
                result.Dates = new List<string>();

                xmlObj.availableDate.ToList().ForEach(date => result.Dates.Add(date));
            }

            return result;
        }

        private bool IsValidWgs84Coordinates(string x, string y)
        {
            var result = false;
            double parsedX, parsedY;

            if (Double.TryParse(x, out parsedX) && Double.TryParse(y, out parsedY))
            {
                if (parsedX <= 180 && parsedX >= -180 && parsedY <= 90 && parsedY >= -90)
                {
                    result = true;
                }
            }

            return result;
        }
    }

    public static class BoolExtensions
    {
        public static string ToYorNString(this bool b)
        {
            return b ? "Y" : "N";
        }
    }
}
