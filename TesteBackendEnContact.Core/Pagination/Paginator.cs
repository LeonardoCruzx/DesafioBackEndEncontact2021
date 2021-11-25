using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendEnContact.Core.Models;

using Microsoft.EntityFrameworkCore;

namespace TesteBackendEnContact.Core.Pagination
{
    public class Paginator<T> where T : class
    {
        public MetaData Metadata { get; set; }
        public IEnumerable<T> Data { get; set; }
        public Paginator(IEnumerable<T> items, int count, int pageNumber, int itemsPerPage)
        {
            Metadata = new MetaData
            {
                CurrentPage = pageNumber,
                ItemsPerPage = itemsPerPage,
                TotalPages = (int)Math.Ceiling(count / (double)itemsPerPage),
                TotalItems = count
            };
            this.Data = items;
        }
        public Paginator(IEnumerable<T> items, MetaData metadata)
        {
            this.Data = items;
            this.Metadata = metadata;
        }
        public static async Task<Paginator<T>> Paginate(IQueryable<T> items, int pageNumber, int itemsPerPage)
        {
            var count = items.Count();
            var chunk = items.Skip((pageNumber - 1) * itemsPerPage).Take(itemsPerPage);
            
            var selectedItems = await chunk.ToListAsync();
            
            return new Paginator<T>(selectedItems, count, pageNumber, itemsPerPage);
        }
    }
}