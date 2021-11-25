namespace TesteBackendEnContact.Api.Resources.Contact
{
    public class SaveContactResource
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int ContactBookId { get; set; }
        public int CompanyId { get; set; }
    }
}