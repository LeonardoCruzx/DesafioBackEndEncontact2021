using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TesteBackendEnContact.Api.Resources;
using TesteBackendEnContact.Core.Interfaces.Services;
using TesteBackendEnContact.Core.Models;

namespace TesteBackendEnContact.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ContactResource>>> GetAllContacts()
        {
            var companies = await _contactService.GetAllContacts();
            var companiesResource = _mapper.Map<IEnumerable<Contact>, IEnumerable<ContactResource>>(companies);

            return Ok(companiesResource);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactResource>> GetContactById(int id)
        {
            var Contact = await _contactService.GetContactById(id);
            var ContactResource = _mapper.Map<Contact, ContactResource>(Contact);

            return Ok(ContactResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<ContactResource>> CreateContact([FromBody] ContactResource ContactResource)
        {
            var ContactCreated = await _contactService.CreateContact(_mapper.Map<ContactResource, Contact>(ContactResource));
            var ContactResourceCreated = _mapper.Map<Contact, ContactResource>(ContactCreated);

            return Ok(ContactResourceCreated);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ContactResource>> UpdateContact(int id, [FromBody] ContactResource ContactResource)
        {
            var ContactToBeUpdated = await _contactService.GetContactById(id);

            if (ContactToBeUpdated == null)
                return NotFound();

            var Contact = _mapper.Map<ContactResource, Contact>(ContactResource);
            await _contactService.UpdateContact(ContactToBeUpdated, Contact);
            var ContactResourceUpdated = _mapper.Map<Contact, ContactResource>(Contact);

            return Ok(ContactResourceUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            var ContactToBeDeleted = await _contactService.GetContactById(id);

            if (ContactToBeDeleted == null)
                return NotFound();

            await _contactService.DeleteContact(ContactToBeDeleted);

            return NoContent();
        }
    }
}