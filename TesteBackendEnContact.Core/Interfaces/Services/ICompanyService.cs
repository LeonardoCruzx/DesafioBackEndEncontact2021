using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Models;

namespace TesteBackendEnContact.Core.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetCompanyById(int id);
        Task<Company> CreateCompany(Company newCompany);
        Task UpdateCompany(Company companyToBeUpdated, Company company);
        Task DeleteCompany(Company company);
    }
}