using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Accela.Apps.Apis.Models.DomainModels.ConditionModels;
using Accela.Apps.Shared.Utils;
using Accela.Apps.Apis.Models.Common;

namespace Accela.Apps.Apis.WSModels.RecordConditions4V3p
{
    [DataContract(Name = "condition")]
    public class WSCondition4V3p : WSDataModel
    {
        [DataMember(Name = "displayOrder", EmitDefaultValue = false)]
        public int DisplayOrder { get; set; }

        [DataMember(Name = "conditionOfApproval", EmitDefaultValue = false)]
        public string ConditionOfApproval { get; set; }

        [DataMember(Name = "additionalInformation", EmitDefaultValue = false)]
        public string AdditionalInformation { get; set; }

        [DataMember(Name = "resolutionAction", EmitDefaultValue = false)]
        public string ResolutionAction { get; set; }

        [DataMember(Name = "statusDate", EmitDefaultValue = false)]
        public string StatusDate { get; set; }

        [DataMember(Name = "publicDisplayMessage", EmitDefaultValue = false)]
        public string PublicDisplayMessage { get; set; }

        [DataMember(Name = "serviceProviderCode", EmitDefaultValue = false)]
        public string ServiceProviderCode { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public WSId4V3p Type { get; set; }

        [DataMember(Name = "group", EmitDefaultValue = false)]
        public WSId4V3p Group { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false)]
        public WSId4V3p Status { get; set; }

        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public WSId4V3p Priority { get; set; }

        [DataMember(Name = "severity", EmitDefaultValue = false)]
        public WSId4V3p Severity { get; set; }

        [DataMember(Name = "appliedbyDepartment", EmitDefaultValue = false)]
        public WSId4V3p AppliedbyDepartment { get; set; }

        [DataMember(Name = "actionbyDepartment", EmitDefaultValue = false)]
        public WSId4V3p ActionbyDepartment { get; set; }

        [DataMember(Name = "actionbyUser", EmitDefaultValue = false)]
        public WSId4V3p ActionbyUser { get; set; }

        [DataMember(Name = "appliedbyUser", EmitDefaultValue = false)]
        public WSId4V3p AppliedbyUser { get; set; }

        [DataMember(Name = "inheritable", EmitDefaultValue = false)]
        public WSId4V3p Inheritable { get; set; }

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "shortComments", EmitDefaultValue = false)]
        public string ShortComments { get; set; }

        [DataMember(Name = "effectiveDate", EmitDefaultValue = false)]
        public string EffectiveDate { get; set; }

        [DataMember(Name = "appliedDate", EmitDefaultValue = false)]
        public string AppliedDate { get; set; }

        [DataMember(Name = "expirationDate", EmitDefaultValue = false)]
        public string ExpirationDate { get; set; }

        [DataMember(Name = "longComments", EmitDefaultValue = false)]
        public string LongComments { get; set; }

        [DataMember(Name = "statusType", EmitDefaultValue = false)]
        public string StatusType { get; set; }

        [DataMember(Name = "displayNoticeInAgency", EmitDefaultValue = false)]
        public bool DisplayNoticeInAgency { get; set; }

        [DataMember(Name = "isIncludeNameInNotice", EmitDefaultValue = false)]
        public bool IsIncludeNameInNotice { get; set; }

        [DataMember(Name = "isIncludeShortCommentsInNotice", EmitDefaultValue = false)]
        public bool IsIncludeShortCommentsInNotice { get; set; }

        [DataMember(Name = "displayNoticeInCitizens", EmitDefaultValue = false)]
        public bool DisplayNoticeInCitizens { get; set; }

        [DataMember(Name = "displayNoticeInCitizensFee", EmitDefaultValue = false)]
        public bool DisplayNoticeInCitizensFee { get; set; }

        [DataMember(Name = "recordId", EmitDefaultValue = false)]
        public WSRecordId4V3p RecordId { get; set; }

        [DataMember(Name = "activeStatus", EmitDefaultValue = false)]
        public string ActiveStatus { get; set; }

        /// <summary>
        /// Froms the entity models.
        /// </summary>
        /// <param name="entityModels">The entity models.</param>
        /// <returns>the entity models.</returns>
        public static WSCondition4V3p[] FromEntityModels(ConditionModel[] entityModels)
        {
            if (entityModels == null)
            {
                return null;
            }

            var result = entityModels.Select(m => FromEntityModel(m)).ToArray();
            return result;
        }

        /// <summary>
        /// Froms the entity model.
        /// </summary>
        /// <param name="entityModel">The entity model.</param>
        /// <returns>the entity model.</returns>
        public static WSCondition4V3p FromEntityModel(ConditionModel entityModel)
        {
            if (entityModel == null)
            {
                return null;
            }

            var result = new WSCondition4V3p()
            {
                //DisplayOrder = ,
                //ConditionOfApproval = entityModel.ConditionOfApproval,
                //AdditionalInformation = entityModel.
                ResolutionAction = entityModel.ResolutionAction,
                //StatusDate = entityModel
                PublicDisplayMessage = entityModel.PublicDisplayMessage,
                //ServiceProviderCode = entityModel.
                Type = entityModel.ConditionType != null ? new WSId4V3p()
                {
                    Text = entityModel.ConditionType.Display,
                    Value = decodeIdentifier(entityModel.ConditionType.Identifier)
                } : null,
                Group = entityModel.ConditionGroup != null ? new WSId4V3p()
                {
                    Text = entityModel.ConditionGroup.Display,
                    Value = decodeIdentifier(entityModel.ConditionGroup.Identifier)
                } : null,
                Status = entityModel.ConditionStatus != null ? new WSId4V3p()
                {
                    Text = entityModel.ConditionStatus.Display,
                    Value = decodeIdentifier(entityModel.ConditionStatus.Identifier)
                } : null,
                //Priority = new WSId4V3p()
                //{
                //    Text = entityModel..Display,
                //    Value = entityModel..Identifier
                //},
                Severity = entityModel.SeverityLevel != null ? new WSId4V3p()
                {
                    Text = entityModel.SeverityLevel.Display,
                    Value = decodeIdentifier(entityModel.SeverityLevel.Identifier)
                } : null,
                //AppliedbyDepartment = new WSId4V3p()
                //{
                //    Text = entityModel..Display,
                //    Value = entityModel..Identifier
                //},
                //ActionbyDepartment = new WSId4V3p()
                //{
                //    Text = entityModel..Display,
                //    Value = entityModel..Identifier
                //},
                //ActionbyUser = new WSId4V3p()
                //{
                //    Text = entityModel..Display,
                //    Value = entityModel..Identifier
                //},
                //AppliedbyUser = new WSId4V3p()
                //{
                //    Text = entityModel..Display,
                //    Value = entityModel..Identifier
                //},
                Inheritable = !String.IsNullOrWhiteSpace(entityModel.Inheritable) ? new WSId4V3p()
                {
                    Text = BoolHelper.IsTrueString(entityModel.Inheritable).ToString(),
                    Value = entityModel.Inheritable
                } : null,
                Id = GetId(entityModel.Identifier),
                Name = entityModel.ConditionName,
                ShortComments = entityModel.ShortComment,
                EffectiveDate = entityModel.EffectiveDate,
                AppliedDate = entityModel.ApplyDate,
                ExpirationDate = entityModel.ExpirationDate,
                LongComments = entityModel.LongComment,
                StatusType = entityModel.ConditionStatus != null ? entityModel.ConditionStatus.Type : null,
                DisplayNoticeInAgency = BoolHelper.IsTrueString(entityModel.DisplayConditionNotice),
                IsIncludeNameInNotice = BoolHelper.IsTrueString(entityModel.IncludeInConditionName),
                IsIncludeShortCommentsInNotice = BoolHelper.IsTrueString(entityModel.IncludeInShortDescription),
                DisplayNoticeInCitizens = BoolHelper.IsTrueString(entityModel.DisplayConditionNotice),
                //DisplayNoticeInCitizensFee = BoolHelper.IsTrueString(entityModel.),
                //RecordId = entityModel.
                //ActiveStatus = entityModel.ConditionStatus.Type
            };

            return result;
        }

        private static int GetId(string identifier)
        {
            var result = 0;

            if (!String.IsNullOrWhiteSpace(identifier))
            {
                var elements = identifier.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                var idString = elements != null && elements.Length > 0 ? elements[elements.Length - 1] : "";

                int tempId;
                if (!String.IsNullOrWhiteSpace(idString))
                {
                    if (int.TryParse(idString.Trim(), out tempId))
                    {
                        result = tempId;
                    }
                }
            }

            return result;
        }

        private static string decodeIdentifier(string identifier)
        {
            var result = identifier;

            if (!String.IsNullOrWhiteSpace(result))
            {
                string[] strKeys = Regex.Split(result, "-");

                for (int i = 0; i < strKeys.Length; i++)
                {
                    strKeys[i] = IdEscapeHelper.DecodeString(strKeys[i]);
                }
                result = String.Join("-", strKeys);
            }

            return result;
        }
    }
}
