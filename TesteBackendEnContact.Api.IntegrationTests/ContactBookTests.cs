using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFilterer.Swagger;
using Newtonsoft.Json;

using Xunit;

using System.Collections.Generic;

using TesteBackendEnContact.Api.Resources.ContactBook;
using TesteBackendEnContact.Api.Resources.Company;
using AutoMapper;
using TesteBackendEnContact.Core.Models;

namespace TesteBackendEnContact.Api.IntegrationTests
{
    public class ContactBookTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;
        public static readonly string _baseUrl = "/api/ContactBook";

        public readonly List<SaveContactBookResource> _contactBooks = new List<SaveContactBookResource>
        {
            new SaveContactBookResource
            {
                Name = "ContactBook 1",
                Description = "ContactBook 1 Description",
                CompanyId = 1
            },
            new SaveContactBookResource
            {
                Name = "ContactBook 2",
                Description = "ContactBook 2 Description",
                CompanyId = 1
            },
            new SaveContactBookResource
            {
                Name = "ContactBook 3",
                Description = "ContactBook 3 Description",
                CompanyId = 1
            }
        };

        public ContactBookTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        private async Task<HttpResponseMessage> CreateContactBook(SaveContactBookResource contactBook)
        {
            return await _client.PostAsync(_baseUrl, ContentHelper.GetStringContent(contactBook));
        }

        private async Task<HttpResponseMessage> CreateCompany(SaveCompanyResource company)
        {
            return await _client.PostAsync(CompanyTests._baseUrl, ContentHelper.GetStringContent(company));
        }

        [Fact]
        public async Task TestGetAllCompanies()
        {
            var response = await _client.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
        }
        
        [Fact]
        public async Task TestGetContactBookById()
        {
            var response = await _client.GetAsync(_baseUrl + "/1");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestCreateContactBook()
        {
            var companyCreatedResponse = await CreateCompany(CompanyTests._companies[0]);

            var companyCreated = JsonConvert.DeserializeObject<Company>(companyCreatedResponse.Content.ReadAsStringAsync().Result);

            var contactBookToBeCreated =  new SaveContactBookResource(_contactBooks[0])
            {
                CompanyId = companyCreated.Id
            };

            var response = await CreateContactBook(contactBookToBeCreated);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestUpdateContactBook()
        {
            var companyCreatedResponse = await CreateCompany(CompanyTests._companies[0]);

            var companyCreated = JsonConvert.DeserializeObject<Company>(companyCreatedResponse.Content.ReadAsStringAsync().Result);

            var contactBookToBeCreated =  new SaveContactBookResource(_contactBooks[0])
            {
                CompanyId = companyCreated.Id
            };

            var createContactBookResponse = await CreateContactBook(contactBookToBeCreated);

            var contactBookCreated = JsonConvert.DeserializeObject<ContactBookResource>(createContactBookResponse.Content.ReadAsStringAsync().Result);

            contactBookCreated.Name = "ContactBook Updated";

            
            var response = await _client.PutAsync($"{_baseUrl}/{contactBookCreated.Id}", ContentHelper.GetStringContent(contactBookCreated));

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestDeleteContactBook()
        {
            var companyCreatedResponse = await CreateCompany(CompanyTests._companies[0]);

            var companyCreated = JsonConvert.DeserializeObject<Company>(companyCreatedResponse.Content.ReadAsStringAsync().Result);

            var contactBookToBeCreated =  new SaveContactBookResource(_contactBooks[0])
            {
                CompanyId = companyCreated.Id
            };

            var createContactBookResponse = await CreateContactBook(contactBookToBeCreated);

            var contactBookCreated = JsonConvert.DeserializeObject<ContactBookResource>(createContactBookResponse.Content.ReadAsStringAsync().Result);

            var response = await _client.DeleteAsync($"{_baseUrl}/{contactBookCreated.Id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
