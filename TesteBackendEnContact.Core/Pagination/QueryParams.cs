namespace TesteBackendEnContact.Core.Pagination
{
    public class QueryParams
    {
        private const int _maxPageSize = 50;

        private int _page = 10;

        public int Page { get; set; } = 1;

        public int ItemsPerPage
        {
            get
            {
                return _page;
            }
            set
            {
                if (value > _maxPageSize) _page = _maxPageSize;
                else _page = value;
            }
        }
    }
}