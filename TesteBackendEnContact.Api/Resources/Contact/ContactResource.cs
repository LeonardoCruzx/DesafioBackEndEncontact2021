namespace TesteBackendEnContact.Api.Resources.Contact
{
    public class ContactResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int ContactBookId { get; set; }
        public ContactBookResource ContactBook { get; set; }
        public int CompanyID { get; set; }
        public CompanyResource Company { get; set; }
    }
}