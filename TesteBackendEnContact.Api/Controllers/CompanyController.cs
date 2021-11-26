using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteBackendEnContact.Api.Resources;
using TesteBackendEnContact.Core.Interfaces.Services;
using AutoMapper;
using TesteBackendEnContact.Core.Models;
using System;
using TesteBackendEnContact.Core;
using TesteBackendEnContact.Core.Pagination;
using TesteBackendEnContact.Core.Filters;
using TesteBackendEnContact.Api.Resources.Contact;
using TesteBackendEnContact.Api.Resources.Company;

namespace TesteBackendEnContact.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<Paginator<CompanyResource>>> GetAllCompanies([FromQuery] QueryParams queryParams)
        {
            var paginatedCompanies = await _companyService.GetAllCompaniesPaginated(queryParams.Page, queryParams.ItemsPerPage);
            var paginatedCompaniesResource =  new Paginator<CompanyResource>(_mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(paginatedCompanies.Data), paginatedCompanies.Metadata);
            return Ok(paginatedCompaniesResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyResource>> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            var companyResource = _mapper.Map<Company, CompanyResource>(company);

            return Ok(companyResource);
        }
        [HttpGet("{companyId}/ContactBook/{contactBookId}/Contacts")]
        public async Task<ActionResult<Paginator<ContactResource>>> GetCompanyByIdWithContacts(int companyId, int contactBookId, [FromQuery] ContactFilter filter ,[FromQuery] QueryParams queryParams)
        {
            var company = await _companyService.GetContactsFromContactBookOfCompanyWithId(companyId, contactBookId, filter, queryParams.Page, queryParams.ItemsPerPage);
            
            
            var companyResource = new Paginator<ContactResource>(_mapper.Map<IEnumerable<Contact>, IEnumerable<ContactResource>>(company.Data), company.Metadata);

            return Ok(companyResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<CompanyResource>> CreateCompany([FromBody] CompanyResource companyResource)
        {
            var companyCreated = await _companyService.CreateCompany(_mapper.Map<CompanyResource, Company>(companyResource));
            var companyResourceCreated = _mapper.Map<Company, CompanyResource>(companyCreated);

            return Ok(companyResourceCreated);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyResource>> UpdateCompany(int id, [FromBody] CompanyResource companyResource)
        {
            var companyToBeUpdated = await _companyService.GetCompanyById(id);

            if (companyToBeUpdated == null)
                return NotFound();

            var company = _mapper.Map<CompanyResource, Company>(companyResource);
            await _companyService.UpdateCompany(companyToBeUpdated, company);
            var companyResourceUpdated = _mapper.Map<Company, CompanyResource>(company);

            return Ok(companyResourceUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var companyToBeDeleted = await _companyService.GetCompanyById(id);

            if (companyToBeDeleted == null)
                return NotFound();

            await _companyService.DeleteCompany(companyToBeDeleted);

            return NoContent();
        }
    }
}
