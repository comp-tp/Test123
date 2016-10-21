using System.Collections.Generic;
using Accela.Apps.Apis.Models.DomainModels.ContactModels;
using Accela.Apps.Apis.Models.DTOs;
using Accela.Apps.Apis.Models.DTOs.Requests.ContactRequests;

namespace Accela.Apps.Apis.Repositories.Interfaces
{
    public interface IContactRepository : IRepository
    {
        /// <summary>
        /// Get contacts.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="fullName">Full name.</param>
        /// <param name="offset">Offset.</param>
        /// <param name="limit">Limit.</param>
        /// <param name="pageInfo">PageInfo.</param>
        /// <returns>ContactModel list.</returns>
        List<ContactModel> GetContacts(string type, string fullName, int offset, int limit, out Pagination pageInfo);

        /// <summary>
        /// Search contacts.
        /// </summary>
        /// <param name="searchContactRequest">SearchContactRequest.</param>
        /// <param name="pageInfo">PageInfo.</param>
        /// <returns>ContactModel list.</returns>
        List<ContactModel> SearchContacts(SearchContactsRequest searchContactRequest, out Pagination pageInfo);
    }
}
