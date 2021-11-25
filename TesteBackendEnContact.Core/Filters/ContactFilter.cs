using AutoFilterer.Types;

namespace TesteBackendEnContact.Core.Filters
{
    public class ContactFilter : FilterBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? ContactBookId { get; set; }
        public int? CompanyID { get; set; }
    }
}