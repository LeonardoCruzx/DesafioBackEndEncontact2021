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

        public async Task<ContactBook> CreateContactBook(ContactBook contactBook)
        {
            await _unitOfWork.ContactBooks.AddAsync(contactBook);
            await _unitOfWork.CommitAsync();
            return contactBook;
        }
        public async Task<Paginator<ContactBook>> GetAllContactBooksPaginated(int page = 1, int postsPerPage = 10)
        {
            return await this._unitOfWork.ContactBooks.GetAllContactBooksPaginated(page, postsPerPage);
        }
        public Task<IEnumerable<ContactBook>> GetAllContactBooks()
        {
            throw new System.NotImplementedException();
        }
        public async Task<ContactBook> GetContactBookById(int id) => await _unitOfWork.ContactBooks.GetByIdAsync(id);
        public async Task DeleteContactBook(ContactBook contactBook)
        {
            _unitOfWork.ContactBooks.Remove(contactBook);
            await _unitOfWork.CommitAsync();
        }
        public async Task UpdateContactBook(ContactBook contactBookToBeUpdated, ContactBook contactBook)
        {
            ///TODO: Implement update
            await _unitOfWork.CommitAsync();
        }
    }
}