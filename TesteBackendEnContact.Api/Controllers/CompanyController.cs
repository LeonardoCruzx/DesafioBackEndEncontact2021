using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TesteBackendEnContact.Api.Resources;
using TesteBackendEnContact.Core.Interfaces.Services;
using AutoMapper;
using TesteBackendEnContact.Core.Models;
using System;

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

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CompanyResource>>> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompanies();
            var companiesResource = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);

            return Ok(companiesResource);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyResource>> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            var companyResource = _mapper.Map<Company, CompanyResource>(company);

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
    }
}
