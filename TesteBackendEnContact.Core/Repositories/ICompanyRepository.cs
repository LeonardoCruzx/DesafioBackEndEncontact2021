using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Filters;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;

namespace TesteBackendEnContact.Core.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<Paginator<Company>> GetAllCompaniesPaginated(int page = 1, int resultsPerPage = 10);
    }
}