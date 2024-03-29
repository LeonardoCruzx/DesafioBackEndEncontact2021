﻿using System.Collections.Generic;

namespace TesteBackendEnContact.Core.Models
{
    public class ContactBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
