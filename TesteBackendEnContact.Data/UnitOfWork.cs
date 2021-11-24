using System.Threading.Tasks;
using TesteBackendEnContact.Core.Interfaces;
using TesteBackendEnContact.Core.Repositories;
using TesteBackendEnContact.Data.Repositories;

namespace TesteBackendEnContact.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TesteBackendEnContactContext _context;
        private CompanyRepository _companyRepository;
        private ContactBookRepository _contactBookRepository;
        public UnitOfWork(TesteBackendEnContactContext context)
        {
            _context = context;
        }
        public ICompanyRepository Companies => _companyRepository = _companyRepository ?? new CompanyRepository(_context);
        public IContactBookRepository ContactBooks => _contactBookRepository = _contactBookRepository ?? new ContactBookRepository(_context);
        public async Task<int> CommitAsync() => await this._context.SaveChangesAsync();
        
        public void Dispose() => this._context.Dispose();
    }
}