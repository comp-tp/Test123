using System;
using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.Portals;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IAutomationAccountRepository
    {
        void Save(AutomationAccountModel autoAccountModel);

        void Unlink(Guid atuoId);

        AutomationAccountModel GetAutomationAccount(Guid Id);

        IList<AutomationAccountModel> GetACALinkedAccounts(Guid cloudUserId);

        IList<AutomationAccountModel> GetAALinkedAccounts(Guid cloudUserId);
    }
}
