using System.Collections.Generic;
using TesteBackendEnContact.Core.Models;

namespace TesteBackendEnContact.Api.Resources
{
    public class ContactBookResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}