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
    internal class StatusRepository
    {
        public async Task<StatusEntity[]> GetAllAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<StatusEntity[]>($"{ServerConstants.Host}/v1/status");
            return response;
        }

        public async Task<StatusEntity> GetAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<StatusEntity>($"{ServerConstants.Host}/v1/status/{id}");
            return response;
        }

        public async Task<StatusEntity> PostAsync(StatusEntity status)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync($"{ServerConstants.Host}/v1/status", status);
            return await response.Content.ReadFromJsonAsync<StatusEntity>();
        }

        public async Task<StatusEntity> PutAsync(StatusEntity status)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync($"{ServerConstants.Host}/v1/status", status);
            return await response.Content.ReadFromJsonAsync<StatusEntity>();
        }

        public async Task<StatusEntity> DeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.DeleteFromJsonAsync<StatusEntity>($"{ServerConstants.Host}/v1/status/{id}");
            return response;
        }
    }
}
