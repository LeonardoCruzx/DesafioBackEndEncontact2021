using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteBackendEnContact.Api.Resources;
using TesteBackendEnContact.Core.Interfaces.Services;
using TesteBackendEnContact.Core.Models;

namespace TesteBackendEnContact.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactBookController : ControllerBase
    {
        private readonly IContactBookService _contactService;
        private readonly IMapper _mapper;
        public ContactBookController(IContactBookService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ContactBookResource>>> GetAllContactBooks()
        {
            var companies = await _contactService.GetAllContactBooks();
            var companiesResource = _mapper.Map<IEnumerable<ContactBook>, IEnumerable<ContactBookResource>>(companies);

            return Ok(companiesResource);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactBookResource>> GetContactBookById(int id)
        {
            var ContactBook = await _contactService.GetContactBookById(id);
            var ContactBookResource = _mapper.Map<ContactBook, ContactBookResource>(ContactBook);

            return Ok(ContactBookResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<ContactBookResource>> CreateContactBook([FromBody] ContactBookResource ContactBookResource)
        {
            var ContactBookCreated = await _contactService.CreateContactBook(_mapper.Map<ContactBookResource, ContactBook>(ContactBookResource));
            var ContactBookResourceCreated = _mapper.Map<ContactBook, ContactBookResource>(ContactBookCreated);

            return Ok(ContactBookResourceCreated);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ContactBookResource>> UpdateContactBook(int id, [FromBody] ContactBookResource ContactBookResource)
        {
            var ContactBookToBeUpdated = await _contactService.GetContactBookById(id);

            if (ContactBookToBeUpdated == null)
                return NotFound();

            var ContactBook = _mapper.Map<ContactBookResource, ContactBook>(ContactBookResource);
            await _contactService.UpdateContactBook(ContactBookToBeUpdated, ContactBook);
            var ContactBookResourceUpdated = _mapper.Map<ContactBook, ContactBookResource>(ContactBook);

            return Ok(ContactBookResourceUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContactBook(int id)
        {
            var ContactBookToBeDeleted = await _contactService.GetContactBookById(id);

            if (ContactBookToBeDeleted == null)
                return NotFound();

            await _contactService.DeleteContactBook(ContactBookToBeDeleted);

            return NoContent();
        }
    }
}