using System;
using System.Collections.Generic;
using System.Linq;
using TesteBackendEnContact.Core.Models;

namespace TesteBackendEnContact.Core.Pagination
{
    public class Paginator<T> where T : class
    {
        public MetaData Metadata { get; set; }
        public IEnumerable<T> Posts { get; set; }
        public Paginator(IEnumerable<T> items, int count, int pageNumber, int postsPerPage)
        {
            Metadata = new MetaData
            {
                CurrentPage = pageNumber,
                PostsPerPage = postsPerPage,
                TotalPages = (int)Math.Ceiling(count / (double)postsPerPage),
                TotalPosts = count
            };
            this.Posts = items;
        }
        public static Paginator<T> ToPaginatedCompany(IQueryable<T> posts, int pageNumber, int postsPerPage)
        {
            var count = posts.Count();
            var chunk = posts.Skip((pageNumber - 1) * postsPerPage).Take(postsPerPage);
            return new Paginator<T>(chunk, count, pageNumber, postsPerPage);
        }
    }
}