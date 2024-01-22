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
    internal class PredprinimatelRepository
    {
        public async Task<PredprinimatelEntity[]> GetAllAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<PredprinimatelEntity[]>($"{ServerConstants.Host}/v1/predprinimatel");
            return response;
        }

        public async Task<PredprinimatelEntity> GetAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<PredprinimatelEntity>($"{ServerConstants.Host}/v1/predprinimatel/{id}");
            return response;
        }

        public async Task<PredprinimatelEntity> PostAsync(PredprinimatelEntity predprinimatelEntity)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync($"{ServerConstants.Host}/v1/predprinimatel", predprinimatelEntity);
            return await response.Content.ReadFromJsonAsync<PredprinimatelEntity>();
        }

        public async Task<PredprinimatelEntity> PutAsync(PredprinimatelEntity predprinimatelEntity)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync($"{ServerConstants.Host}/v1/predprinimatel", predprinimatelEntity);
            return await response.Content.ReadFromJsonAsync<PredprinimatelEntity>();
        }

        public async Task<PredprinimatelEntity> DeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.DeleteFromJsonAsync<PredprinimatelEntity>($"{ServerConstants.Host}/v1/predprinimatel/{id}");
            return response;
        }
    }
}
