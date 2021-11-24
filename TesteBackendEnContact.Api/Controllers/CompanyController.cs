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

        [HttpPost("")]
        public async Task<ActionResult<CompanyResource>> CreateCompany([FromBody] CompanyResource companyResource)
        {
            Console.WriteLine("CompanyController.CreateCompany");
            Console.WriteLine(companyResource.Name);
            var companyCreated = await _companyService.CreateCompany(_mapper.Map<CompanyResource, Company>(companyResource));
            var companyResourceCreated = _mapper.Map<Company, CompanyResource>(companyCreated);
            return Ok(companyResourceCreated);
        }
        
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CompanyResource>>> GetAllCompanies()
        {

            return Ok(new List<CompanyResource>() {
                new CompanyResource() { Id = 1, Name = "Company 1" },
                new CompanyResource() { Id = 2, Name = "Company 2" },
                new CompanyResource() { Id = 3, Name = "Company 3" }
            });
        }
    }
}
