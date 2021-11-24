using System.Threading.Tasks;
using TesteBackendEnContact.Core.Interfaces;
using TesteBackendEnContact.Core.Repositories;

namespace TesteBackendEnContact.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TesteBackendEnContactContext _context;
        private CompanyRepository _companyRepository;
        public UnitOfWork(TesteBackendEnContactContext context)
        {
            _context = context;
        }
        public ICompanyRepository Companies => _companyRepository = _companyRepository ?? new CompanyRepository(_context);
        public async Task<int> CommitAsync() => await this._context.SaveChangesAsync();
        
        public void Dispose() => this._context.Dispose();
    }
}