using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Interfaces;
using TesteBackendEnContact.Core.Interfaces.Services;
using TesteBackendEnContact.Core.Models;

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

        public Task DeleteCompany(Company company)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetAllArtists()
        {
            throw new System.NotImplementedException();
        }

        public Task<Company> GetCompanyById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateCompany(Company companyToBeUpdated, Company company)
        {
            throw new System.NotImplementedException();
        }
    }
}