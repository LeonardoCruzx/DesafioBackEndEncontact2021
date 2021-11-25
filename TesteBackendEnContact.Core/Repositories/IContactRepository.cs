using System.Threading.Tasks;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;

namespace TesteBackendEnContact.Core.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        Task<Paginator<Contact>> GetAllContactPaginated(int page = 1, int postsPerPage = 10);
    }
}