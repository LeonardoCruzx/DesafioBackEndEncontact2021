using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Models;

namespace TesteBackendEnContact.Core.Interfaces.Services
{
    public interface IContactBookService
    {
        Task<IEnumerable<ContactBook>> GetAllContactBooks();
        Task<ContactBook> GetContactBookById(int id);
        Task<ContactBook> CreateContactBook(ContactBook newCompany);
        Task UpdateContactBook(ContactBook companyToBeUpdated, ContactBook company);
        Task DeleteContactBook(ContactBook company);
    }
}