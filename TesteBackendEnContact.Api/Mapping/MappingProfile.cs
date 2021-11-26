using AutoMapper;
using TesteBackendEnContact.Api.Resources;
using TesteBackendEnContact.Api.Resources.Company;
using TesteBackendEnContact.Api.Resources.Contact;
using TesteBackendEnContact.Api.Resources.ContactBook;
using TesteBackendEnContact.Core.Models;

namespace TesteBackendEnContact.Api.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            #region Company
            CreateMap<Company, CompanyResource>();
            CreateMap<CompanyResource, Company>();

            CreateMap<Company, SaveCompanyResource>();
            CreateMap<SaveCompanyResource, Company>();

            CreateMap<CompanyResource, SaveCompanyResource>();
            CreateMap<SaveCompanyResource, CompanyResource>();
            #endregion

            #region ContactBook
            CreateMap<ContactBook, ContactBookResource>();
            CreateMap<ContactBookResource, ContactBook>();

            CreateMap<ContactBook, SaveContactBookResource>();
            CreateMap<SaveContactBookResource, ContactBook>();
            #endregion

            #region Contact
            CreateMap<Contact, ContactResource>();
            CreateMap<ContactResource, Contact>();

            CreateMap<SaveContactResource, Contact>();
            CreateMap<Contact, SaveContactResource>();
            #endregion
        }
    }
}