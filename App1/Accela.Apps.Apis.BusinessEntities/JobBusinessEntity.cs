using System;
using System.Collections.Generic;
using Accela.Apps.Apis.BusinessEntities.Interfaces;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DTOs.Requests.CommonRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.InspectionRequests;
using Accela.Apps.Apis.Models.DTOs.Requests.RecordRequests;
using Accela.Apps.Apis.Models.DTOs.Responses.InspectionResponses;
using Accela.Apps.Apis.Models.DTOs.Responses.RecordResponses;
using Accela.Apps.Apis.Repositories.Interfaces;
using Accela.Apps.Shared;
using Accela.Apps.Shared.Exceptions;
using Accela.Apps.Apis.Resources;

namespace Accela.Apps.Apis.BusinessEntities
{
    /// <summary>
    /// Job list business entity class.
    /// </summary>
    public class JobBusinessEntity : BusinessEntityBase, IJobBusinessEntity
    {
        
        public JobBusinessEntity(IInspectionRepository inspectionRepository, IRecordBusinessEntity recordBusinessEntity)
        {
            InspectionRepository = inspectionRepository;
            RecordBusinessEntity = recordBusinessEntity;
        }

        private readonly IInspectionRepository InspectionRepository;
        

        private readonly IRecordBusinessEntity RecordBusinessEntity;

        /// <summary>
        /// Gets user's Inspections Job List.
        /// </summary>
        /// <param name="cloudUser">CloudUser</param>
        /// <param name="pageIndex">Page start index. Used for paging.</param>
        /// <param name="pageSize">Number of items to return in paged collection.</param>
        /// <returns></returns>
        public JoblistResponse GetJobList(JoblistRequest request)
        {
            return InspectionRepository.GetJobs(request);
        }

        /// <summary>
        /// Clear specified user's cache so that client is able to get latest data from next access.
        /// </summary>
        /// <param name="refreshRequest">Refresh request model.</param>
        public void RefreshData(RefreshRequest refreshRequest)
        {
            InspectionRepository.RefreshData(refreshRequest);
        }

        /// <summary>
        /// Updates the inspection.
        /// </summary>
        /// <param name="inspectionRequest">InspectionRequest parameter.</param>
        /// <returns>Inspection response.</returns>
        public InspectionResponse UpdateJob(InspectionRequest inspectionRequest)
        {
            var requestContainsInspectionModel = inspectionRequest != null && inspectionRequest.InspectionModel != null;
            var requestContainsAsi = requestContainsInspectionModel && inspectionRequest.InspectionModel.Additionals != null && inspectionRequest.InspectionModel.Additionals.Count > 0;
            var requestContainsAsit = requestContainsInspectionModel && inspectionRequest.InspectionModel.AdditionalTables != null && inspectionRequest.InspectionModel.AdditionalTables.Count > 0;
            var requestContainsRecordId = requestContainsInspectionModel && inspectionRequest.InspectionModel.Record != null && !String.IsNullOrWhiteSpace(inspectionRequest.InspectionModel.Record.Identifier);

            if ((requestContainsAsi || requestContainsAsit) && !requestContainsRecordId)
            {
                throw new MobileException(MobileResources.GetString("record_id_required"));
            }

            InspectionResponse retu = InspectionRepository.UpdateJob(inspectionRequest);
            if ((requestContainsAsi || requestContainsAsit) && requestContainsRecordId)
            {
                //update asi and asit
                //1. Get record with basic data
                RecordRequest recordRequest = new RecordRequest();
                recordRequest.RecordId = inspectionRequest.InspectionModel.Record.Identifier;
                RecordResponse recordResponse = RecordBusinessEntity.GetRecord(recordRequest);
                RecordModel recordModel = recordResponse.Record;

                recordModel.AdditionalInfo = inspectionRequest.InspectionModel.Additionals;
                recordModel.AdditionalTableInfo = inspectionRequest.InspectionModel.AdditionalTables;

                UpdateRecordRequest updateRecordRequest = new UpdateRecordRequest();
                updateRecordRequest.Record = recordModel;
                RecordBusinessEntity.UpdateRecord(updateRecordRequest);
            }

            return retu;
        }

        /// <summary>
        /// Gets the inspetion comments.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="inspectionId">The inspection id.</param>
        /// <returns>
        /// the inspetion comments.
        /// </returns>
        public InspectionCommentResponse GetInspetionComments(InspectionCommentRequest request)
        {
            return InspectionRepository.GetInspetionComments(request);
        }

        /// <summary>
        /// Gets the checklists.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="inspectionId">The inspection id.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// the checklists.
        /// </returns>
        public InspectionChecklistResponse GetChecklists(InspectionChecklistRequest request)
        {
            return InspectionRepository.GetChecklists(request);
        }

        /// <summary>
        /// Gets the checklist items.
        /// </summary>
        /// <param name="cloudUser">The cloud user.</param>
        /// <param name="inspectionId">The inspection id.</param>
        /// <param name="checklistId">The checklist id.</param>
        /// <param name="pageIndex">The page index.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// the checklist items.
        /// </returns>
        public InspectionChecklistItemResponse GetChecklistItems(InspectionChecklistItemRequest request)
        {
            return InspectionRepository.GetChecklistItems(request);
        }
    }

}
