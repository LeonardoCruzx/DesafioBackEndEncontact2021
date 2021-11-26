using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using TesteBackendEnContact.Api.Resources;
using TesteBackendEnContact.Api.Resources.ContactBook;
using TesteBackendEnContact.Core.Interfaces.Services;
using TesteBackendEnContact.Core.Models;
using TesteBackendEnContact.Core.Pagination;

namespace TesteBackendEnContact.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactBookController : ControllerBase
    {
        private readonly IContactBookService _contactBookService;
        private readonly IMapper _mapper;
        public ContactBookController(IContactBookService contactService, IMapper mapper)
        {
            _contactBookService = contactService;
            _mapper = mapper;
        }


        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ContactBookResource>>> GetAllContactBooks()
        {
            var companies = await _contactBookService.GetAllContactBooksPaginated();
            var companiesResource = new Paginator<ContactBookResource>(_mapper.Map<IEnumerable<ContactBook>, IEnumerable<ContactBookResource>>(companies.Data), companies.Metadata);

            return Ok(companiesResource);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactBookResource>> GetContactBookById(int id)
        {
            var ContactBook = await _contactBookService.GetContactBookById(id);
            var ContactBookResource = _mapper.Map<ContactBook, ContactBookResource>(ContactBook);

            return Ok(ContactBookResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<ContactBookResource>> CreateContactBook([FromBody] ContactBookResource ContactBookResource)
        {
            var ContactBookCreated = await _contactBookService.CreateContactBook(_mapper.Map<ContactBookResource, ContactBook>(ContactBookResource));
            var ContactBookResourceCreated = _mapper.Map<ContactBook, ContactBookResource>(ContactBookCreated);

            return Ok(ContactBookResourceCreated);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ContactBookResource>> UpdateContactBook(int id, [FromBody] ContactBookResource ContactBookResource)
        {
            var ContactBookToBeUpdated = await _contactBookService.GetContactBookById(id);

            if (ContactBookToBeUpdated == null)
                return NotFound();

            var ContactBook = _mapper.Map<ContactBookResource, ContactBook>(ContactBookResource);
            await _contactBookService.UpdateContactBook(ContactBookToBeUpdated, ContactBook);
            var ContactBookResourceUpdated = _mapper.Map<ContactBook, ContactBookResource>(ContactBook);

            return Ok(ContactBookResourceUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContactBook(int id)
        {
            var ContactBookToBeDeleted = await _contactBookService.GetContactBookById(id);

            if (ContactBookToBeDeleted == null)
                return NotFound();

            await _contactBookService.DeleteContactBook(ContactBookToBeDeleted);

            return NoContent();
        }

        [HttpGet("{id}/ExportContactsToCsv")]
        public async Task<FileResult> ExportContactsToCsv(int id)
        {
            var contactBook = await _contactBookService.GetContactBookByIdWithContacts(id);
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            var csv = new CsvWriter(writer, System.Globalization.CultureInfo.CurrentCulture);

            csv.WriteRecords(contactBook.Contacts);
            writer.Flush();
            stream.Position = 0;

            return File(stream, "text/csv", "contacts.csv");
        }
    }
}