using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ConditionModels;
using Accela.Automation.GovXmlClient.Model;
using Accela.Apps.Apis.Models.DomainModels.ReferenceModels;

namespace Accela.Apps.Apis.Repositories.GovXmlHelpers
{
    internal class ConditionHelper : GovXmlHelperBase 
    {
        public static Conditions ToXMLConditions(List<ConditionModel> clientConditions)
        {
            Conditions retus = null;
            if (clientConditions != null)
            {
                List<Condition> xmlConditions = new List<Condition>();
                foreach (var item in clientConditions)
                {
                    Condition xmlCondition = ConditionHelper.ToXMLCondition(item);
                    if (xmlCondition != null)
                    {
                        xmlConditions.Add(xmlCondition);
                    }
                }

                retus = new Conditions();
                retus.condition = xmlConditions.ToArray();
            }

            return retus;
        }

        public static Condition ToXMLCondition(ConditionModel clientCondition)
        {
            Condition xmlCondition = null;
            if (clientCondition != null)
            {
                xmlCondition = new Condition();
                xmlCondition.keys = KeysHelper.CreateXMLKeys(clientCondition.Identifier);
                xmlCondition.identifierDisplay = clientCondition.Display;
                xmlCondition.description = clientCondition.Description;
                xmlCondition.action = CommonHelper.ToGovXmlAction(clientCondition.Action);

                if (clientCondition.ConditionType != null)
                {
                    xmlCondition.type = new Automation.GovXmlClient.Model.Type();
                    xmlCondition.type.keys = KeysHelper.CreateXMLKeys(clientCondition.ConditionType.Identifier);
                    xmlCondition.type.identifierDisplay = clientCondition.ConditionType.Display;
                }

                xmlCondition.applyDate = clientCondition.ApplyDate;
                xmlCondition.expirationDate = clientCondition.ExpirationDate;
                xmlCondition.effectiveDate = clientCondition.EffectiveDate;
                if (clientCondition.ConditionStatus != null)
                {
                    xmlCondition.status = new Status();
                    xmlCondition.status.keys = KeysHelper.CreateXMLKeys(clientCondition.ConditionStatus.Identifier);
                    xmlCondition.status.IdentifierDisplay = clientCondition.ConditionStatus.Display;
                }

                if (clientCondition.SeverityLevel != null)
                {
                    xmlCondition.severityLevel = new SeverityLevel();
                    xmlCondition.severityLevel.keys = KeysHelper.CreateXMLKeys(clientCondition.SeverityLevel.Identifier);
                    xmlCondition.severityLevel.identifierDisplay = clientCondition.SeverityLevel.Display;
                }

                xmlCondition.DisplayConditionNotice = clientCondition.DisplayConditionNotice;
                xmlCondition.IncludeInConditionName = clientCondition.IncludeInConditionName;
                xmlCondition.IncludeInShortDescription = clientCondition.IncludeInShortDescription;
                xmlCondition.Inheritable = clientCondition.Inheritable;
                xmlCondition.PublicDisplayMessage = clientCondition.PublicDisplayMessage;
                xmlCondition.ResolutionAction = clientCondition.ResolutionAction;
                xmlCondition.ShortComment = clientCondition.ShortComment;
                xmlCondition.LongComment = clientCondition.LongComment;
                xmlCondition.OpenCondition = clientCondition.OpenCondition;

                if (clientCondition.ConditionGroup != null)
                {
                    xmlCondition.conditionGroup = new ConditionGroup();
                    xmlCondition.conditionGroup.keys = KeysHelper.CreateXMLKeys(clientCondition.ConditionGroup.Identifier);
                    xmlCondition.conditionGroup.identifierDisplay = clientCondition.ConditionGroup.Display;
                }

                xmlCondition.ConditionName = clientCondition.ConditionName;
                xmlCondition.ReadOnly = clientCondition.ReadOnly;
            }

            return xmlCondition;
        }

        public static ConditionModel ToClientCondition(Condition xmlCondition)
        {
            ConditionModel clientCondition = null;
            if (xmlCondition != null)
            {
                clientCondition = new ConditionModel();
                clientCondition.Identifier = KeysHelper.ToStringKeys(xmlCondition.keys);
                clientCondition.Display = xmlCondition.identifierDisplay;
                clientCondition.Description = xmlCondition.description;
                if (xmlCondition.type != null)
                {
                    clientCondition.ConditionType=new ConditionTypeModel();
                    clientCondition.ConditionType.Identifier = KeysHelper.ToStringKeys(xmlCondition.type.keys);
                    clientCondition.ConditionType.Display = xmlCondition.type.identifierDisplay;
                }

                clientCondition.ApplyDate = xmlCondition.applyDate;
                clientCondition.ExpirationDate = xmlCondition.expirationDate;
                clientCondition.EffectiveDate = xmlCondition.effectiveDate;
                if (xmlCondition.status != null)
                {
                    clientCondition.ConditionStatus = new ConditionStatusModel();
                    clientCondition.ConditionStatus.Identifier = KeysHelper.ToStringKeys(xmlCondition.status.keys);
                    clientCondition.ConditionStatus.Display = xmlCondition.status.IdentifierDisplay;
                }

                if (xmlCondition.severityLevel != null)
                {
                    clientCondition.SeverityLevel = new SeverityModel();
                    clientCondition.SeverityLevel.Identifier = KeysHelper.ToStringKeys(xmlCondition.severityLevel.keys);
                    clientCondition.SeverityLevel.Display = xmlCondition.severityLevel.identifierDisplay;
                }

                clientCondition.DisplayConditionNotice = xmlCondition.DisplayConditionNotice;
                clientCondition.IncludeInConditionName = xmlCondition.IncludeInConditionName;
                clientCondition.IncludeInShortDescription = xmlCondition.IncludeInShortDescription;
                clientCondition.Inheritable = xmlCondition.Inheritable;
                clientCondition.PublicDisplayMessage = xmlCondition.PublicDisplayMessage;
                clientCondition.ResolutionAction = xmlCondition.ResolutionAction;
                clientCondition.ShortComment = xmlCondition.ShortComment;
                clientCondition.LongComment = xmlCondition.LongComment;
                clientCondition.OpenCondition = xmlCondition.OpenCondition;

                if (xmlCondition.conditionGroup != null)
                {
                    clientCondition.ConditionGroup = new ConditionGroupModel();
                    clientCondition.ConditionGroup.Identifier = KeysHelper.ToStringKeys(xmlCondition.conditionGroup.keys);
                    clientCondition.ConditionGroup.Display = xmlCondition.conditionGroup.identifierDisplay;
                }

                clientCondition.ConditionName = xmlCondition.ConditionName;
                clientCondition.ReadOnly = xmlCondition.ReadOnly;
            }

            return clientCondition;
        }
    }
}
