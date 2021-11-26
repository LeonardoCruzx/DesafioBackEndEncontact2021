namespace TesteBackendEnContact.Core.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int ContactBookId { get; set; }
        public ContactBook ContactBook { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}