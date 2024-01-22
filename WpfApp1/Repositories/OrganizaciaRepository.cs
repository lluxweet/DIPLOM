using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Repositories
{
    internal class OrganizaciaRepository
    {
        public async Task<OrganizaciaEntity[]> GetAllAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<OrganizaciaEntity[]>($"{ServerConstants.Host}/v1/organizacia");
            return response;
        }

        public async Task<OrganizaciaEntity> GetAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<OrganizaciaEntity>($"{ServerConstants.Host}/v1/organizacia/{id}");
            return response;
        }

        public async Task<OrganizaciaEntity> PostAsync(OrganizaciaEntity organizaciaEntity)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync($"{ServerConstants.Host}/v1/organizacia", organizaciaEntity);
            return await response.Content.ReadFromJsonAsync<OrganizaciaEntity>();
        }

        public async Task<OrganizaciaEntity> PutAsync(OrganizaciaEntity organizaciaEntity)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync($"{ServerConstants.Host}/v1/organizacia", organizaciaEntity);
            return await response.Content.ReadFromJsonAsync<OrganizaciaEntity>();
        }

        public async Task<OrganizaciaEntity> DeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.DeleteFromJsonAsync<OrganizaciaEntity>($"{ServerConstants.Host}/v1/organizacia/{id}");
            return response;
        }
    }
}
