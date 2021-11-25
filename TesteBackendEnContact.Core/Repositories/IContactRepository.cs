using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Filters;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;

namespace TesteBackendEnContact.Core.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<Paginator<Contact>> GetAllContactPaginated(int page = 1, int resultsPerPage = 10);
        Task<Paginator<Contact>> GetAllContactPaginatedWithContactBook(ContactFilter filter = null, int page = 1, int resultsPerPage = 10);
    }
}