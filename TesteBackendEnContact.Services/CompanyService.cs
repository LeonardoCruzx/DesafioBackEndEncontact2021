using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Core;
using TesteBackendEnContact.Core.Interfaces;
using TesteBackendEnContact.Core.Interfaces.Services;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;

namespace TesteBackendEnContact.Services
{
    public class CompanyService: ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Company> CreateCompany(Company newCompany)
        {
            await _unitOfWork.Companies.AddAsync(newCompany);
            await _unitOfWork.CommitAsync();
            return newCompany;
        }

        public async Task<Paginator<Company>> GetAllCompaniesPaginated(int page = 1, int postsPerPage = 10)
        {
            return await this._unitOfWork.Companies.GetAllCompaniesPaginated(page, postsPerPage);
        }
        public async Task<IEnumerable<Company>> GetAllCompanies() => await _unitOfWork.Companies.GetAllAsync();
        public async Task<Company> GetCompanyById(int id) => await _unitOfWork.Companies.GetByIdAsync(id);
        public async Task DeleteCompany(Company company)
        {
            _unitOfWork.Companies.Remove(company);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateCompany(Company companyToBeUpdated, Company company)
        {
            companyToBeUpdated.Name = company.Name;
            companyToBeUpdated.Email = company.Email;
            companyToBeUpdated.Phone = company.Phone;

            await _unitOfWork.CommitAsync();
        }
    }
}