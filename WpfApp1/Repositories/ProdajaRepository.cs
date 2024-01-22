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
    internal class ProdajaRepository
    {
        public async Task<ProdajaEntity[]> GetAllAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<ProdajaEntity[]>($"{ServerConstants.Host}/v1/prodaja");
            return response;
        }

        public async Task<ProdajaEntity> GetAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<ProdajaEntity>($"{ServerConstants.Host}/v1/prodaja/{id}");
            return response;
        }

        public async Task<ProdajaEntity> PostAsync(ProdajaEntity prodaja)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync($"{ServerConstants.Host}/v1/prodaja", prodaja);
            return await response.Content.ReadFromJsonAsync<ProdajaEntity>();
        }

        public async Task<ProdajaEntity> PutAsync(ProdajaEntity prodaja)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync($"{ServerConstants.Host}/v1/prodaja", prodaja);
            return await response.Content.ReadFromJsonAsync<ProdajaEntity>();
        }

        public async Task<ProdajaEntity> DeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.DeleteFromJsonAsync<ProdajaEntity>($"{ServerConstants.Host}/v1/prodaja/{id}");
            return response;
        }
    }
}
