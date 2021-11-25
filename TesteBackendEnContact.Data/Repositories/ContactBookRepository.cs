using System.Linq;
using System.Threading.Tasks;
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
    }
}