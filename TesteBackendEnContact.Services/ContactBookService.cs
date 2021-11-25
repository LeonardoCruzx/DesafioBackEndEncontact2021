using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Interfaces;
using TesteBackendEnContact.Core.Interfaces.Services;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;

namespace TesteBackendEnContact.Services
{
    public class ContactBookService: IContactBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ContactBook> CreateContactBook(ContactBook newCompany)
        {
            await _unitOfWork.ContactBooks.AddAsync(newCompany);
            await _unitOfWork.CommitAsync();
            return newCompany;
        }
        public async Task<Paginator<ContactBook>> GetAllContactBooksPaginated(int page = 1, int postsPerPage = 10)
        {
            return await this._unitOfWork.ContactBooks.GetAllContactBooksPaginated(page, postsPerPage);
        }
        public Task DeleteContactBook(ContactBook company)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ContactBook>> GetAllContactBooks()
        {
            throw new System.NotImplementedException();
        }

        public Task<ContactBook> GetContactBookById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateContactBook(ContactBook companyToBeUpdated, ContactBook company)
        {
            throw new System.NotImplementedException();
        }
    }
}