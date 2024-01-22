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
    public class CategoriaRepository
    {
        public async Task<CategoriaEntity[]> GetAllAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<CategoriaEntity[]>($"{ServerConstants.Host}/v1/categoria");
            return response;
        }

        public async Task<CategoriaEntity> GetAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<CategoriaEntity>($"{ServerConstants.Host}/v1/categoria/{id}");
            return response;
        }

        public async Task<CategoriaEntity> PostAsync(CategoriaEntity categoria)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync($"{ServerConstants.Host}/v1/categoria", categoria);
            return await response.Content.ReadFromJsonAsync<CategoriaEntity>();
        }

        public async Task<CategoriaEntity> PutAsync(CategoriaEntity categoria)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync($"{ServerConstants.Host}/v1/categoria", categoria);
            return await response.Content.ReadFromJsonAsync<CategoriaEntity>();
        }

        public async Task<CategoriaEntity> DeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.DeleteFromJsonAsync<CategoriaEntity>($"{ServerConstants.Host}/v1/categoria/{id}");
            return response;
        }
    }
}
