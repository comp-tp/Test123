using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.SummaryModels;
using Accela.Automation.GovXmlClient.Model;
using Accela.Automation.GovXmlServices.Client.Model;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    public class RecordSummaryHelper
    {
        public static ConditionSummaryModel ToConditionSummary(CapConditions xmlObjs)
        {
            ConditionSummaryModel clienObj = null;
            if (xmlObjs != null && xmlObjs.CapCondition != null)
            {
                clienObj = new ConditionSummaryModel();
                foreach (SummaryItem xmlObj in xmlObjs.CapCondition)
                {
                    if (xmlObj.Key != null)
                    {
                        string key = xmlObj.Key.ToLower().Trim();
                        switch (key)
                        {
                            case "notice":
                                clienObj.NoticeCount = int.Parse(xmlObj.Amount);
                                break;
                            case "hold":
                                clienObj.HoldCount = int.Parse(xmlObj.Amount);
                                break;
                            case "lock":
                                clienObj.LockCount = int.Parse(xmlObj.Amount);
                                break;
                        }
                    }
                }
            }

            return clienObj;
        }

        public static InspectionSummaryModel ToInspectionSummarySummary(CapInspections xmlObjs)
        {
            InspectionSummaryModel clienObj = null;
            if (xmlObjs != null)
            {
                clienObj = new InspectionSummaryModel();
                if (xmlObjs.CapInspection != null)
                {
                    foreach (SummaryItem xmlObj in xmlObjs.CapInspection)
                    {
                        if (xmlObj.Key != null)
                        {
                            string key = xmlObj.Key.ToLower().Trim();
                            switch (key)
                            {
                                case "total":
                                    clienObj.Total = int.Parse(xmlObj.Amount);
                                    break;
                                case "passed":
                                    clienObj.PassedCount = int.Parse(xmlObj.Amount);
                                    break;
                                case "failed":
                                    clienObj.FailedCount = int.Parse(xmlObj.Amount);
                                    break;
                                case "scheduled":
                                    clienObj.ScheduledCount = int.Parse(xmlObj.Amount);
                                    break;
                            }
                        }
                    }
                }

                clienObj.CompletedCount = clienObj.PassedCount + clienObj.FailedCount;
                clienObj.NextInspection = xmlObjs.NextInspection;
                clienObj.NextScheduleDate = xmlObjs.NextScheduleDate;
            }

            return clienObj;
        }

        public static FeeSummaryModel ToFeeSummary(CapFees xmlObjs)
        {
            FeeSummaryModel clienObj = null;
            if (xmlObjs != null)
            {
                clienObj = new FeeSummaryModel();
                if (xmlObjs.CapFee != null)
                {

                    foreach (SummaryItem xmlObj in xmlObjs.CapFee)
                    {
                        if (xmlObj.Key != null)
                        {
                            string key = xmlObj.Key.ToLower().Trim();
                            switch (key)
                            {
                                case "total":
                                    clienObj.Total = decimal.Parse(xmlObj.Number);
                                    break;
                                case "paid":
                                    clienObj.Paid = decimal.Parse(xmlObj.Number);
                                    break;
                                case "due":
                                    clienObj.Due = decimal.Parse(xmlObj.Number);
                                    break;
                            }
                        }
                    }
                }

                clienObj.LastPayment = decimal.Parse(xmlObjs.LastPayment);
                clienObj.LastPaymentDate = xmlObjs.LastPaymentTime;
            }

            return clienObj;
        }

        public static WorkflowSummaryModel ToWorkflowSummary(CapWorkflows xmlObjs)
        {
            WorkflowSummaryModel clienObj = null;
            if (xmlObjs != null)
            {
                clienObj = new WorkflowSummaryModel();
                clienObj.CurrentTask = xmlObjs.CurrentTask;
                clienObj.TotalSpendDays = int.Parse(xmlObjs.TotalSpendDays);
                clienObj.CurrentSpendDays = int.Parse(xmlObjs.CurrentSpendDays);
                clienObj.LastComplete = xmlObjs.LastComplete;
            }

            return clienObj;
        }

        public static List<ContactSummaryModel> ToContactSummaries(CapContacts xmlObjs)
        {
            List<ContactSummaryModel> clientObjs = null;
            if (xmlObjs != null && xmlObjs.CapContact != null)
            {
                clientObjs = new List<ContactSummaryModel>();
                foreach (var xmlObj in xmlObjs.CapContact)
                {
                    ContactSummaryModel clientObj = new ContactSummaryModel();
                    clientObj.Identifier = xmlObj.Key;
                    clientObj.Type = xmlObj.Type;
                    clientObj.Address = xmlObj.Address;
                    clientObj.FullName = xmlObj.FullName;
                    clientObj.PhoneNumber = xmlObj.PhoneNumber;
                    clientObj.Email = xmlObj.Email;
                    clientObjs.Add(clientObj);
                }
            }

            return clientObjs;
        }

        public static List<ProjectInformationModel> ToProjectInformations(CapProjectInformations xmlObjs)
        {
            List<ProjectInformationModel> clientObjs = null;

            if (xmlObjs != null && xmlObjs.CapProjectInformation != null)
            {
                clientObjs = new List<ProjectInformationModel>();

                foreach (var xmlObj in xmlObjs.CapProjectInformation)
                {
                    var clientObj = new ProjectInformationModel();
                    clientObj.RecordId = xmlObj.CapId;
                    clientObj.RecordType = xmlObj.CapType;
                    clientObj.ShortComments = xmlObj.ShortComments;
                    clientObjs.Add(clientObj);
                }
            }

            return clientObjs;
        } 
    }
}
