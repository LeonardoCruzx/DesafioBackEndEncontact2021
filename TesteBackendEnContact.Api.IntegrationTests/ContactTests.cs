using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFilterer.Swagger;
using Newtonsoft.Json;
using TesteBackendEnContact.Core.Models;

using TesteBackendEnContact.Api;
using Xunit;
using TesteBackendEnContact.Core.Pagination;
using System.Collections.Generic;
using TesteBackendEnContact.Api.Resources.Contact;


namespace TesteBackendEnContact.Api.IntegrationTests
{
    public class ContactTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;
        public static readonly string _baseUrl = "/api/Contact";

        public readonly List<SaveContactResource> _contacts = new List<SaveContactResource>
        {
            new SaveContactResource
            {
                Name = "Contact 1",
                Email = "Email 1",
                Phone = "Phone 1",
                ContactBookId = 1
            },
            new SaveContactResource
            {
                Name = "Contact 2",
                Email = "Email 2",
                Phone = "Phone 2",
                ContactBookId = 1
            },
            new SaveContactResource
            {
                Name = "Contact 3",
                Email = "Email 3",
                Phone = "Phone 3",
                ContactBookId = 1
            }
        };

        public ContactTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        private async Task<HttpResponseMessage> CreateContact(SaveContactResource Contact)
        {
            return await _client.PostAsync(_baseUrl, ContentHelper.GetStringContent(Contact));
        }

        [Fact]
        public async Task TestGetAllCompanies()
        {
            var response = await _client.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
        }
        
        [Fact]
        public async Task TestGetContactById()
        {
            var response = await _client.GetAsync(_baseUrl + "/1");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestCreateContact()
        {
            var response = await CreateContact(_contacts[0]);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestUpdateContact()
        {
            var createContactResponse = await CreateContact(_contacts[0]);

            var contactCreated = JsonConvert.DeserializeObject<ContactResource>(createContactResponse.Content.ReadAsStringAsync().Result);
            
            var response = await _client.PutAsync($"{_baseUrl}/{contactCreated.Id}", ContentHelper.GetStringContent(contactCreated));

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestDeleteContact()
        {
            var createContactResponse = await CreateContact(_contacts[0]);

            var contactCreated = JsonConvert.DeserializeObject<ContactResource>(createContactResponse.Content.ReadAsStringAsync().Result);

            var response = await _client.DeleteAsync($"{_baseUrl}/{contactCreated.Id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
