using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;

namespace TesteBackendEnContact.Core.Interfaces.Services
{
    public interface IContactBookService
    {
        Task<Paginator<ContactBook>> GetAllContactBooksPaginated(int page = 1, int postsPerPage = 10);
        Task<IEnumerable<ContactBook>> GetAllContactBooks();
        Task<ContactBook> GetContactBookById(int id);
        Task<ContactBook> GetContactBookByIdWithContacts(int id);
        Task<ContactBook> CreateContactBook(ContactBook newContactBook);
        Task UpdateContactBook(ContactBook contactBookToBeUpdated, ContactBook contactBook);
        Task DeleteContactBook(ContactBook contactBook);
    }
}