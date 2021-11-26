using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Filters;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;

namespace TesteBackendEnContact.Core.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Paginator<Company>> GetAllCompaniesPaginated(int page = 1, int postsPerPage = 10);
        Task<Company> GetCompanyById(int id);
        Task<Paginator<Contact>> GetContactsFromContactBookOfCompanyWithId(int companyId, int contactBookId, ContactFilter filter, int page = 1, int postsPerPage = 10);
        Task<Company> CreateCompany(Company newCompany);
        Task UpdateCompany(Company companyToBeUpdated, Company company);
        Task DeleteCompany(Company company);
    }
}