using AutoMapper;
using TesteBackendEnContact.Api.Resources;
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
        }
    }
}