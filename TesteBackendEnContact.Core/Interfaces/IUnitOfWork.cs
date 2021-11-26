using System;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Repositories;

namespace TesteBackendEnContact.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Companies { get; }
        IContactBookRepository ContactBooks { get; }
        IContactRepository Contacts { get; }
        Task<int> CommitAsync();
    }
}