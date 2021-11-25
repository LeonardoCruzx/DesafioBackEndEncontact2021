using System.Threading.Tasks;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;

namespace TesteBackendEnContact.Core.Repositories
{
    public interface IContactBookRepository : IRepository<ContactBook>
    {
        Task<Paginator<ContactBook>> GetAllContactBooksPaginated(int page = 1, int postsPerPage = 10);
    }
}