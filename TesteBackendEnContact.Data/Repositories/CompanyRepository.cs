using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Repositories;
using TesteBackendEnContact.Data.Repositories;

namespace TesteBackendEnContact.Data
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(TesteBackendEnContactContext context) : base(context)
        {
        }
    }
}