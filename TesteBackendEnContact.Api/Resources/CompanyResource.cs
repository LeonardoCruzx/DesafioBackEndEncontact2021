using TesteBackendEnContact.Core.Models;

namespace TesteBackendEnContact.Api.Resources
{
    public class CompanyResource
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

        /*
        public Company ToCompany() => new Company()
        {
            Id = Id,
            Name = Name,
            Cnpj = Cnpj,
            Email = Email,
            Phone = Phone,
            Address = Address
        };
        */
    }
}