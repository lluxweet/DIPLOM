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
    internal class StatusOIplataRepository
    {
        public async Task<StatusoplataEntity[]> GetAllAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<StatusoplataEntity[]>($"{ServerConstants.Host}/v1/statusoplata");
            return response;
        }

        public async Task<StatusoplataEntity> GetAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<StatusoplataEntity>($"{ServerConstants.Host}/v1/statusoplata/{id}");
            return response;
        }

        public async Task<StatusoplataEntity> PostAsync(StatusoplataEntity statusoplata)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync($"{ServerConstants.Host}/v1/statusoplata", statusoplata);
            return await response.Content.ReadFromJsonAsync<StatusoplataEntity>();
        }

        public async Task<StatusoplataEntity> PutAsync(StatusoplataEntity statusoplata)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync($"{ServerConstants.Host}/v1/statusoplata", statusoplata);
            return await response.Content.ReadFromJsonAsync<StatusoplataEntity>();
        }

        public async Task<StatusoplataEntity> DeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.DeleteFromJsonAsync<StatusoplataEntity>($"{ServerConstants.Host}/v1/statusoplata/{id}");
            return response;
        }
    }
}
