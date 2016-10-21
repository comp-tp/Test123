/**
 * <pre>
 * 
 *  Accela Mobile Office
 *  File: GovXML.cs
 * 
 *  Accela, Inc.
 *  Copyright (C): 2010-2011
 * 
 *  Description:
 *  All DataModel class must inherit the class.
 * 
 *  Note
 *  Created By: aw system
 * </pre>
 */
using System;
using System.Xml.Serialization;
using Accela.GIS.GovXml.Model;
using Accela.Automation.GovXmlServices.Client.Model;

namespace Accela.Automation.GovXmlClient.Model
{
	[XmlRootAttribute("GovXML", Namespace="http://www.accela.com/schema/AccelaOpenSystemInterfaceXML", IsNullable=false)]
	public class GovXML 
	{

        #region ChangePassword
        [XmlElement(ElementName = "ChangePassword")]
        public ChangePassword changePassword;

        [XmlElement(ElementName = "ChangePasswordResponse")]
        public ChangePasswordResponse changePasswordResponse;
        #endregion

        #region CalculateRoute
        [XmlElement(ElementName = "CalculateRoute")]
		public CalculateRoute_5_2 calculateRoute;

		[XmlElement(ElementName = "CalculateRouteResponse")]
		public CalculateRouteResponse_5_2 calculateRouteResponse;
		#endregion

		#region CancelInspection
		[XmlElement(ElementName = "CancelInspection")]
		public CancelInspection cancelInspection;

		[XmlElement(ElementName = "CancelInspectionResponse")]
		public CancelInspectionResponse cancelInspectionResponse;
		#endregion

		#region CreateAsset
		[XmlElement(ElementName = "CreateAsset")]
		public CreateAsset createAsset;

		[XmlElement(ElementName = "CreateAssetResponse")]
		public CreateAssetResponse createAssetResponse;
		#endregion

		#region CreateDocument
		[XmlElement(ElementName = "CreateDocument")]
		public CreateDocument createDocument;

		[XmlElement(ElementName = "CreateDocumentResponse")]
		public CreateDocumentResponse createDocumentResponse;
		#endregion

		#region DeleteDocument
		[XmlElement(ElementName = "DeleteDocument")]
		public DeleteDocument deleteDocument;

		[XmlElement(ElementName = "DeleteDocumentResponse")]
		public DeleteDocumentResponse deleteDocumentResponse;
		#endregion

		#region FinalizeCAP
		[XmlElement(ElementName = "FinalizeCAP")]
		public FinalizeCAP finalizeCAP;

		[XmlElement(ElementName = "FinalizeCAPResponse")]
		public FinalizeCAPResponse finalizeCAPResponse;
		#endregion

		#region FSystem
		[XmlElement(ElementName = "FSystemOut")]
		public FSystemOut fSystemOut;
		#endregion

		#region GetAdditionalInformationGroups
		[XmlElement(ElementName = "GetAdditionalInformationGroups")]
		public GetAdditionalInformationGroups GetAdditionalInformationGroups;

		[XmlElement(ElementName = "GetAdditionalInformationGroupsResponse")]
		public GetAdditionalInformationGroupsResponse GetAdditionalInformationGroupsResponse;
		#endregion

		#region GetAssets
		[XmlElement(ElementName = "GetAssets")]
		public GetAssets getAssets;

		[XmlElement(ElementName = "GetAssetsResponse")]
		public GetAssetsResponse getAssetsResponse;
		#endregion

        //Author:Liner Lin
        //Date:2008-09-23
        //Desc:06ACC-00918 Seach Licensed Professional
        #region GetLicensedProfessionals
        [XmlElement(ElementName = "GetLicensedProfessionals")]
        public GetLicensedProfessionals getLicensedProfessionals;

        [XmlElement(ElementName = "GetLicensedProfessionalsResponse")]
        public GetLicensedProfessionalsResponse getLicensedProfessionalsResponse;
        #endregion
        //end

		#region GetAssetTypes
		[XmlElement(ElementName = "GetAssetTypes")]
		public GetAssetTypes getAssetTypes;

		[XmlElement(ElementName = "GetAssetTypesResponse")]
		public GetAssetTypesResponse getAssetTypesResponse;

		#endregion

        #region GetAssetTypes
        [XmlElement(ElementName = "GetAPOTemplate")]
        public GetAPOTemplate getAPOTemplate;

        [XmlElement(ElementName = "GetAPOTemplateResponse")]
        public GetAPOTemplateResponse getAPOTemplateResponse;

        #endregion


        #region GetAssetUsages
        [XmlElement(ElementName = "GetAssetUsages")]
        public GetAssetUsages getAssetUsages;

        [XmlElement(ElementName = "GetAssetUsagesResponse")]
        public GetAssetUsagesResponse getAssetUsagesResponse;
        #endregion

        #region GetTimeAccountingGroups
        [XmlElement(ElementName = "GetTimeAccountingGroups")]
        public GetTimeAccountingGroups getTimeAccountingGroups;

        [XmlElement(ElementName = "GetTimeAccountingGroupsResponse")]
        public GetTimeAccountingGroupsResponse getTimeAccountingGroupsResponse;
        #endregion

        #region GetTimeAccountingTypes
        [XmlElement(ElementName = "GetTimeAccountingTypes")]
        public GetTimeAccountingTypes getTimeAccountingTypes;

        [XmlElement(ElementName = "GetTimeAccountingTypesResponse")]
        public GetTimeAccountingTypesResponse getTimeAccountingTypesResponse;
        #endregion

        #region GetUserSecurities
        [XmlElement(ElementName = "GetUserSecurities")]
        public GetUserSecurities getUserSecurities;

        [XmlElement(ElementName = "GetUserSecuritiesResponse")]
        public GetUserSecuritiesResponse getUserSecuritiesResponse;
        #endregion GetUserSecurities

        #region GetStandardChoices

        [XmlElement(ElementName = "GetStandardChoices")]
        public GetStandardChoices getStandardChoices;

        [XmlElement(ElementName = "GetStandardChoicesResponse")]
        public GetStandardChoicesResponse getStandardChoicesResponse;

        #endregion

        #region GetCAPs
        [XmlElement(ElementName = "GetCAPs")]
		public GetCAPs getCAPs;

		[XmlElement(ElementName = "GetCAPsResponse")]
		public GetCAPsResponse getCAPsResponse;
		#endregion

		#region GetCAPTypes
		[XmlElement(ElementName = "GetCAPTypes")]
		public GetCAPTypes getCAPTypes;

		[XmlElement(ElementName = "GetCAPTypesResponse")]
		public GetCAPTypesResponse getCAPTypesResponse;
		#endregion

		#region GetCities
		[XmlElement(ElementName = "GetCities")]
		public GetCities getCities;

		[XmlElement(ElementName = "GetCitiesResponse")]
		public GetCitiesResponse getCitiesResponse;
		#endregion

		#region GetConditionTypes
		[XmlElement(ElementName = "GetConditionTypes")]
		public GetConditionTypes getConditionTypes;
        
		[XmlElement(ElementName = "GetConditionTypesResponse")]
		public GetConditionTypesResponse getConditionTypesResponse;
		#endregion

		#region GetCostTypes
		[XmlElement(ElementName = "GetCostTypes")]
		public GetCostTypes getCostTypes;
		
		[XmlElement(ElementName = "GetCostTypesResponse")]
		public GetCostTypesResponse getCostTypesResponse;
		#endregion
		
		#region GetDepartments
		[XmlElement(ElementName = "GetDepartments")]
		public GetDepartments getDepartments;
		
		[XmlElement(ElementName = "GetDepartmentsResponse")]
		public GetDepartmentsResponse getDepartmentsResponse;
		#endregion

		#region GetDispositions
		[XmlElement(ElementName = "GetDispositions")]
		public GetDispositions getDispositions;

		[XmlElement(ElementName = "GetDispositionsResponse")]
		public GetDispositionsResponse getDispositionsResponse;
		#endregion

		#region GetDocument
		[XmlElement(ElementName = "GetDocument")]
		public GetDocument getDocument;

		[XmlElement(ElementName = "GetDocumentResponse")]
		public GetDocumentResponse getDocumentResponse;
		#endregion

		#region GetDocumentList
		[XmlElement(ElementName = "GetDocumentList")]
		public GetDocumentList getDocumentList;

		[XmlElement(ElementName = "GetDocumentListResponse")]
		public GetDocumentListResponse getDocumentListResponse;
		#endregion

		#region GetDocuments
		[XmlElement(ElementName = "GetDocuments")]
		public GetDocuments getDocuments;

		[XmlElement(ElementName = "GetDocumentsResponse")]
		public GetDocumentsResponse getDocumentsResponse;
		#endregion

		#region GetGuidesheets
		[XmlElement(ElementName = "GetGuidesheets")]
		public GetGuidesheets getGuidesheets;

		[XmlElement(ElementName = "GetGuidesheetsResponse")]
		public GetGuidesheetsResponse getGuidesheetsResponse;
		#endregion

		#region GetHoldTypes
		[XmlElement(ElementName = "GetHoldTypes")]
		public GetHoldTypes GetHoldTypes;

		[XmlElement(ElementName = "GetHoldTypesResponse")]
		public GetHoldTypesResponse GetHoldTypesResponse;
		#endregion

		#region GetInspectionDistricts
		[XmlElement(ElementName = "GetInspectionDistricts")]
		public GetInspectionDistricts GetInspectionDistricts;

		[XmlElement(ElementName = "GetInspectionDistrictsResponse")]
		public GetInspectionDistrictsResponse GetInspectionDistrictsResponse;
		#endregion

		#region GetInspections
		[XmlElement(ElementName = "GetInspections")]
		public GetInspections getInspections;

		[XmlElement(ElementName = "GetInspectionsResponse")]
		public GetInspectionsResponse getInspectionsResponse;
		#endregion

		#region GetInspectionTypes
		[XmlElement(ElementName = "GetInspectionTypes")]
		public GetInspectionTypes getInspectionTypes;
        
		[XmlElement(ElementName = "GetInspectionTypesResponse")]
		public GetInspectionTypesResponse getInspectionTypesResponse;
		#endregion

		#region GetInspectionUnitNumbers
		[XmlElement(ElementName = "GetInspectionUnitNumbers")]
		public GetInspectionUnitNumbers getInspectionUnitNumbers;

		[XmlElement(ElementName = "GetInspectionUnitNumbersResponse")]
		public GetInspectionUnitNumbersResponse getInspectionUnitNumbersResponse;
		#endregion

		#region GetInspectors
		[XmlElement(ElementName = "GetInspectors")]
		public GetInspectors getInspectors;

		[XmlElement(ElementName = "GetInspectorsResponse")]
		public GetInspectorsResponse getInspectorsResponse;
		#endregion

		#region GetLicenseTypes
		[XmlElement(ElementName = "GetLicenseTypes")]
		public GetLicenseTypes getLicenseTypes;

		[XmlElement(ElementName = "GetLicenseTypesResponse")]
		public GetLicenseTypesResponse getLicenseTypesResponse;
		#endregion

        #region GetContacts
        [XmlElement(ElementName = "GetContacts")]
        public GetContacts getContacts;

        [XmlElement(ElementName = "GetContactsResponse")]
        public GetContactsResponse getContactsResponse;
        #endregion

        #region GetParcels
        [XmlElement(ElementName = "GetParcels")]
		public GetParcels getParcels;

		[XmlElement(ElementName = "GetParcelsResponse")]
		public GetParcelsResponse getParcelsResponse;
		#endregion

        #region GetOwners
        [XmlElement(ElementName = "GetOwners")]
        public GetOwners getOwners;

        [XmlElement(ElementName = "GetOwnersResponse")]
        public GetOwnersResponse getOwnersResponse;
        #endregion

        #region GetAuditLogs
        [XmlElement(ElementName = "GetAuditLogs")]
        public GetAuditLogs getAuditLogs;

        [XmlElement(ElementName = "GetAuditLogsResponse")]
        public GetAuditLogsResponse getAuditLogsResponse;
        #endregion

		#region GetPartTypes
		[XmlElement(ElementName = "GetPartTypes")]
		public GetPartTypes getPartTypes;
		
		[XmlElement(ElementName = "GetPartTypesResponse")]
		public GetPartTypesResponse getPartTypesResponse;
		#endregion

		#region GetPartInventory
		[XmlElement(ElementName = "GetPartInventory")]
		public GetPartInventory getPartInventory;
		
		[XmlElement(ElementName = "GetPartInventoryResponse")]
		public GetPartInventoryResponse getPartInventoryResponse;
		#endregion 

		#region GetRoles
		[XmlElement(ElementName = "GetRoles")]
		public GetRoles getRoles;

		[XmlElement(ElementName = "GetRolesResponse")]
		public GetRolesResponse getRolesResponse;
		#endregion

		#region GetSeverityLevels 
		[XmlElement(ElementName = "GetSeverityLevels")]
		public GetSeverityLevels getSeverityLevels;
        
		[XmlElement(ElementName = "GetSeverityLevelsResponse")]
		public GetSeverityLevelsResponse getSeverityLevelsResponse;
		#endregion

		#region GetStandardComments
		[XmlElement(ElementName = "GetStandardComments")]
		public GetStandardComments getStandardComments;

		[XmlElement(ElementName = "GetStandardCommentsResponse")]
		public GetStandardCommentsResponse getStandardCommentsResponse;
		#endregion

		#region GetWorksheets
		[XmlElement(ElementName = "GetWorksheets")]
		public GetWorksheets getWorksheets;

		[XmlElement(ElementName = "GetWorksheetsResponse")]
		public GetWorksheetsResponse getWorksheetsResponse;
		#endregion

		#region InitiateCAP
		[XmlElement(ElementName = "InitiateCAP")]
		public InitiateCAP initiateCAP;

        private InitiateCAPResponse _initiateCAPResponse = null;
		[XmlElement(ElementName = "InitiateCAPResponse")]
		public InitiateCAPResponse initiateCAPResponse
        {
            get
            {
                return _initiateCAPResponse;
            }
            set
            {
                _initiateCAPResponse = value;
            }
        }
		#endregion

		#region PassGISObjects
		[XmlElement(ElementName = "PassGISObjects")]
		public PassGISObjects_5_2 passGISObjects;

		[XmlElement(ElementName = "PassGISObjectsResponse")]
		public PassGISObjectsResponse_5_2 passGISObjectsResponse;
		#endregion

		#region PostMileage
		[XmlElement(ElementName = "PostMileage")]
		public PostMileage postMileage;

		[XmlElement(ElementName = "PostMileageResponse")]
		public PostMileageResponse postMileageResponse;
		#endregion

		#region RescheduleInspection
		[XmlElement(ElementName = "RescheduleInspection")]
		public RescheduleInspection rescheduleInspection;

		[XmlElement(ElementName = "RescheduleInspectionResponse")]
		public RescheduleInspectionResponse rescheduleInspectionResponse;
		#endregion

		#region ScheduleInspection
		[XmlElement(ElementName = "ScheduleInspection")]
		public ScheduleInspection scheduleInspection;

		[XmlElement(ElementName = "ScheduleInspectionResponse")]
		public ScheduleInspectionResponse scheduleInspectionResponse;
		#endregion

		#region SetInspectionPriority
		[XmlElement(ElementName = "SetInspectionPriority")]
		public SetInspectionPriority setInspectionPriority;

		[XmlElement(ElementName = "SetInspectionPriorityResponse")]
		public SetInspectionPriorityResponse setInspectionPriorityResponse;
		#endregion

		#region System
		[XmlElement(ElementName = "SystemResponse")]
		public SystemResponse systemResponse;
		#endregion

		#region UpdateAsset
		[XmlElement(ElementName = "UpdateAsset")]
		public UpdateAsset updateAsset;
		
		[XmlElement(ElementName = "UpdateAssetResponse")]
		public UpdateAssetResponse updateAssetResponse;
		#endregion

        //Author:Liner Lin
        //Date:2008-09-25
        //Desc:08ACC-03707 Apply Parcel Conditions
        #region UpdateParcel
        [XmlElement(ElementName = "UpdateParcel")]
        public UpdateParcel updateParcel;

        [XmlElement(ElementName = "UpdateParcelResponse")]
        public UpdataParcelResponse updateParcelResponse;
        #endregion
        //end

		#region UpdateInspection
		[XmlElement(ElementName = "UpdateInspection")]
		public UpdateInspection updateInspection;

		[XmlElement(ElementName = "UpdateInspectionResponse")]
		public UpdateInspectionResponse updateInspectionResponse;
		#endregion

		#region UpdateCAP
		[XmlElement(ElementName = "UpdateCAP")]
		public UpdateCAP UpdateCAP;

        private UpdateCAPResponse _updateCAPResponse = null;
        [XmlElement(ElementName = "UpdateCAPResponse")]
        public UpdateCAPResponse UpdateCAPResponse
        {
            get
            {
                return _updateCAPResponse;
            }
            set
            {
                _updateCAPResponse = value;
            }
        }

		#endregion

		#region UpdateDocument
		[XmlElement(ElementName = "UpdateDocument")]
		public UpdateDocument updateDocument;

		[XmlElement(ElementName = "UpdateDocumentResponse")]
		public UpdateDocumentResponse updateDocumentResponse;
		#endregion

        #region GetDocumentGroups
        //Author: Robert Luo
        //Date:2007-12-10
        //Desc:Bugzilla:4384(07ACC-05951)--[650]Upload Files from CAP forms
        [XmlElement(ElementName = "GetDocumentGroups")]
        public GetDocumentGroups getDocumentGroups;
        //Author: Robert Luo
        //Date:2007-12-10
        //Desc:Bugzilla:4384(07ACC-05951)--[650]Upload Files from CAP forms
        [XmlElement(ElementName = "GetDocumentGroupsResponse")]
        public GetDocumentGroupsResponse getDocumentGroupsResponse;
        #endregion

        #region Asset CA 

        [XmlElement(ElementName = "GetAssetCATypes")]
        public GetAssetCATypes GetAssetCATypes { get; set; }

        [XmlElement(ElementName = "GetAssetCATypesResponse")]
        public GetAssetCATypesResponse GetAssetCATypesResponse { get; set; }

        [XmlElement(ElementName = "GetAssetCAs")]
        public GetAssetCAs GetAssetCAs { get; set; }

        [XmlElement(ElementName = "GetAssetCAsResponse")]
        public GetAssetCAsResponse GetAssetCAsResponse { get; set; }

        [XmlElement(ElementName = "GetAssetCAStatus")]
        public GetAssetCAStatus GetAssetCAStatus { get; set; }

        [XmlElement(ElementName = "GetAssetCAStatusResponse")]
        public GetAssetCAStatusResponse GetAssetCAStatusResponse { get; set; }

        [XmlElement(ElementName = "CreateAssetCA")]
        public CreateAssetCA CreateAssetCA { get; set; }

        [XmlElement(ElementName = "UpdateAssetCA")]
        public UpdateAssetCA UpdateAssetCA { get; set; }

        [XmlElement(ElementName = "UpdateAssetCAResponse")]
        public UpdateAssetCAResponse UpdateAssetCAResponse { get; set; }

        [XmlElement(ElementName = "CreateAssetCAResponse")]
        public CreateAssetCAResponse CreateAssetCAResponse { get; set; }

        #endregion

        #region Street

        [XmlElement(ElementName = "GetStreetSuffixes")]
        public GetStreetSuffixes GetStreetSuffixes
        {
            get;
            set;
        }

        [XmlElement(ElementName = "GetStreetSuffixesResponse")]
        public GetStreetSuffixesResponse GetStreetSuffixesResponse
        {
            get;
            set;
        }

        [XmlElement(ElementName = "GetStreetDirections")]
        public GetStreetDirections GetStreetDirections
        {
            get;
            set;
        }

        [XmlElement(ElementName = "GetStreetDirectionsResponse")]
        public GetStreetDirectionsResponse GetStreetDirectionsResponse
        {
            get;
            set;
        }

        #endregion

        #region GetEDMSAdapters
        [XmlElement(ElementName = "GetEDMSAdapters")]
        public GetEDMSAdapters getEDMSAdapters;

        [XmlElement(ElementName = "GetEDMSAdaptersResponse")]
        public GetEDMSAdaptersResponse getEDMSAdaptersResponse;
        #endregion

        //Author:Daniel Shi
        //Date:2011-01-24
        //Desc:Search Enhancement
        #region Address
        [XmlElement(ElementName = "GetAddresses")]
        public GetAddress getAddresses;

        [XmlElement(ElementName = "GetAddressesResponse")]
        public AddressesResponse getAddressesResponse;
        #endregion

        #region getCAPDetail
        [XmlElement(ElementName = "GetCAPDetail")]
        public GetCAPDetail getCAPDetail;

        [XmlElement(ElementName = "GetCAPDetailResponse")]
        public GetCAPDetailResponse getCAPDetailResponse;
        #endregion

        #region GetWorkflow
        [XmlElement(ElementName = "GetWorkflow")]
        public GetWorkflow getWorkflow;

        [XmlElement(ElementName = "GetWorkflowResponse")]
        public GetWorkflowResponse getWorkflowResponse;

        [XmlElement(ElementName = "UpdateWorkflowTask")]
        public UpdateWorkflowTask updateWorkflowTask;

        [XmlElement(ElementName = "UpdateWorkflowTaskResponse")]
        public UpdateWorkflowTaskResponse updateWorkflowTaskResponse;

        #endregion

        #region GetModules

        [XmlElement(ElementName = "GetModules")]
        public GetModules getModules;

        [XmlElement(ElementName = "GetModulesResponse")]
        public GetModulesResponse getModulesResponse;

        #endregion

        #region CountDailyRecords

        [XmlElement(ElementName = "CountDailyRecords")]
        public CountDailyRecords countDailyRecords;

        [XmlElement(ElementName = "CountDailyRecordsResponse")]
        public CountDailyRecordsResponse countDailyRecordsResponse;

        #endregion

        #region GISSettings
        [XmlElement(ElementName = "GISSettings")]
        public GetGISSettings GISSettings;
        #endregion

        #region WorkOrderTemplates

        [XmlElement(ElementName = "GetWorkOrderTemplates")]
        public GetWorkOrderTemplates getWorkOrderTemplates;

        [XmlElement(ElementName = "GetWorkOrderTemplatesResponse")]
        public GetWorkOrderTemplatesResponse getWorkOrderTemplatesResponse;

        #endregion

        #region GetAvailableInspectionDates

        [XmlElement(ElementName = "GetAvailableInspectionDates")]
        public GetAvailableInspectionDates getAvailableInspectionDates;

        [XmlElement(ElementName = "GetAvailableInspectionDatesResponse")]
        public GetAvailableInspectionDatesResponse getAvailableInspectionDatesResponse;

        #endregion
    }
}
