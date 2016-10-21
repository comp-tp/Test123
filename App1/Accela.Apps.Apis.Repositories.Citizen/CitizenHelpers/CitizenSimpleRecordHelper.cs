using System;
using System.Collections.Generic;
using System.Linq;
using Accela.ACA.WSProxy;
using Accela.Apps.Apis.Models.DomainModels.RecordModels;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;
using Accela.Apps.Apis.Repositories.Citizen;

namespace Accela.Apps.Apis.Repositories.CitizenHelpers
{
    public class CitizenSimpleRecordHelper
    {
        public static RecordModel ToEntity4Search(SimpleCapModel citizenModel, bool IncludeAddresses)
        {
            RecordModel result = null;

            if (citizenModel != null)
            {
                result = new RecordModel()
                {
                    Identifier = BuildID4Entity(citizenModel.capID),
                    Display = citizenModel.altID,
                    RecordType = CitizenRecordTypeHelper.ToClientEntity(citizenModel.capType),
                    RecordStatus = !String.IsNullOrWhiteSpace(citizenModel.capStatus) ?
                    new RecordStatusModel()
                    {
                        Identifier = citizenModel.capStatus,
                        Display = citizenModel.capStatus
                    } : null,

                    Name = citizenModel.specialText,
                    AssignDate = citizenModel.capDetailModel != null ? CommonHelper.ToUTCDateTimeString(citizenModel.capDetailModel.asgnDate) : null,
                    ScheduleDate = citizenModel.capDetailModel != null ? CommonHelper.ToUTCDateString(citizenModel.capDetailModel.scheduledDate) : null,
                    ScheduleTime = citizenModel.capDetailModel != null ? citizenModel.capDetailModel.scheduledTime : null,
                    Priority = citizenModel.capDetailModel != null ? citizenModel.capDetailModel.priority : null,
                    OpenDate = CommonHelper.ToUTCDateTimeString(citizenModel.fileDate),
                    Module = citizenModel.moduleName
                    
                };

                if (citizenModel.capDetailModel != null)
                {
                    if (!string.IsNullOrWhiteSpace(citizenModel.capDetailModel.asgnDept))
                    {
                        result.Department = new DepartmentModel();
                        result.Department.Identifier = citizenModel.capDetailModel.asgnDept;
                        result.Department.Display = citizenModel.capDetailModel.asgnDept;
                    }

                    if (!string.IsNullOrWhiteSpace(citizenModel.capDetailModel.asgnStaff))
                    {
                        result.StaffPerson = new StaffPersonModel();
                        result.StaffPerson.Identifier = citizenModel.capDetailModel.asgnStaff;
                        result.StaffPerson.Display = citizenModel.capDetailModel.asgnStaff;
                    }

                    //result.Description = citizenModel.capDetailModel.shortNotes;
                }

                if (IncludeAddresses)
                {
                    result.Addresses = new List<Accela.Apps.Apis.Models.DomainModels.ReferenceModels.AddressModel>();
                    if (citizenModel.addressModels != null )
                    {
                        result.Addresses.AddRange(CitizenAddressHelper.ToEnityAddresses(citizenModel.addressModels.ToList()));
                    }
                    else if(citizenModel.addressModel != null)
                    {
                        result.Addresses.Add(CitizenAddressHelper.ToEnityAddress(citizenModel.addressModel));
                    }
                }

            }

            return result;
        }

        public static List<RecordModel> ToEntities4Search(SimpleCapModel[] citizenSimpleRecords, bool IncludeAddresses)
        {
            List<RecordModel> result = null;

            if (citizenSimpleRecords != null)
            {
                result = citizenSimpleRecords.Where(r => r != null).Select(r => ToEntity4Search(r, IncludeAddresses)).OrderByDescending(item=>item.OpenDate).ToList();
            }

            return result;
        }

        public static string BuildID4Entity(CapIDModel capIdModel)
        {
            string result = null;
            var pattern = "{0}-{1}-{2}";

            if (capIdModel != null)
            {
                result = String.Format(pattern
                    , capIdModel.id1
                    , capIdModel.id2
                    , capIdModel.id3);
            }

            return result;
        }
    }
}
