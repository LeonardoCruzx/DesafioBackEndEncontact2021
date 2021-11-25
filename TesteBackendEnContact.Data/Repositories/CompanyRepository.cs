using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteBackendEnContact.Core;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;
using TesteBackendEnContact.Core.Repositories;
using TesteBackendEnContact.Data.Repositories;

namespace TesteBackendEnContact.Data.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(TesteBackendEnContactContext context) : base(context){}
        private TesteBackendEnContactContext TesteBackendEnContactContext => Context as TesteBackendEnContactContext;
        public async Task<Paginator<Company>> GetAllCompaniesPaginated(int page = 1, int resultsPerPage = 10)
        {
            var results = TesteBackendEnContactContext.Companies.OrderBy(c => c.Id);

            return await Paginator<Company>.Paginate(results, page, resultsPerPage);

        }
    }
}