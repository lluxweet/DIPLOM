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
    internal class ClientRepository
    {
        public async Task<ClientEntity[]> GetAllAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<ClientEntity[]>($"{ServerConstants.Host}/v1/client");
            return response;
        }

        public async Task<ClientEntity> GetAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<ClientEntity>($"{ServerConstants.Host}/v1/client/{id}");
            return response;
        }

        public async Task<ClientEntity> PostAsync(ClientEntity client)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync($"{ServerConstants.Host}/v1/client", client);
            return await response.Content.ReadFromJsonAsync<ClientEntity>();
        }

        public async Task<ClientEntity> PutAsync(ClientEntity client)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync($"{ServerConstants.Host}/v1/client", client);
            return await response.Content.ReadFromJsonAsync<ClientEntity>();
        }

        public async Task<ClientEntity> DeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.DeleteFromJsonAsync<ClientEntity>($"{ServerConstants.Host}/v1/client/{id}");
            return response;
        }
    }
}
