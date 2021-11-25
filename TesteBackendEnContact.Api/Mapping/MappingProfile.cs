using AutoMapper;
using TesteBackendEnContact.Api.Resources;
using TesteBackendEnContact.Api.Resources.Contact;
using TesteBackendEnContact.Core.Models;

namespace TesteBackendEnContact.Api.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyResource>();
            CreateMap<CompanyResource, Company>();

            CreateMap<ContactBook, ContactBookResource>();
            CreateMap<ContactBookResource, ContactBook>();

            #region Contact
            CreateMap<Contact, ContactResource>();
            CreateMap<ContactResource, Contact>();

            CreateMap<SaveContactResource, Contact>();
            CreateMap<Contact, SaveContactResource>();
            #endregion
        }
    }
}