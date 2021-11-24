namespace TesteBackendEnContact.Core.Pagination
{
    public class MetaData
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PostsPerPage { get; set; }
        public int TotalPosts { get; set; }
    }
}