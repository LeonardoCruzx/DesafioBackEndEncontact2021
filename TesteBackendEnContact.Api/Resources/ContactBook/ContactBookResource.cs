using System.Collections.Generic;
using TesteBackendEnContact.Core.Models;

namespace TesteBackendEnContact.Api.Resources.ContactBook
{
    public class ContactBookResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? CompanyId { get; set; }
    }
}