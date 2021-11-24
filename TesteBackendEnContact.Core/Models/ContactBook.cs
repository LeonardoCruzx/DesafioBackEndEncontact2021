using System.Collections.Generic;

namespace TesteBackendEnContact.Core.Models
{
    public class ContactBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
