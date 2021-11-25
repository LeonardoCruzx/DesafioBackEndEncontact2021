using System.Collections.Generic;
using System.Threading.Tasks;
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
        public Task<Contact> CreateContact(Contact newCompany)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteContact(Contact company)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetAllContacts()
        {
            throw new System.NotImplementedException();
        }

        public Task<Paginator<Contact>> GetAllContactsPaginated(int page = 1, int postsPerPage = 10)
        {
            throw new System.NotImplementedException();
        }

        public Task<Contact> GetContactById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateContact(Contact companyToBeUpdated, Contact company)
        {
            throw new System.NotImplementedException();
        }
    }
}