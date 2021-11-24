using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Repositories;

namespace TesteBackendEnContact.Data.Repositories
{
    public class ContactBookRepository: Repository<ContactBook>, IContactBookRepository
    {
        public ContactBookRepository(TesteBackendEnContactContext context) : base(context)
        {
            
        }
    }
}