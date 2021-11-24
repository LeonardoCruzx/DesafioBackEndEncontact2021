using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;

namespace TesteBackendEnContact.Core.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Paginator<Company>> GetAllCompaniesPaginated(int page = 1, int postsPerPage = 10);
    }
}