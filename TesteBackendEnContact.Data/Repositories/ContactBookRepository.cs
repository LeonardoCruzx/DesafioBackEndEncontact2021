using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;
using TesteBackendEnContact.Core.Repositories;

namespace TesteBackendEnContact.Data.Repositories
{
    public class ContactBookRepository: Repository<ContactBook>, IContactBookRepository
    {
        public ContactBookRepository(TesteBackendEnContactContext context) : base(context){}
        private TesteBackendEnContactContext TesteBackendEnContactContext => Context as TesteBackendEnContactContext;
        public Task<Paginator<ContactBook>> GetAllContactBooksPaginated(int page = 1, int resultsPerPage = 10)
        {
            var results = TesteBackendEnContactContext.ContactBooks.OrderBy(c => c.Id);
            return Paginator<ContactBook>.Paginate(results, page, resultsPerPage);

        }

        public async Task<ContactBook> GetContactBookByIdWithContacts(int id) =>
            await TesteBackendEnContactContext.ContactBooks
                .Where(c => c.Id == id)
                .Include(c => c.Contacts)
                .FirstOrDefaultAsync();
    }
}