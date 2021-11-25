using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFilterer.Extensions;
using Microsoft.EntityFrameworkCore;
using TesteBackendEnContact.Core.Filters;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;
using TesteBackendEnContact.Core.Repositories;

namespace TesteBackendEnContact.Data.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(TesteBackendEnContactContext context) : base(context){}
        private TesteBackendEnContactContext TesteBackendEnContactContext => Context as TesteBackendEnContactContext;

        public async Task<Paginator<Contact>> GetAllContactPaginated(int page = 1, int resultsPerPage = 10)
        {
            var results = TesteBackendEnContactContext.Contacts.OrderBy(c => c.Id);
            return await Paginator<Contact>.Paginate(results, page, resultsPerPage);
        }
        public async Task<Paginator<Contact>> GetAllContactPaginatedWithContactBook(ContactFilter filter = null, int page = 1, int resultsPerPage = 10)
        {
            var results = TesteBackendEnContactContext.Contacts.ApplyFilter(filter);

            
            return await Paginator<Contact>.Paginate(results, page, resultsPerPage);
            //return await results.ToListAsync();
        }
    }
}