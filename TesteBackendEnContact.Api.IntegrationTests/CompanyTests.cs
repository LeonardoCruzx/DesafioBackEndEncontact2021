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
using TesteBackendEnContact.Api.Resources.Company;

namespace TesteBackendEnContact.Api.IntegrationTests
{
    public class CompanyTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl = "/api/Company";

        private readonly List<SaveCompanyResource> _companies = new List<SaveCompanyResource>
        {
            new SaveCompanyResource
            {
                Name = "Company 1",
                Cnpj = "12345678901234",
                Email = ""
            },
            new SaveCompanyResource
            {
                Name = "Company 2",
                Cnpj = "12345678901234",
                Email = ""
            },
            new SaveCompanyResource
            {
                Name = "Company 3",
                Cnpj = "12345678901234",
                Email = ""
            },
        };

        public CompanyTests(TestFixture<Startup> fixture)
        {
            _client = fixture.Client;
        }

        private async Task<HttpResponseMessage> CreateCompany(Company company)
        {
            return await _client.PostAsync(_baseUrl, ContentHelper.GetStringContent(company));
        }

        [Fact]
        public async Task TestGetAllCompanies()
        {
            var response = await _client.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
        }
        
        [Fact]
        public async Task TestGetCompanyById()
        {
            var response = await _client.GetAsync(_baseUrl + "/1");
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestCreateCompany()
        {
            var company = new Company
            {
                Name = "Teste",
                Cnpj = "12345678901234",
                Email = "aa"
            };
            var response = await _client.PostAsync(_baseUrl, ContentHelper.GetStringContent(company));

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestUpdateCompany()
        {
            var company = new Company
            {
                Name = "Teste",
                Cnpj = "12345678901234",
                Email = "aa"
            };
            var createCompanyResponse = await CreateCompany(company);

            var companyCreated = JsonConvert.DeserializeObject<Company>(createCompanyResponse.Content.ReadAsStringAsync().Result);
            
            var response = await _client.PutAsync($"{_baseUrl}/{companyCreated.Id}", ContentHelper.GetStringContent(company));

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestDeleteCompany()
        {
            var company = new Company
            {
                Name = "Teste",
                Cnpj = "12345678901234",
                Email = "aa"
            };

            var createCompanyResponse = await CreateCompany(company);

            var companyCreated = JsonConvert.DeserializeObject<Company>(createCompanyResponse.Content.ReadAsStringAsync().Result);

            var response = await _client.DeleteAsync($"{_baseUrl}/{companyCreated.Id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
