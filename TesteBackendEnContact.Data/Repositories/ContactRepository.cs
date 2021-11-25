using System.Linq;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;

namespace TesteBackendEnContact.Data.Repositories
{
    public class ContactRepository : Repository<Contact>
    {
        public ContactRepository(TesteBackendEnContactContext context) : base(context){}
        private TesteBackendEnContactContext TesteBackendEnContactContext => Context as TesteBackendEnContactContext;
        public Task<Paginator<Contact>> GetAllContactBooksPaginated(int page = 1, int resultsPerPage = 10)
        {
            var results = TesteBackendEnContactContext.Contacts.OrderBy(c => c.Id);
            return Paginator<Contact>.Paginate(results, page, resultsPerPage);

        }
    }
}