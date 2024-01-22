using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using System.Net.Http.Json;

namespace WpfApp1.Repositories
{
    internal class UserRepository
    {
        public async Task<UserEntity[]> GetAllAsync()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<UserEntity[]>($"{ServerConstants.Host}/v1/user");
            return response;
        } 

        public async Task<UserEntity> GetAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetFromJsonAsync<UserEntity>($"{ServerConstants.Host}/v1/user/{id}");
            return response;
        }

        public async Task<UserEntity> PostAsync(UserEntity userEntity)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsJsonAsync($"{ServerConstants.Host}/v1/user", userEntity);
            return await response.Content.ReadFromJsonAsync<UserEntity>();
        }

        public async Task<UserEntity> PutAsync(UserEntity userEntity)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PutAsJsonAsync($"{ServerConstants.Host}/v1/user", userEntity);
            return await response.Content.ReadFromJsonAsync<UserEntity>();
        }

        public async Task<UserEntity> DeleteAsync(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.DeleteFromJsonAsync<UserEntity>($"{ServerConstants.Host}/v1/user/{id}");
            return response;
        }

    }
}
