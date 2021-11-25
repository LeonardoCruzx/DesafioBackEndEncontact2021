using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Filters;
using TesteBackendEnContact.Core.Interfaces;
using TesteBackendEnContact.Core.Interfaces.Services;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;

namespace TesteBackendEnContact.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Contact> CreateContact(Contact newContact)
        {
            await _unitOfWork.Contacts.AddAsync(newContact);
            await _unitOfWork.CommitAsync();
            return newContact;
        }
        public async Task<Paginator<Contact>> GetAllContactPaginatedWithContactBookAndCompany(ContactFilter filter, int page, int itemsPerPage) => await _unitOfWork.Contacts.GetAllContactPaginatedWithContactBookAndCompany(filter, page, itemsPerPage);
        public Task<Paginator<Contact>> GetAllContactsPaginated(int page = 1, int postsPerPage = 10)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contact> GetContactById(int id) => await _unitOfWork.Contacts.GetByIdAsync(id);
        public async Task DeleteContact(Contact company)
        {
            _unitOfWork.Contacts.Remove(company);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateContact(Contact companyToBeUpdated, Contact company)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<Contact>> IContactService.GetAllContacts()
        {
            throw new System.NotImplementedException();
        }
    }
}