using System.Collections.Generic;

namespace TesteBackendEnContact.Core.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public ICollection<ContactBook> ContactBooks { get; set;}
    }
}
