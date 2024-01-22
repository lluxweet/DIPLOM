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
    internal class TypeOplataRepository
    {
        public async Task<TypeoplataEntity[]> GetAllAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<TypeoplataEntity[]>($"{ServerConstants.Host}/v1/typeoplata");
            return response;
        }

        public async Task<TypeoplataEntity> GetAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<TypeoplataEntity>($"{ServerConstants.Host}/v1/typeoplata/{id}");
            return response;
        }

        public async Task<TypeoplataEntity> PostAsync(TypeoplataEntity typeoplata)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync($"{ServerConstants.Host}/v1/typeoplata", typeoplata);
            return await response.Content.ReadFromJsonAsync<TypeoplataEntity>();
        }

        public async Task<TypeoplataEntity> PutAsync(TypeoplataEntity typeoplata)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync($"{ServerConstants.Host}/v1/typeoplata", typeoplata);
            return await response.Content.ReadFromJsonAsync<TypeoplataEntity>();
        }

        public async Task<TypeoplataEntity> DeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.DeleteFromJsonAsync<TypeoplataEntity>($"{ServerConstants.Host}/v1/typeoplata/{id}");
            return response;
        }
    }
}
