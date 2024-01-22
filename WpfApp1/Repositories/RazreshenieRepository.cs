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
    internal class RazreshenieRepository
    {
        public async Task<RazreshenieEntity[]> GetAllAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<RazreshenieEntity[]>($"{ServerConstants.Host}/v1/razreshenie");
            return response;
        }

        public async Task<RazreshenieEntity> GetAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<RazreshenieEntity>($"{ServerConstants.Host}/v1/razreshenie/{id}");
            return response;
        }

        public async Task<RazreshenieEntity> PostAsync(RazreshenieEntity razreshenie)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync($"{ServerConstants.Host}/v1/razreshenie", razreshenie);
            return await response.Content.ReadFromJsonAsync<RazreshenieEntity>();
        }

        public async Task<RazreshenieEntity> PutAsync(RazreshenieEntity razreshenie)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync($"{ServerConstants.Host}/v1/razreshenie", razreshenie);
            return await response.Content.ReadFromJsonAsync<RazreshenieEntity>();
        }

        public async Task<RazreshenieEntity> DeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.DeleteFromJsonAsync<RazreshenieEntity>($"{ServerConstants.Host}/v1/razreshenie/{id}");
            return response;
        }
    }
}
