using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;

namespace TesteBackendEnContact.Core.Interfaces.Services
{
    public interface IContactService
    {
        Task<Paginator<Contact>> GetAllContactsPaginated(int page = 1, int postsPerPage = 10);
        Task<Paginator<Contact>> GetAllContactsPaginatedWithContactBook(int page = 1, int postsPerPage = 10);
        Task<IEnumerable<Contact>> GetAllContacts();
        Task<Contact> GetContactById(int id);
        Task<Contact> CreateContact(Contact newCompany);
        Task UpdateContact(Contact companyToBeUpdated, Contact company);
        Task DeleteContact(Contact company);
    }
}