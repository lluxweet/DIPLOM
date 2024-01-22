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
    internal class RoleRepository
    {
        public async Task<RoleEntity[]> GetAllAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<RoleEntity[]>($"{ServerConstants.Host}/v1/role");
            return response;
        }

        public async Task<RoleEntity> GetAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<RoleEntity>($"{ServerConstants.Host}/v1/role/{id}");
            return response;
        }

        public async Task<RoleEntity> PostAsync(RoleEntity roleEntity)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync($"{ServerConstants.Host}/v1/role", roleEntity);
            return await response.Content.ReadFromJsonAsync<RoleEntity>();
        }

        public async Task<RoleEntity> PutAsync(RoleEntity roleEntity)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync($"{ServerConstants.Host}/v1/role", roleEntity);
            return await response.Content.ReadFromJsonAsync<RoleEntity>();
        }

        public async Task<RoleEntity> DeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.DeleteFromJsonAsync<RoleEntity>($"{ServerConstants.Host}/v1/role/{id}");
            return response;
        }
    }
}
